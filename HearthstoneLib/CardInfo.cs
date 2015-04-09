using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media.Imaging;

namespace Hearthstone
{
    [DataContract]
    public class CardInfo
    {
        private static Dictionary<string, BitmapImage> CardImages;

        /// <summary>
        /// The card name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The mana cost of this card.
        /// </summary>
        [DataMember]
        public int Cost { get; set; }

        /// <summary>
        /// The card type.
        /// </summary>
        [DataMember]
        public CardType Type { get; set; }

        /// <summary>
        /// The rarity of the card.
        /// </summary>
        [DataMember]
        public CardRarity Rarity { get; set; }

        /// <summary>
        /// The faction of the card.
        /// </summary>
        [DataMember]
        public CardFaction Faction { get; set; }

        /// <summary>
        /// The race of the card.
        /// </summary>
        [DataMember]
        public MinionRace Race { get; set; }

        /// <summary>
        /// The player class this card belongs to.
        /// </summary>
        [DataMember]
        public PlayerClass PlayerClass { get; set; }

        /// <summary>
        /// The text of the card when it is in your hand. May contain HTML tags and other symbols which are present in the Hearthstones files as presented here.
        /// </summary>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// The mechanics of the card.
        /// </summary>
        [DataMember]
        public List<CardMechanics> Mechanics { get; set; }

        /// <summary>
        /// The text of the card when it is in play. May contain HTML tags and other symbols which are present in the Hearthstones files as presented here.
        /// </summary>
        [DataMember]
        public string InPlayText { get; set; }

        /// <summary>
        /// The flavor text of the card.
        /// </summary>
        [DataMember]
        public string FlavorText { get; set; }

        /// <summary>
        /// The artist of the card.
        /// </summary>
        [DataMember]
        public string Artist { get; set; }

        /// <summary>
        /// The attack of the card. Used for both Minions and Weapons.
        /// </summary>
        [DataMember]
        public int Attack { get; set; }

        /// <summary>
        /// The health of the card. Used for Minions.
        /// </summary>
        [DataMember]
        public int Health { get; set; }

        /// <summary>
        /// The durability of the card. Used for Weapons.
        /// </summary>
        [DataMember]
        public int Durability { get; set; }

        /// <summary>
        /// The Hearthstone ID of the card.
        /// </summary>
        [DataMember]
        public string HearthstoneID { get; set; }

        /// <summary>
        /// If this card can be acquired by the player, this is true. false otherwise.
        /// </summary>
        [DataMember]
        public bool IsCollectible { get; set; }

        /// <summary>
        /// Whether or not this card is elite.
        /// </summary>
        [DataMember]
        public bool IsElite { get; set; }

        /// <summary>
        /// How to get this card. Only present if it's gotten via a method other than opening a booster pack.
        /// </summary>
        [DataMember]
        public string HowToGet { get; set; }

        /// <summary>
        /// How to get the gold version of this card. Only present if it's gotten via a method other than opening a booster pack.
        /// </summary>
        [DataMember]
        public string HowToGetGold { get; set; }

        /// <summary>
        /// The set of the card.
        /// </summary>
        [DataMember]
        public CardSet Set { get; set; }

        /// <summary>
        /// The loaded the card image.
        /// </summary>        
        public BitmapImage Image { get; private set; }

        public static List<CardInfo> AllCards { get; private set; }

        public static List<CardInfo> PlayableCards
        {
            get
            {
                return new List<CardInfo>(AllCards.Where(c => (c.Type == CardType.Minion || c.Type == CardType.Spell || c.Type == CardType.Weapon)));
            }
        }

        public static CardInfo FromCardName(string name)
        {
            return PlayableCards.Find(c => c.Name == name);
        }

        public static void LoadImages()
        {
            CardImages = new Dictionary<string, BitmapImage>();

            foreach (string filePath in Directory.GetFiles(@"..\..\..\Database\Images\Done", "*.png"))
            {
                CardImages.Add(Path.GetFileNameWithoutExtension(filePath), new BitmapImage(new Uri(Path.GetFullPath(filePath))));
            }
        }

        private static BitmapImage FindImage(string id)
        {
            if (CardImages != null && CardImages.ContainsKey(id))
            {
                return CardImages[id];
            }
            else
            {
                return null;
            }
        }

        public static void LoadJsonDatabase(string path)
        {            
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(HSJsonDatabase));
            FileStream fs = new FileStream(path, FileMode.Open);
            HSJsonDatabase database = (HSJsonDatabase)ser.ReadObject(fs);
            fs.Close();

            AllCards = new List<CardInfo>(2000);

            
            LoadJsonSet(database.Basic, CardSet.Basic);
            LoadJsonSet(database.Naxxramas, CardSet.Naxxramas);
            LoadJsonSet(database.Classic, CardSet.Classic);
            LoadJsonSet(database.Promotion, CardSet.Promotion);
            LoadJsonSet(database.Reward, CardSet.Reward);
            LoadJsonSet(database.GoblinsVsGnomes, CardSet.GoblinsVsGnomes); 
            LoadJsonSet(database.BlackrockMountain, CardSet.BlackrockMountain); 
        }

        private static void LoadJsonSet(List<HSJsonDatabase.Card> setJsonCards, CardSet set)
        {
            foreach (HSJsonDatabase.Card jsonCard in setJsonCards)
            {
                AllCards.Add(new CardInfo
                {
                    Name = jsonCard.name,
                    Cost = jsonCard.cost,
                    Type = ParseJsonCardType(jsonCard.type),
                    Rarity = ParseJsonCardRarity(jsonCard.rarity),
                    Faction = ParseJsonCardFaction(jsonCard.faction),
                    Race = ParseJsonCardRace(jsonCard.race),
                    PlayerClass = ParseJsonCardPlayerClass(jsonCard.playerClass),
                    Text = jsonCard.text,
                    InPlayText = jsonCard.inPlayText,
                    Mechanics = ParseJsonCardMechanicsArray(jsonCard.mechanics),
                    FlavorText = jsonCard.flavor,
                    Artist = jsonCard.artist,
                    Attack = jsonCard.attack,
                    Health = jsonCard.health,
                    Durability = jsonCard.durability,
                    HearthstoneID = jsonCard.id,
                    IsCollectible = jsonCard.collectible,
                    IsElite = jsonCard.elite,
                    HowToGet = jsonCard.howToGet,
                    HowToGetGold = jsonCard.howToGetGold,
                    Set = set,
                    Image = FindImage(jsonCard.id)
                });
            }
        }

        private static CardType ParseJsonCardType(string text)
        {
            Dictionary<string, CardType> types = new Dictionary<string, CardType>() { { "Minion", CardType.Minion },
                                                                                      { "Spell", CardType.Spell }, 
                                                                                      { "Weapon", CardType.Weapon },
                                                                                      { "Hero", CardType.Hero },
                                                                                      { "Hero Power", CardType.HeroPower },
                                                                                      { "Enchantment", CardType.Enchantment } };

            return types[text];
        }

        private static CardRarity ParseJsonCardRarity(string text)
        {
            Dictionary<string, CardRarity> rarities = new Dictionary<string, CardRarity>() { { "Free", CardRarity.Free },
                                                                                             { "Common", CardRarity.Common }, 
                                                                                             { "Rare", CardRarity.Rare },
                                                                                             { "Epic", CardRarity.Epic },
                                                                                             { "Legendary", CardRarity.Legendary }};

            return (text != null) ? rarities[text] : CardRarity.Free;
        }

        private static CardFaction ParseJsonCardFaction(string text)
        {
            Dictionary<string, CardFaction> factions = new Dictionary<string, CardFaction>() { { "Alliance", CardFaction.Alliance },
                                                                                               { "Horde", CardFaction.Horde }, 
                                                                                               { "Neutral", CardFaction.Neutral } };
            return (text != null) ? factions[text] : CardFaction.Neutral;
        }

        private static MinionRace ParseJsonCardRace(string text)
        {
            Dictionary<string, MinionRace> races = new Dictionary<string, MinionRace>() { { "Murloc", MinionRace.Murloc },
                                                                                               { "Demon", MinionRace.Demon }, 
                                                                                               { "Beast", MinionRace.Beast },
                                                                                               { "Totem", MinionRace.Totem },
                                                                                               { "Pirate", MinionRace.Pirate },
                                                                                               { "Dragon", MinionRace.Dragon },
                                                                                               { "Mech", MinionRace.Mech },
                                                                                               { "None", MinionRace.None },};
            return (text != null) ? races[text] : MinionRace.None;
        }

        private static PlayerClass ParseJsonCardPlayerClass(string text)
        {
            Dictionary<string, PlayerClass> classes = new Dictionary<string, PlayerClass>() { { "Druid", PlayerClass.Druid },
                                                                                               { "Hunter", PlayerClass.Hunter }, 
                                                                                               { "Mage", PlayerClass.Mage },
                                                                                               { "Paladin", PlayerClass.Paladin },
                                                                                               { "Priest", PlayerClass.Priest },
                                                                                               { "Rogue", PlayerClass.Rogue },
                                                                                               { "Shaman", PlayerClass.Shaman },
                                                                                               { "Warrior", PlayerClass.Warrior },
                                                                                               { "Warlock", PlayerClass.Warlock },
                                                                                               { "Dream", PlayerClass.Dream },
                                                                                               { "None", PlayerClass.None }};
            return (text != null) ? classes[text] : PlayerClass.None;
        }

        private static CardMechanics ParseJsonCardMechanics(string text)
        {
            Dictionary<string, CardMechanics> mechanics = new Dictionary<string, CardMechanics>() { { "Battlecry", CardMechanics.Battlecry },
                                                                                               { "Charge", CardMechanics.Charge }, 
                                                                                               { "Combo", CardMechanics.Combo },
                                                                                               { "Deathrattle", CardMechanics.Deathrattle },
                                                                                               { "Divine Shield", CardMechanics.DivineShield },
                                                                                               { "Stealth", CardMechanics.Stealth },
                                                                                               { "None", CardMechanics.None },
                                                                                               { "Passive", CardMechanics.Passive },
                                                                                               { "Secret", CardMechanics.Secret },
                                                                                               { "Taunt", CardMechanics.Taunt },
                                                                                               { "Windfury", CardMechanics.Windfury },
                                                                                               { "ImmuneToSpellpower", CardMechanics.ImmuneToSpellPower },
                                                                                               { "Overload", CardMechanics.Overload },
                                                                                               { "Spellpower", CardMechanics.SpellPower },
                                                                                               { "OneTurnEffect", CardMechanics.OneTurnEffect },
                                                                                               { "GrantCharge", CardMechanics.GrantCharge },
                                                                                               { "Freeze", CardMechanics.Freeze },
                                                                                               { "Morph", CardMechanics.Morph },
            { "AdjacentBuff", CardMechanics.AdjacentBuff }, 
            { "Aura", CardMechanics.Aura },
            { "HealTarget", CardMechanics.HealTarget },
            { "Poisonous", CardMechanics.Poisonous }, 
            { "Enrage", CardMechanics.Enrage },
            { "AffectedBySpellPower", CardMechanics.AffectedBySpellPower },
            { "Silence", CardMechanics.Silence },
            { "Summoned", CardMechanics.Summoned },};
            return (text != null) ? mechanics[text] : CardMechanics.None;
        }

        private static List<CardMechanics> ParseJsonCardMechanicsArray(List<string> textArray)
        {
            if (textArray != null)
            {
                List<CardMechanics> mechs = new List<CardMechanics>(textArray.Count);
                foreach (string text in textArray)
                {
                    mechs.Add(ParseJsonCardMechanics(text));
                }
                return mechs;
            }
            else
            {
                return new List<CardMechanics>();
            }
        }

        public bool HasMechanics(CardMechanics mechanics)
        {
            return Mechanics.Contains(mechanics);
        }
    }
}
