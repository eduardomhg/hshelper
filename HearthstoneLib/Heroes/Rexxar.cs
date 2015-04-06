using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Heroes
{
    public class Rexxar : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Hunter; }
        }

        public Rexxar(int id)
            : base(id, "Rexxar")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            board.Hero(player.Opossite()).TakeDamage(2);
        }
    }
}
