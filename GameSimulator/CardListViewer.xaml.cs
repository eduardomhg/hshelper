using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hearthstone;

namespace GameSimulator
{
    /// <summary>
    /// Interaction logic for CardListViewer.xaml
    /// </summary>
    public partial class CardListViewer : UserControl
    {
        public ObservableCollection<Card> Cards
        {
            get { return (ObservableCollection<Card>)GetValue(WorkItemsProperty); }
            set { SetValue(WorkItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cards.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkItemsProperty =
            DependencyProperty.Register("Cards", typeof(ObservableCollection<Card>), typeof(CardListViewer), new FrameworkPropertyMetadata(null, OnWorkItemsChanged));

        private static void OnWorkItemsChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CardListViewer me = sender as CardListViewer;

            var old = e.OldValue as ObservableCollection<Card>;

            if (old != null)
                old.CollectionChanged -= me.OnWorkCollectionChanged;

            var n = e.NewValue as ObservableCollection<Card>;

            if (n != null)
                n.CollectionChanged += me.OnWorkCollectionChanged;
        }


        private void OnWorkCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                // Clear and update entire collection
                ClearCards();
            }

            if (e.NewItems != null)
            {
                foreach (Card item in e.NewItems)
                {
                    // Subscribe for changes on item
                    item.PropertyChanged += OnWorkItemChanged;

                    // Add item to internal collection
                    AddNewCard(item);
                }
            }

            if (e.OldItems != null)
            {
                foreach (Card item in e.OldItems)
                {
                    // Unsubscribe for changes on item
                    item.PropertyChanged -= OnWorkItemChanged;

                    // Remove item from internal collection
                    RemoveCard(item);
                }
            }
        }

        private void OnWorkItemChanged(object sender, PropertyChangedEventArgs e)
        {
            // Modify existing item in internal collection
        }

        private CardViewer[] _cardViewers;

        public CardListViewer()
        {
            InitializeComponent();

            _cardViewers = new CardViewer[] { cardViewer0, cardViewer1, cardViewer2, cardViewer3, cardViewer4,
                                              cardViewer5, cardViewer6, cardViewer7, cardViewer8, cardViewer9 };
        }

        private void AddNewCard(Card c)
        {
            for (int i = 0; i < _cardViewers.Length; i++)
            {
                if (_cardViewers[i].Visibility == Visibility.Hidden)
                {
                    _cardViewers[i].Card = c;
                    _cardViewers[i].Visibility = Visibility.Visible;
                    break;
                }
            }
        }

        private void RemoveCard(Card c)
        {
            for (int i = 0; i < _cardViewers.Length; i++)
            {
                if (_cardViewers[i].Card == c)
                {
                    _cardViewers[i].Visibility = Visibility.Hidden;
                    _cardViewers[i].Card = null;
                }
                if (i > 0 && _cardViewers[i - 1].Visibility == Visibility.Hidden)
                {
                    if (_cardViewers[i].Visibility == Visibility.Hidden)
                    {
                        _cardViewers[i - 1].Card = _cardViewers[i].Card;
                        _cardViewers[i - 1].Visibility = Visibility.Visible;
                        _cardViewers[i].Card = null;
                        _cardViewers[i].Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void ClearCards()
        {
            foreach (CardViewer viewer in _cardViewers)
            {
                viewer.Visibility = Visibility.Hidden;
                viewer.Card = null;
            }
        }
    }
}
