using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Enchantments
{
    public class AncestralInfusion : MinionEnchantment
    {
        public AncestralInfusion(int id) :
            base(id, "Ancestral Infusion")
        {
        }

        public override void Apply(IMinion minion)
        {
            minion.HasTaunt = true;
        }
    }
}
