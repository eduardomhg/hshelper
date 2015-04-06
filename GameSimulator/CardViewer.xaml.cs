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
        private Card _card;

        public Card Card
        {
            get { return _card; }
            set { _card = value; Refresh(); }
        }
        
        public CardViewer()
        {
            InitializeComponent();
            //Refresh();
        }

        private void Refresh()
        {
            textBlockName.Text = _card.Info.Name;
            textBlockCost.Text = _card.CurrentCost.ToString();
            if (_card.Info.Image != null)
            {
                imageCard.Source = _card.Info.Image;
            }

            TextBlock t = new TextBlock();
            t.Inlines.AddRange(ProcessToolTipText(_card.Info.Text));

            imageCard.ToolTip = t;
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
