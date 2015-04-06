using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Hearthstone;

namespace HearthstoneHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const int TotalImages = 525;

        private int _currentIndex;
        private int _doneImages;
        private IEnumerable<CardInfo> _allCards;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            string path = @"C:\Users\Edu\Downloads\AllSets.json";
            CardInfo.LoadJsonDatabase(path);

            _allCards = CardInfo.AllCards.Where(c => c.Type != CardType.Enchantment);
            Items = new ObservableCollection<CardInfo>(_allCards);


            _doneImages = Directory.GetFiles(@"K:\HearthstoneHelper\ImageChooser\Done\").Length;
            labelCount.Content = _doneImages + "/" + TotalImages;
            _currentIndex = 1;
            GoToNextImage();
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
            Items = new ObservableCollection<CardInfo>(_allCards.Where(c => c.Name.StartsWith((sender as TextBox).Text, StringComparison.InvariantCultureIgnoreCase)));
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex++;
            GoToNextImage();
        }

        void GoToNextImage()
        {
            while (!File.Exists(GenerateSourcePath(_currentIndex)))
            {
                _currentIndex++;
            }
            labelFilename.Content = GenerateFileName(_currentIndex);
            cardImage.Source = new BitmapImage(new Uri(GenerateDisplayPath(_currentIndex)));
        }

        
        string GenerateFileName(int index)
        {
            return index + ".png";
        }

        string GenerateFileName(string id)
        {
            return id + ".png";
        }

        string GenerateDisplayPath(int index)
        {
            return @"K:\HearthstoneHelper\ImageChooser\Original\" + GenerateFileName(index);
        }

        string GenerateSourcePath(int index)
        {
            return @"K:\HearthstoneHelper\ImageChooser\NotDone\" + GenerateFileName(index);
        }

        string GenerateDestinationPath(string hearthstoneID)
        {
            return @"K:\HearthstoneHelper\ImageChooser\Done\" + GenerateFileName(hearthstoneID);
        }

        void ProcessImageFile(int index, string hearthstoneID)
        {
            _currentIndex++;
            GoToNextImage();

            File.Copy(GenerateSourcePath(index), GenerateDestinationPath(hearthstoneID));
            File.Delete(GenerateSourcePath(index));

            _doneImages++;
            labelCount.Content = _doneImages + "/" + TotalImages;

            textBoxFilter.Clear();
        }

        private void itemDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ProcessCurrentImage();
        }

        private void textBoxFilter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessCurrentImage();
            }
        }

        private void ProcessCurrentImage()
        {
            CardInfo sel = itemDataGrid.SelectedItem as CardInfo;
            if (sel == null)
            {
                if (itemDataGrid.Items.Count == 1)
                {
                    sel = itemDataGrid.Items[0] as CardInfo;
                }
            }

            if (sel != null)
            {
                ProcessImageFile(_currentIndex, sel.HearthstoneID);
            }
        }
    }
}
