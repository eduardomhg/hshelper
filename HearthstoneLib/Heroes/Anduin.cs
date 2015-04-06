using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Weapons;

namespace Hearthstone.Heroes
{
    public class Anduin : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Priest; }
        }

        public Anduin(int id)
            : base(id, "Anduin")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            target.Heal(2);
        }
    }
}
