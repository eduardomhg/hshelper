using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public abstract class Weapon : IWeapon
    {
        public int ID
        {
            get { throw new NotImplementedException(); }
        }

        public int Attack
        {
            get { throw new NotImplementedException(); }
        }

        public int Durability
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasOverload
        {
            get { throw new NotImplementedException(); }
        }

        public static IWeapon FromCard(Card card)
        {
            return null;
        }
    }
}
