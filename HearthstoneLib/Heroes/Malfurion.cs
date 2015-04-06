using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Weapons;

namespace Hearthstone.Heroes
{
    public class Malfurion : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Druid; }
        }

        public Malfurion(int id)
            : base(id, "Malfurion")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            Armor = Armor + 1;
            Attack = Attack + 1;
        }
    }
}
