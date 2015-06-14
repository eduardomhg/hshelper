using System;
using System.Collections.Generic;
using System.Diagnostics;
using Hearthstone.Spells;

namespace Hearthstone
{
    public abstract class HeroEnchantment : Enchantment
    {
        protected HeroEnchantment(int id, string cardName)
            : base(id, cardName)
        {
        }

        public override void Apply(ICharacter character)
        {
            Debug.Assert(character is IHero);
            Apply(character as IHero);
        }

        public abstract void Apply(IHero hero);
    }
}
