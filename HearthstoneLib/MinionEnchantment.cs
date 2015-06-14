using System;
using System.Collections.Generic;
using System.Diagnostics;
using Hearthstone.Spells;

namespace Hearthstone
{
    public abstract class MinionEnchantment : Enchantment
    {
        protected MinionEnchantment(int id, string cardName) : base(id, cardName)
        {
        }

        public override void Apply(ICharacter character)
        {
            Debug.Assert(character is IMinion);
            Apply(character as IMinion);
        }

        public abstract void Apply(IMinion minion);
    }
}
