using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Weapons;

namespace Hearthstone.Heroes
{
    public class Guldan : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Warlock; }
        }

        public Guldan(int id)
            : base(id, "Guldan")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            TakeDamage(2);
            board.DrawCard(player);
        }
    }
}
