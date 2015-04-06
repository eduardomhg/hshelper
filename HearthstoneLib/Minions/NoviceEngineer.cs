using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Minions
{
    public class NoviceEngineer : Minion
    {
        public NoviceEngineer(CardInfo card)
            : base(0, card)
        {
        }

        public override void Battlecry(Board board, ICharacter target)
        {
            board.DrawCard(PlayerTurn.Player2);
        }
    }
}
