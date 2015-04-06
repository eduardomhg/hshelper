using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Spells
{
    public class Flamestrike : Spell
    {
        public override void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board)
        {
            foreach (IMinion minion in board.Minions(castingPlayer.Opossite()))
            {
                minion.TakeDamage(4 + spellPower);
            }
        }
    }
}
