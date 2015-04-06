using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Players
{
    public class LazyPlayer : Player
    {
        public LazyPlayer(PlayerClass playerClass, Deck deck) : base (playerClass, deck)
        {
        }

        public override PlayerAction ChooseAction(Board board)
        {
            return new PlayerAction(PlayerActionType.JobsDone);
        }

        public override List<Card> ChooseMulligan(List<Card> initialHand)
        {
            return new List<Card>();
        }
    }
}
