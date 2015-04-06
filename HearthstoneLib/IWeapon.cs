using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface IWeapon
    {
        int ID { get; }
        int Attack { get; }
        int Durability { get; }
        bool HasOverload { get; }
    }
}
