using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface ISpell
    {
        void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board);
    }
}
