
using Microsoft.Practices.Prism.Mvvm;
namespace Hearthstone
{
    public class Card : BindableBase
    {
        private static int _currentFreeID = 0;

        public int ID { get; private set; }

        public CardInfo Info { get; private set; }

        public int CurrentCost { get; set; }

        public Card(CardInfo info) : this(info, info.Cost)
        {
        }

        public Card(CardInfo info, int currentCost)
        {
            ID = GenerateFreeID();
            Info = info;
            CurrentCost = currentCost;
        }

        public static Card TheCoin
        {
            get
            {
                return new Card(CardInfo.FromCardName("The Coin"));
            }
        }

        private static int GenerateFreeID()
        {
            int id = _currentFreeID;
            _currentFreeID++;
            return id;
        }

        public override string ToString()
        {
            return Info.Name;
        }
    }
}
