using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Spells
{
    public class ArcaneExplosion : Spell
    {
        public override void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board)
        {
            foreach (IMinion minion in board.Minions(castingPlayer.Opossite()))
            {
                minion.TakeDamage(1 + spellPower);
            }
        }
    }
}
