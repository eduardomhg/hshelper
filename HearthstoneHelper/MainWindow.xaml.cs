using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hearthstone;

namespace HearthstoneHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            string path = @"C:\Users\Edu\Downloads\AllSets.json";
            CardInfo.LoadJsonDatabase(path);
            Items = new ObservableCollection<CardInfo>(CardInfo.AllCards);
        }


        private ObservableCollection<CardInfo> _filteredCards;

        public ObservableCollection<CardInfo> Items
        {
            get { return _filteredCards; }

            set 
            { 
                _filteredCards = value; 
                if (PropertyChanged != null) 
                { 
                    PropertyChanged(this, new PropertyChangedEventArgs("Items")); 
                } 
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Items = new ObservableCollection<CardInfo>(CardInfo.AllCards);

            if ((sender as CheckBox).IsChecked == true)
            {
                Items = new ObservableCollection<CardInfo>(_filteredCards.Where(c => c.Type == CardType.Enchantment));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Items = new ObservableCollection<CardInfo>(CardInfo.AllCards.Where(c => c.Name.StartsWith((sender as TextBox).Text, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
