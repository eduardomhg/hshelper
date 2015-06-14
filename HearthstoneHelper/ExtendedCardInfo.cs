using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Hearthstone;

namespace HearthstoneHelper
{
    [DataContract]
    public class ExtendedCardInfo : CardInfo
    {
        [DataMember]
        public int NumberOfCards { get; set; }

        [DataMember]
        public int NumberOfGoldCards { get; set; }

        public int NumberOfTotalCards
        {
            get
            {
                return NumberOfCards + NumberOfGoldCards;
            }
        }

        public static List<ExtendedCardInfo> AllCardsExtended { get; private set; }

        public ExtendedCardInfo(CardInfo info)
        {
            Name = info.Name;
            Cost = info.Cost;
            Type = info.Type;
            Rarity = info.Rarity;
            Faction = info.Faction;
            Race = info.Race;
            PlayerClass = info.PlayerClass;
            Text = info.Text;
            InPlayText = info.InPlayText;
            Mechanics = info.Mechanics;
            FlavorText = info.FlavorText;
            Artist = info.Artist;
            Attack = info.Attack;
            Health = info.Health;
            Durability = info.Durability;
            HearthstoneID = info.HearthstoneID;
            IsCollectible = info.IsCollectible;
            IsElite = info.IsElite;
            HowToGet = info.HowToGet;
            HowToGetGold = info.HowToGetGold;
            Set = info.Set;
            Image = info.Image;

            NumberOfCards = 0;
            NumberOfGoldCards = 0;
        }

        public static void CreateXmlDatabaseFromJsonDatabase(string path)
        {            
            AllCardsExtended = new List<ExtendedCardInfo>(2000);

            foreach (CardInfo info in AllCards)
            {
                AllCardsExtended.Add(new ExtendedCardInfo(info));
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(List<ExtendedCardInfo>));
            FileStream fs = new FileStream(path, FileMode.Create);

            serializer.WriteObject(fs, AllCardsExtended);

            fs.Close();
        }

        public static void SaveXmlDatabase(string path)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<ExtendedCardInfo>));
            FileStream fs = new FileStream(path, FileMode.Create);

            serializer.WriteObject(fs, AllCardsExtended);

            fs.Close();
        }

        public static bool LoadXmlDatabase(string path)
        {
            if (File.Exists(path))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<ExtendedCardInfo>));
                FileStream fs = new FileStream(path, FileMode.Open);

                AllCardsExtended = (List<ExtendedCardInfo>)serializer.ReadObject(fs);


                foreach (ExtendedCardInfo info in AllCardsExtended)
                {
                    info.Image = FindImage(info.HearthstoneID);
                }

                fs.Close();

                return true;
            }
            return false;
        }
    }
}
