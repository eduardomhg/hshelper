using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Spells
{
    public class Fireball : Spell
    {
        public override void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board)
        {
            target.TakeDamage(6 + spellPower);
        }
    }
}
