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
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();
            this.DataContext = viewModel;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                viewModel.FilterCards(c => c.Type == CardType.Enchantment);
            }
            else
            {
                viewModel.FilterCards(c => true);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FilterCards(c => c.Name.StartsWith((sender as TextBox).Text, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
