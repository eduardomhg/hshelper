using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone.Enchantments
{
    public class AlexstrazsasFire : HeroEnchantment
    {
        public AlexstrazsasFire(int id) :
            base(id, "Alexstrazsa's Fire")
        {
        }

        public override void Apply(IHero hero)
        {
            hero.MaximumHealth = 15;
        }
    }
}
