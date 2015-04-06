using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Minions
{
    public class ShateredSunCleric : Minion
    {
        public ShateredSunCleric(CardInfo card)
            : base(0, card)
        {
        }

        public override void Battlecry(Board board, ICharacter target)
        {
            if (target != null)
            {
                target.Attack = target.Attack + 1;
                target.MaximumHealth = target.MaximumHealth + 1;
                target.Health = target.Health + 1;
            }
        }
    }
}
