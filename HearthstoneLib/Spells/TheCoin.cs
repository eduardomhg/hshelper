using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Spells
{
    public class TheCoin : Spell
    {
        public override void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board)
        {
            if (board.Hero(castingPlayer).Mana < Limits.MaximumManaCrystals)
            {
                board.Hero(castingPlayer).Mana = board.Hero(castingPlayer).Mana + 1;
            }
        }
    }
}
