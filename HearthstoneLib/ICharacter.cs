using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface ICharacter
    {
        int ID { get; }
        string Name { get; }

        int Attack { get; set; }
        int Health { get; set; }
        int MaximumHealth { get; set; }
        int TimesAttackedThisTurn { get; set; }
        bool SummonedThisTurn { get; }

        bool IsFrozen { get; }

        bool IsDead { get; }

        void TakeDamage(int damagePoints);
        void TakeDamage(ICharacter character);
        void TakeDamage(IWeapon hero);

        void Heal(int healthPoints);

        void ProcessTurnStart();
    }
}
