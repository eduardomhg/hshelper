using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone.Heroes;

namespace Hearthstone
{
    public abstract class Hero : IHero
    {
        private static readonly Dictionary<PlayerClass, Type> DefaultHeroes = new Dictionary<PlayerClass,Type> 
        { 
            { PlayerClass.Mage, typeof(Jaina) } 
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

        private int _armor;
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }

        private bool _isImmune;
        public bool IsImmune
        {
            get { return _isImmune; }
            set { _isImmune = value; }
        }

        public bool IsDead { get { return _health <= 0; } }

        public void TakeDamage(int damage)
        {
            _health = Math.Max(_health - damage, 0);
        }

        public void TakeDamage(ICharacter character)
        {
            TakeDamage(character.Attack);
        }
        public void TakeDamage(IWeapon weapon)
        {
            TakeDamage(weapon.Attack);
        }

        private int _lastFatigueDamage;

        public void TakeFatigueDamage()
        {
            _lastFatigueDamage++;
            TakeDamage(_lastFatigueDamage);
        }

        protected Hero(int id, CardInfo card)
        {
            Debug.Assert(card.Type == CardType.Hero);

            _id = id;
            _attack = 0;
            _health = Limits.MaximumHeroHealth;
            _maximumHealth = Limits.MaximumHeroHealth;
            _armor = 0;
            _lastFatigueDamage = 0;
            _isImmune = false;
            _mana = 0;
            _spellPower = 0;
            _name = card.Name;
        }

        protected Hero(int id, string name)
        {
            _id = id;
            _attack = 0;
            _health = Limits.MaximumHeroHealth;
            _armor = 0;
            _isImmune = false;
            _mana = 0;
            _spellPower = 0;
            _name = name;
        }

        public static Hero Create(int id, PlayerClass playerClass)
        {
            return (Hero)DefaultHeroes[playerClass].GetConstructor(new Type[]{ typeof(int)}).Invoke(new object[] { id });
        }

        public abstract PlayerClass Class
        {
            get;
        }


        private int _mana;

        public int Mana
        {
            get
            {
                return _mana;
            }
            set
            {
                _mana = value;
            }
        }

        private int _maximumMana;

        public int MaximumMana
        {
            get
            {
                return _maximumMana;
            }
            set
            {
                _maximumMana = value;
            }
        }

        public int HeroPowerCost
        {
            get { return 2; }
        }

        public int _spellPower;

        public int SpellPower
        {
            get { return _spellPower; }
            set { _spellPower = value; }
        }

        public void UseHeroPower(PlayerTurn player, Board board, ICharacter target)
        {
            Mana = Mana - HeroPowerCost;
            Debug.Assert(Mana >= 0);
            CastHeroPower(player, board, target);
        }

        public abstract void CastHeroPower(PlayerTurn player, Board board, ICharacter target);
        
        public void Heal(int healthPoints)
        {
            _health = Math.Min(_health + healthPoints, _maximumHealth);
        }

        public int _maximumHealth;
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


        public int TimesAttackedThisTurn
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }


        public void ProcessTurnStart()
        {
            TimesAttackedThisTurn = 0;
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


        public bool SummonedThisTurn
        {
            get
            {
                return false;
            }
        }

        public bool IsFrozen
        {
            get { return false; }
        }
    }
}

