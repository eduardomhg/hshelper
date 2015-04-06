using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hearthstone
{
    [DataContract]
    public class HSJsonDatabase
    {
        [DataContract]
        public class Card
        {
            /// <summary>
            /// The card name.
            /// </summary>
            [DataMember]
            public string name;

            /// <summary>
            /// The mana cost of this card.
            /// </summary>
            [DataMember]
            public int cost;

            /// <summary>
            /// The card type.
            /// </summary>
            [DataMember]
            public string type;

            /// <summary>
            /// The rarity of the card.
            /// </summary>
            [DataMember]
            public string rarity;

            /// <summary>
            /// The faction of the card.
            /// </summary>
            [DataMember]
            public string faction;

            /// <summary>
            /// The race of the card.
            /// </summary>
            [DataMember]
            public string race;

            /// <summary>
            /// The player class this card belongs to.
            /// </summary>
            [DataMember]
            public string playerClass;

            /// <summary>
            /// The text of the card when it is in your hand. May contain HTML tags and other symbols which are present in the Hearthstones files as presented here.
            /// </summary>
            [DataMember]
            public string text;

            /// <summary>
            /// The mechanics of the card.
            /// </summary>
            [DataMember]
            public List<string> mechanics;

            /// <summary>
            /// The text of the card when it is in play. May contain HTML tags and other symbols which are present in the Hearthstones files as presented here.
            /// </summary>
            [DataMember]
            public string inPlayText;

            /// <summary>
            /// The flavor text of the card.
            /// </summary>
            [DataMember]
            public string flavor;

            /// <summary>
            /// The artist of the card.
            /// </summary>
            [DataMember]
            public string artist;

            /// <summary>
            /// The attack of the card. Used for both Minions and Weapons.
            /// </summary>
            [DataMember]
            public int attack;

            /// <summary>
            /// The health of the card. Used for Minions.
            /// </summary>
            [DataMember]
            public int health;

            /// <summary>
            /// The durability of the card. Used for Weapons.
            /// </summary>
            [DataMember]
            public int durability;

            /// <summary>
            /// The Hearthstone ID of the card.
            /// </summary>
            [DataMember]
            public string id;

            /// <summary>
            /// If this card can be acquired by the player, this is true. false otherwise.
            /// </summary>
            [DataMember]
            public bool collectible;

            /// <summary>
            /// Whether or not this card is elite.
            /// </summary>
            [DataMember]
            public bool elite;

            /// <summary>
            /// How to get this card. Only present if it's gotten via a method other than opening a booster pack.
            /// </summary>
            [DataMember]
            public string howToGet;

            /// <summary>
            /// How to get the gold version of this card. Only present if it's gotten via a method other than opening a booster pack.
            /// </summary>
            [DataMember]
            public string howToGetGold;
        }

        [DataMember]
        internal List<Card> Basic;
        [DataMember]
        internal List<Card> Credits;
        [DataMember(Name = "Curse of Naxxramas")]
        internal List<Card> Naxxramas;
        [DataMember]
        internal List<Card> Debug;
        [DataMember]
        internal List<Card> Classic;
        [DataMember]
        internal List<Card> Missions;
        [DataMember]
        internal List<Card> Promotion;
        [DataMember]
        internal List<Card> Reward;
        [DataMember]
        internal List<Card> System;
        [DataMember(Name = "Goblins vs Gnomes")]
        internal List<Card> GoblinsVsGnomes;
        [DataMember(Name = "Blackrock Mountain")]
        internal List<Card> BlackrockMountain;
    }
}
