using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using Hearthstone.Players;

namespace GameSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //_model.Hola = "tururu";
            //_model.Adios = "tarara";

            cardViewer.Card = new Card(CardInfo.FromCardName("Frostbolt"));

            Deck player1Deck = new Deck { CardInfo.FromCardName("Chillwind Yeti"), CardInfo.FromCardName("Shattered Sun Cleric") };

            Deck player2Deck = new Deck { 
                CardInfo.FromCardName("Chillwind Yeti"), 
                CardInfo.FromCardName("Shattered Sun Cleric"), 
                CardInfo.FromCardName("Stonetusk Boar"),
                CardInfo.FromCardName("Stonetusk Boar"),
                CardInfo.FromCardName("Novice Engineer"),
                CardInfo.FromCardName("Novice Engineer"),
                CardInfo.FromCardName("Novice Engineer")
            };

            LazyPlayer player1 = new LazyPlayer(PlayerClass.Mage, player1Deck);
            DumbPlayer player2 = new DumbPlayer(PlayerClass.Mage, player2Deck);

            TextBoxTraceListener logListener = new TextBoxTraceListener(textBoxLog);

            GameRunner runner = new GameRunner(player1, player2, logListener);

            var h = new ObservableCollection<Card>();

            player1HandViewer.Cards = h;

            foreach (CardInfo ci in player2Deck)
            {
                h.Add(new Card(ci));
            }


            //runner.RunGame();
        }
    }
}
