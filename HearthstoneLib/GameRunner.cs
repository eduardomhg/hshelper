using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    /// <summary>
    /// Runs a Hearthstone game.
    /// 
    /// <remarks>
    /// Rules from http://hearthstone.gamepedia.com/Advanced_rulebook has been used.
    /// </summary>
    public class GameRunner
    {
        private Board _board;
        public Board Board { get { return _board; } }
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer Player(PlayerTurn player) { return player == PlayerTurn.Player1 ? _player1 : _player2; }
        private PlayerTurn _currentTurn;
        private int _numberOfTurns;
        private TraceListener _traceListener;

        public GameRunner(IPlayer player1, IPlayer player2, TraceListener traceListener)
        {
            _player1 = player1;
            _player1.Turn = PlayerTurn.Player1;
            _player2 = player2;
            _player2.Turn = PlayerTurn.Player2;

            IList<Card> player1SortedDeck = new List<Card>();            
            foreach (CardInfo info in player1.Deck)
            {
                player1SortedDeck.Add(new Card(info));
            }
            player1SortedDeck.Shuffle();

            IList<Card> player2SortedDeck = new List<Card>();
            foreach (CardInfo info in player2.Deck)
            {
                player2SortedDeck.Add(new Card(info));
            }
            player2SortedDeck.Shuffle();

            _traceListener = traceListener;
            _board = new Board(new Queue<Card>(player1SortedDeck), new Queue<Card>(player2SortedDeck), player1.Class, player2.Class, _traceListener);

            _currentTurn = PlayerTurn.Player1;
            _numberOfTurns = 0;            
        }

        public PlayerTurn RunGame()
        {
            Trace("Game starts");

            Trace("Player 1 is " + _player1.Class);
            Trace("Player 2 is " + _player2.Class);

            // Do Mulligan for both players.
            DoMulligan(PlayerTurn.Player1);
            DoMulligan(PlayerTurn.Player2);

            // Process each turn until one of the players is dead.
            while (!GameIsOver())
            {
                _numberOfTurns++;
                Trace("Turn " + _numberOfTurns + " begins");
                ProcessTurn(PlayerTurn.Player1);
                ProcessTurn(PlayerTurn.Player2);
                Trace("Turn " + _numberOfTurns + " ends. Player 1 has " + _board.Hero(PlayerTurn.Player1).Health + " HP, Player 2 has " +
                    _board.Hero(PlayerTurn.Player2).Health + " HP");
            }

            // And return the winner player.
            PlayerTurn winner = GetWinner();
            Trace("Game ends");
            Trace("The winner is " + winner.ToCoolString());

            return winner;
        }

        private void ProcessTurn(PlayerTurn player)
        {
            PlayerAction action = null;

            ProcessStartOfTurn(player);

            do
            {
                action = Player(player).ChooseAction(_board);
                ProcessPlayerAction(player, action);
            }
            while (action.Type != PlayerActionType.JobsDone);

            ProcessEndOfTurn(player);
        }

        private void ProcessStartOfTurn(PlayerTurn player)
        {
            _board.ProcessTurnStart();
            _board.DrawCard(player);
            if (_board.Hero(player).MaximumMana < Limits.MaximumManaCrystals)            
            {                
                _board.Hero(player).MaximumMana = _board.Hero(player).MaximumMana + 1;
                Trace(player.ToCoolString() + " gets a mana crystal (" + _board.Hero(player).MaximumMana + ")");
            }
            _board.Hero(player).Mana = _board.Hero(player).MaximumMana;
        }

        private void ProcessEndOfTurn(PlayerTurn player)
        {
        }

        private void ProcessPlayerAction(PlayerTurn player, PlayerAction action)
        {
            switch (action.Type)
            {
                case PlayerActionType.PlayCard:
                    Trace(player.ToCoolString() + " plays " + action.PlayedCard);
                    _board.RemovePlayedCard(player, action.PlayedCard);
                    switch (action.PlayedCard.Info.Type)
	                {
                        case CardType.Minion:
                            IMinion minion = Minion.FromCard(action.PlayedCard);
                            _board.AddMinion(player, minion, action.PlayedCardBoardPosition);
                            minion.Battlecry(_board, action.Target);
                            break;
                        case CardType.Spell:
                            ISpell spell = Spell.FromCard(action.PlayedCard);
                            spell.Cast(player, action.Target, _board.Hero(player).SpellPower, _board);
                            break;
                        case CardType.Weapon:
                            IWeapon weapon = Weapon.FromCard(action.PlayedCard);
                            _board.SetWeapon(player, weapon);
                            break;
                        default:
                            Debug.Fail("Invalid card type");
                            break;
	                }
                    break;
                case PlayerActionType.UseHeroPower:
                    _board.Hero(player).UseHeroPower(player, _board, action.Target);
                    break;
                case PlayerActionType.AttackWithWeapon:
                    action.Target.TakeDamage(action.Source);
                    action.Source.TakeDamage(action.Target);
                    break;
                case PlayerActionType.AttackWithMinion:
                    Trace(player.ToCoolString() + " attacks " + action.Target + " with " + action.Source);
                    action.Target.TakeDamage(action.Source);
                    action.Source.TakeDamage(action.Target);
                    action.Source.TimesAttackedThisTurn = action.Source.TimesAttackedThisTurn + 1;
                    break;
                case PlayerActionType.JobsDone:
                    Trace(player.ToCoolString() + " says that Job's Done");
                    break;
                default:
                    Debug.Fail("Invalid player action");
                    break;
            }
        }

        private void DoMulligan(PlayerTurn player)
        {
            int numberOfInitialcards = player == PlayerTurn.Player1 ? Limits.NumberOfInitialCardsPlayer1 : 
                                                                      Limits.NumberOfInitialCardsPlayer2;
            
            List<Card> initialHand = _board.DrawCards(player, numberOfInitialcards);
            Trace(player.ToCoolString() + " initially draws " + initialHand.ToCoolString());
            List<Card> mulliganedCards = Player(player).ChooseMulligan(initialHand);
            Trace(player.ToCoolString() + " chooses to mulligan " + mulliganedCards.ToCoolString());
            _board.MulliganCards(player, mulliganedCards);
            List<Card> secondHand = _board.DrawCards(player, mulliganedCards.Count);
            Trace(player.ToCoolString() + " draws " + secondHand.ToCoolString());
            
            if (player == PlayerTurn.Player2)
            {
                Trace(player.ToCoolString() + " gets The Coin");
                _board.AddCardToHand(player, Card.TheCoin);
            }
        }

        private bool GameIsOver()
        {
            return _board.Player1Hero.IsDead || _board.Player2Hero.IsDead;
        }

        private PlayerTurn GetWinner()
        {
            if (_board.Player1Hero.IsDead)
            {
                return PlayerTurn.Player2;
            }
            return PlayerTurn.Player1;
        }

        private void Trace(string format, params object[] args)
        {
            _traceListener.WriteLine(String.Format(format, args));
        }

    }
}
