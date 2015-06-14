using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface IEnchantment
    {
        string Name { get; }
        void Apply(ICharacter character);
    }
}
