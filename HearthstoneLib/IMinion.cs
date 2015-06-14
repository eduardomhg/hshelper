using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface IMinion : ICharacter
    {
        bool HasStealth { get; set; }
        bool HasTaunt { get; set; }
        bool HasDivineShield { get; set; }
        bool HasCharge { get; set; }
        bool HasWindfury { get; set; }
        bool HasPoison { get; }
        bool HasAura { get; }

        void Battlecry(Board board, ICharacter target);
        void Deathrattle(Board board);
        void Aura(Board board);
    }
}
