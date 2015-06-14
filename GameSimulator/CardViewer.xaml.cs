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
using Hearthstone;

namespace GameSimulator
{
    /// <summary>
    /// Interaction logic for CardViewer.xaml
    /// </summary>
    public partial class CardViewer : UserControl
    {
        public static readonly DependencyProperty CardProperty = DependencyProperty.Register("Card", typeof(Card), typeof(CardViewer),
                                                                                             new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCardChanged)));
                                                                                                                           

        public Card Card
        {
            get
            {
                return (Card)GetValue(CardProperty);
            }

            set
            {
                SetValue(CardProperty, value);
            }
        }
        
        public CardViewer()
        {
            InitializeComponent();
            Refresh();
        }

        private static void OnCardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardViewer).Refresh();
        }

        private void Refresh()
        {
            if (Card != null)
            {
                textBlockName.Text = Card.Info.Name;
                textBlockCost.Text = Card.CurrentCost.ToString();
                if (Card.Info.Image != null)
                {
                    imageCard.Source = Card.Info.Image;
                }

                TextBlock t = new TextBlock();
                t.Inlines.AddRange(ProcessToolTipText(Card.Info.Text));

                imageCard.ToolTip = t;
            }
            else
            {
                textBlockName.Text = "null";
            }
        }

        private Inline[] ProcessToolTipText(string text)
        {
            return new Inline[] { new Run(text) };
        }

        private void imageCard_MouseEnter(object sender, MouseEventArgs e)
        {
            //this.Width = 200;
        }

        private void imageCard_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
