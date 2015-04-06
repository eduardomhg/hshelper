using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Spells
{
    public class ArcaneMissiles : Spell
    {
        public override void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board)
        {
            for (int i = 0; i < 3 + spellPower; i++)
            {
                board.GetRandomCharacter(castingPlayer.Opossite()).TakeDamage(1);
            }
        }
    }
}
