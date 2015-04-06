using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Heroes
{
    public class Garrosh : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Warrior; }
        }

        public Garrosh(int id)
            : base(id, "Garrosh")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            Armor = Armor + 2;
        }
    }
}
