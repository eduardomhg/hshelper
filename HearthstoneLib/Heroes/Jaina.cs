using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Heroes
{
    public class Jaina : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Mage; }
        }

        public Jaina(int id) : base(id, "Jaina")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            target.TakeDamage(1);
        }
    }
}
