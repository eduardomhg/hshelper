using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone;
using Microsoft.Practices.Prism.Mvvm;

namespace GameSimulator
{
    public class MainViewModel : BindableBase
    {
        private string _hola;
        public string Hola
        {
            get { return _hola; }
            set { SetProperty(ref _hola, value); }
        }

        private Card _card;
        public Card Card
        {
            get { return _card; }
            set { SetProperty(ref _card, value); }
        }

        public MainViewModel()
        {
            CardInfo.LoadImages();
            CardInfo.LoadJsonDatabase("AllSets.enUS.json");

            Card = new Card(CardInfo.FromCardName("Frostbolt"));
            Hola = "jajaja";
        }
    }
}
