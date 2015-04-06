using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public class Board
    {
        public Queue<Card> Player1Deck;
        public Queue<Card> Player2Deck;
        public Queue<Card> Deck(PlayerTurn player) { return (player == PlayerTurn.Player1 ? Player1Deck : Player2Deck); }
        public void SetDeck(PlayerTurn player, Queue<Card> deck) { if (player == PlayerTurn.Player1) Player1Deck = deck; else Player2Deck = deck; }

        public List<Card> Player1Graveyard;
        public List<Card> Player2Graveyard;
        public List<Card> Graveyard(PlayerTurn player) { return (player == PlayerTurn.Player1 ? Player1Graveyard : Player2Graveyard); }

        public ObservableCollection<Card> Player1Hand;
        public ObservableCollection<Card> Player2Hand;
        public ObservableCollection<Card> Hand(PlayerTurn player) { return (player == PlayerTurn.Player1 ? Player1Hand : Player2Hand); }

        public List<IMinion> Player1Minions;
        public List<IMinion> Player2Minions;
        public List<IMinion> Minions(PlayerTurn player) { return (player == PlayerTurn.Player1 ? Player1Minions : Player2Minions); }

        public IWeapon Player1Weapon;
        public IWeapon Player2Weapon;
        public IWeapon Weapon(PlayerTurn player) { return (player == PlayerTurn.Player1 ? Player1Weapon : Player2Weapon); }
        public void SetWeapon(PlayerTurn player, IWeapon weapon) { if (player == PlayerTurn.Player1) Player1Weapon = weapon; else Player2Weapon = weapon; }

        public List<ISecret> Player1Secrets;
        public List<ISecret> Player2Secrets;

        public IHero Player1Hero;
        public IHero Player2Hero;
        public IHero Hero(PlayerTurn player) { return (player == PlayerTurn.Player1 ? Player1Hero : Player2Hero); }
        private TraceListener _traceListener;

        public Board(Queue<Card> player1Deck, Queue<Card> player2Deck, PlayerClass player1Class, PlayerClass player2Class, TraceListener traceListener)
        {
            Player1Deck = player1Deck;
            Player2Deck = player2Deck;
            Player1Graveyard = new List<Card>();
            Player2Graveyard = new List<Card>();
            Player1Hand = new ObservableCollection<Card>();
            Player2Hand = new ObservableCollection<Card>();
            Player1Minions = new List<IMinion>();
            Player2Minions = new List<IMinion>();
            Player1Weapon = null;
            Player2Weapon = null;
            Player1Secrets = new List<ISecret>();
            Player2Secrets = new List<ISecret>();
            Player1Hero = Hearthstone.Hero.Create((int)PlayerTurn.Player1, player1Class);
            Player2Hero = Hearthstone.Hero.Create((int)PlayerTurn.Player2, player2Class);
            _traceListener = traceListener;
        }

        public Card DrawCard(PlayerTurn player)
        {
            Card drawnCard = null;

            if (Deck(player).Count > 0)
            {
                drawnCard = Deck(player).Dequeue();
                Debug.Assert(drawnCard != null);
                Trace(player.ToCoolString() + " draws " + drawnCard);
                if (Hand(player).Count < Limits.MaximumCardsPerHand)
                {
                    Hand(player).Add(drawnCard);
                }
                else
                {
                    Trace(player.ToCoolString() + "'s hand is full and " + drawnCard + " is destroyed");
                    Graveyard(player).Add(drawnCard);
                }
            }
            else
            {
                Trace(player.ToCoolString() + " has no cards to draw and gets Fatigue damage");

                // No more cards, apply Fatigue damage to the hero.
                Hero(player).TakeFatigueDamage();
            }
            return drawnCard;
        }

        public List<Card> DrawCards(PlayerTurn player, int numCards)
        {
            List<Card> drawnCards = new List<Card>(numCards);
            for (int i = 0; i < numCards; i++)
            {
                Card drawnCard = DrawCard(player);
                if (drawnCard != null)
                {
                    drawnCards.Add(drawnCard);
                }
                else
                {
                    break;
                }
            }
            return drawnCards;
        }

        public void MulliganCards(PlayerTurn player, List<Card> mulliganedCards)        
        {
            foreach (Card card in mulliganedCards)
            {
                bool removed = Hand(player).Remove(card);
                Debug.Assert(removed);
                Deck(player).Enqueue(card);
            }
            ShuffleDeck(player);
        }

        public void AddCardToHand(PlayerTurn player, Card card)
        {
            Hand(player).Add(card);
        }

        public ICharacter GetRandomCharacter(PlayerTurn player)
        {
            List<ICharacter> chars = new List<ICharacter>(1 + Minions(player).Count);
            chars.Add(Hero(player));
            chars.AddRange(Minions(player));
            return chars.GetRandomItem();
        }

        public ICharacter GetRandomCharacter()
        {
            List<ICharacter> chars = new List<ICharacter>(2 + Player1Minions.Count + Player2Minions.Count);
            chars.Add(Player1Hero);
            chars.AddRange(Player1Minions);
            chars.Add(Player2Hero);
            chars.AddRange(Player2Minions);
            return chars.GetRandomItem();
        }

        public IMinion GetRandomMinion(PlayerTurn player)
        {
            return Minions(player).GetRandomItem();
        }

        private void ShuffleDeck(PlayerTurn player)
        {
            IList<Card> deckList = new List<Card>(Deck(player));
            deckList.Shuffle();
            SetDeck(player, new Queue<Card>(deckList));
        }

        public void RemovePlayedCard(PlayerTurn player, Card card)
        {
            bool removed = Hand(player).Remove(card);
            Debug.Assert(removed);
            Graveyard(player).Add(card);

            Hero(player).Mana = Hero(player).Mana - card.CurrentCost;
            Debug.Assert(Hero(player).Mana >= 0);
        }

        public void AddMinion(PlayerTurn player, IMinion minion, int boardPosition)
        {
            Minions(player).Insert(boardPosition, minion);
        }

        public void AddMinion(PlayerTurn player, IMinion minion)
        {
            Minions(player).Add(minion);
        }

        public bool IsPlayable(PlayerTurn player, Card card)
        {
            bool playable = false;

            if (card.CurrentCost <= Hero(player).Mana)
            {
                playable = true;
            }

            return playable;
        }

        public bool CanAttack(PlayerTurn player, IMinion minion)
        {
            bool canAttack = false;

            // Can't attack if summoned this turn, unless it has Change
            // Can't attack if already attacked this turn (twice if it has Windfury)
            // Can't attack if frozen.
            if ((!minion.SummonedThisTurn || minion.HasCharge) &&                  
                (minion.TimesAttackedThisTurn < 1 || (minion.HasWindfury && minion.TimesAttackedThisTurn < 2)) &&
                (!minion.IsFrozen))
            {
                canAttack = true;
            }

            return canAttack;
        }

        public void ProcessTurnStart()
        {
            Player1Hero.ProcessTurnStart();
            Player2Hero.ProcessTurnStart();
            foreach (IMinion minion in Player1Minions)
            {
                minion.ProcessTurnStart();
            }
            foreach (IMinion minion in Player2Minions)
            {
                minion.ProcessTurnStart();
            }
        }

        private void Trace(string format, params object[] args)
        {
            _traceListener.WriteLine(String.Format(format, args));
        }

    }
}
