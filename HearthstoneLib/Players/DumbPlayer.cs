using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Players
{
    public class DumbPlayer : Player
    {
        public DumbPlayer(PlayerClass playerClass, Deck deck)
            : base(playerClass, deck)
        {
        }

        public override PlayerAction ChooseAction(Board board)
        {
            PlayerAction action = new PlayerAction(PlayerActionType.JobsDone);

            foreach (Card card in board.Hand(Turn))
            {
                if (board.IsPlayable(Turn, card))
                {
                    action.Type = PlayerActionType.PlayCard;
                    action.PlayedCard = card;
                    break;
                }
            }

            if (action.Type == PlayerActionType.JobsDone)
            {
                foreach (Minion minion in board.Minions(Turn))
                {
                    if (board.CanAttack(Turn, minion))
                    {
                        action.Type = PlayerActionType.AttackWithMinion;
                        action.Source = minion;
                        action.Target = board.Hero(Turn.Opossite());
                    }
                }
            }

            return action;
        }

        public override List<Card> ChooseMulligan(List<Card> initialHand)
        {
            return initialHand;
        }
    }
}
