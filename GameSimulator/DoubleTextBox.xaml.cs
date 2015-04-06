using System;
using System.Collections.Generic;
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

namespace GameSimulator
{
    /// <summary>
    /// Interaction logic for DoubleTextBox.xaml
    /// </summary>
    public partial class DoubleTextBox : UserControl
    {
        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }

        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }

        public static readonly DependencyProperty Text1Property =
            DependencyProperty.Register("Text1", typeof(string),
              typeof(DoubleTextBox), new PropertyMetadata(""));

        public static readonly DependencyProperty Text2Property =
            DependencyProperty.Register("Text2", typeof(string),
              typeof(DoubleTextBox), new PropertyMetadata(""));

        public DoubleTextBox()
        {
            InitializeComponent();
        }
    }
}
