using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface IHero : ICharacter
    {
        PlayerClass Class { get; }
        int Armor { get; set;  }
        int Mana { get; set; }
        int MaximumMana { get; set; }

        int HeroPowerCost { get; }

        bool IsImmune { get; set; }
        int SpellPower { get; set; }

        void TakeFatigueDamage();
        void UseHeroPower(PlayerTurn player, Board board, ICharacter target);
    }
}
