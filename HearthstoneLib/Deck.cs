
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;

namespace Hearthstone
{
    public class Deck : IEnumerable<CardInfo>, IList<CardInfo>
    {
        private List<CardInfo> _cards;

        public List<CardInfo> Cards
        {
            get
            {
                return _cards;
            }
        }

        public bool IsComplete
        {
            get
            {
                return (_cards.Count == Limits.CardsPerDeck);
            }
        }

        public Deck()
        {
            _cards = new List<CardInfo>();
        }

        public bool AddCard(CardInfo card)
        {
            int maximumCardInstances = card.Rarity == CardRarity.Legendary ? Limits.MaximumLegendaryCardCopiesPerDeck :
                                                                             Limits.MaximumOrdinaryCardCopiesPerDeck;
            bool added = false;

            if (_cards.Count < Limits.CardsPerDeck && CountOccurences(card) < maximumCardInstances)
            {
                _cards.Add(card);
                added = true;
            }

            return added;
        }

        public bool RemoveCard(CardInfo card)
        {
            return _cards.Remove(card);
        }

        private int CountOccurences(CardInfo card)
        {
            return _cards.Count(c => c.HearthstoneID == c.HearthstoneID);
        }

        public IEnumerator<CardInfo> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        public int IndexOf(CardInfo item)
        {
            return _cards.IndexOf(item);
        }

        public void Insert(int index, CardInfo item)
        {
            _cards.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _cards.RemoveAt(index);
        }

        public CardInfo this[int index]
        {
            get
            {
                return _cards[index];
            }
            set
            {
                _cards[index] = value;
            }
        }

        public void Add(CardInfo item)
        {
            _cards.Add(item);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public bool Contains(CardInfo item)
        {
            return _cards.Contains(item);
        }

        public void CopyTo(CardInfo[] array, int arrayIndex)
        {
            _cards.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _cards.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(CardInfo item)
        {
            return _cards.Remove(item);
        }
    }
}
