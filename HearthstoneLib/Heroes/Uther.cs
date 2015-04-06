using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Minions;
using Hearthstone.Weapons;

namespace Hearthstone.Heroes
{
    public class Uther : Hero
    {
        public override PlayerClass Class
        {
            get { return PlayerClass.Paladin; }
        }

        public Uther(int id)
            : base(id, "Uther")
        {            
        }

        public override void CastHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            board.AddMinion(player, new PlainMinion(CardInfo.FromCardName("Silver Hand Recruit")));
        }
    }
}
