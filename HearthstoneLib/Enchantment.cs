using System;
using System.Collections.Generic;
using Hearthstone.Spells;

namespace Hearthstone
{
    public abstract class Enchantment : IEnchantment
    {
        private static readonly Dictionary<string, Type> CardToEnchantmentMapping = new Dictionary<string, Type> 
        { 
            
        };

        public static IEnchantment FromCard(Card card)
        {
            return (IEnchantment)CardToEnchantmentMapping[card.Info.Name].GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

        protected Enchantment(int id, string cardName)
        {
            _card = CardInfo.FromCardName(cardName);
        }

        private CardInfo _card;

        public string Name
        {
            get
            {
                return _card.Name;
            }
        }

        public string Text
        {
            get
            {
                return _card.Text;
            }
        }

        public abstract void Apply(ICharacter character);
    }
}
