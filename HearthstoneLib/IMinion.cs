using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface IMinion : ICharacter
    {
        bool HasStealth { get; }
        bool HasTaunt { get; }
        bool HasDivineShield { get; }
        bool HasCharge { get; }
        bool HasWindfury { get; }
        bool HasPoison { get; }
        bool HasAura { get; }

        void Battlecry(Board board, ICharacter target);
        void Deathrattle(Board board);
        void Aura(Board board);
    }
}
