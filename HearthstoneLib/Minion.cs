using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Minions;
using Hearthstone.Weapons;

namespace Hearthstone
{
    public class Minion : IMinion
    {
        private static readonly Dictionary<string, Type> CardToMinionsMapping = new Dictionary<string, Type> 
        { 
            { "Shattered Sun Cleric", typeof(ShateredSunCleric) },
            { "Novice Engineer", typeof(NoviceEngineer) }
        };

        private int _id;
        public int ID
        {
            get { return _id; }
        }

        private int _attack;
        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        private int _health;
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        private bool _hasStealth;
        public bool HasStealth
        {
            get { return _hasStealth; }
            set { _hasStealth = value; }
        }

        private bool _hasTaunt;
        public bool HasTaunt
        {
            get { return _hasTaunt; }
            set { _hasTaunt = value; }
        }

        private bool _hasDivineShield;
        public bool HasDivineShield
        {
            get { return _hasDivineShield; }
            set { _hasDivineShield = value; }
        }

        private bool _hasCharge;
        public bool HasCharge
        {
            get { return _hasCharge; }
            set { _hasCharge = value; }
        }

        private bool _hasPoison;
        public bool HasPoison
        {
            get { return _hasPoison; }
        }

        private bool _hasAura;
        public bool HasAura
        {
            get { return _hasAura; }
        }

        public bool IsDead { get { return _health <= 0; } }

        public virtual void Battlecry(Board board, ICharacter target)
        {            
        }

        public virtual void Deathrattle(Board board)
        {
        }

        public virtual void Aura(Board board)
        {
        }

        public void TakeDamage(ICharacter character)
        {
            TakeDamage(character.Attack);
        }

        public void TakeDamage(IWeapon weapon)
        {
            TakeDamage(weapon.Attack);
        }

        protected Minion(int id, CardInfo card)
        {
            Debug.Assert(card.Type == CardType.Minion);

            _id = id;
            _name = card.Name;
            _attack = card.Attack;
            _health = card.Health;
            _maximumHealth = card.Health;
            _hasStealth = card.HasMechanics(CardMechanics.Stealth);
            _hasTaunt = card.HasMechanics(CardMechanics.Taunt);
            _hasAura = card.HasMechanics(CardMechanics.Aura);
            _hasCharge = card.HasMechanics(CardMechanics.Charge);
            _hasPoison = card.HasMechanics(CardMechanics.Poisonous);
            _hasDivineShield = card.HasMechanics(CardMechanics.DivineShield);
            _timesAttackedThisTurn = 0;
            _summonedThisTurn = true;
        }

        public static IMinion FromCard(Card card)
        {
            if (CardToMinionsMapping.ContainsKey(card.Info.Name))
            {
                return (IMinion)Activator.CreateInstance(CardToMinionsMapping[card.Info.Name], card.Info);
            }
            else
            {
                return new PlainMinion(card.Info);
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }

        public void Heal(int healthPoints)
        {
            _health = Math.Min(_health + healthPoints, _maximumHealth);
        }

        private int _maximumHealth;

        public int MaximumHealth
        {
            get
            {
                return _maximumHealth;
            }
            set
            {
                _maximumHealth = value;
            }
        }

        private int _timesAttackedThisTurn;

        public int TimesAttackedThisTurn
        {
            get
            {
                return _timesAttackedThisTurn;
            }
            set
            {
                _timesAttackedThisTurn = value;
            }
        }

        public void ProcessTurnStart()
        {
            _timesAttackedThisTurn = 0;
            _summonedThisTurn = false;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }

        private bool _summonedThisTurn;
        public bool SummonedThisTurn
        {
            get { return _summonedThisTurn; }
        }

        private bool _hasWindfury;
        public bool HasWindfury
        {
            get { return _hasWindfury; }
            set { _hasWindfury = value; }
        }


        public bool IsFrozen
        {
            get { return false; }
        }
    }
}
