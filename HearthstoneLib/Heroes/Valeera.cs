using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Weapons;

namespace Hearthstone.Heroes
{
    public class Valeera : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Rogue; }
        }

        public Valeera(int id)
            : base(id, "Valeera")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            board.SetWeapon(player, new PlainWeapon(1, 1));
        }
    }
}
