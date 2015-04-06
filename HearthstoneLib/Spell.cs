using System;
using System.Collections.Generic;
using Hearthstone.Spells;

namespace Hearthstone
{
    public abstract class Spell : ISpell
    {
        private static readonly Dictionary<string, Type> CardToSpellsMapping = new Dictionary<string, Type> 
        { 
            { "Flamestrike", typeof(Flamestrike) },
            { "The Coin", typeof(TheCoin) }
        };

        public static ISpell FromCard(Card card)
        {
            return (ISpell)CardToSpellsMapping[card.Info.Name].GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

        public abstract void Cast(PlayerTurn castingPlayer, ICharacter target, int spellPower, Board board);
    }
}
