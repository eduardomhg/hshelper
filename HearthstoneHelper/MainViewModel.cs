using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone;
using Microsoft.Practices.Prism.Mvvm;

namespace HearthstoneHelper
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<CardInfo> _cards;
        public ObservableCollection<CardInfo> Cards
        {
            get { return _cards; }
            set { SetProperty(ref _cards, value); }
        }

        private string _nameFilterText;
        public string NameFilterText
        {
            get { return _nameFilterText; }
            set { SetProperty(ref _nameFilterText, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _nameFilter;

        private bool _filterCost1Enabled;
        public bool FilterCost1Enabled
        {
            get { return _filterCost1Enabled; }
            set { SetProperty(ref _filterCost1Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost1 = (c => c.Cost == 1);

        private bool _filterCost2Enabled;
        public bool FilterCost2Enabled
        {
            get { return _filterCost2Enabled; }
            set { SetProperty(ref _filterCost2Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost2 = (c => c.Cost == 2);

        private bool _filterCost3Enabled;
        public bool FilterCost3Enabled
        {
            get { return _filterCost3Enabled; }
            set { SetProperty(ref _filterCost3Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost3 = (c => c.Cost == 3);

        private bool _filterCost4Enabled;
        public bool FilterCost4Enabled
        {
            get { return _filterCost4Enabled; }
            set { SetProperty(ref _filterCost4Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost4 = (c => c.Cost == 4);

        private bool _filterCost5Enabled;
        public bool FilterCost5Enabled
        {
            get { return _filterCost5Enabled; }
            set { SetProperty(ref _filterCost5Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost5 = (c => c.Cost == 5);

        private bool _filterCost6Enabled;
        public bool FilterCost6Enabled
        {
            get { return _filterCost6Enabled; }
            set { SetProperty(ref _filterCost6Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost6 = (c => c.Cost == 6);

        private bool _filterCost7PlusEnabled;
        public bool FilterCost7PlusEnabled
        {
            get { return _filterCost7PlusEnabled; }
            set { SetProperty(ref _filterCost7PlusEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost7Plus = (c => c.Cost >= 7);

        private bool _filterRarityFreeEnabled;
        public bool FilterRarityFreeEnabled
        {
            get { return _filterRarityFreeEnabled; }
            set { SetProperty(ref _filterRarityFreeEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRarityFree = (c => c.Rarity == CardRarity.Free);

        private bool _filterRarityCommonEnabled;
        public bool FilterRarityCommonEnabled
        {
            get { return _filterRarityCommonEnabled; }
            set { SetProperty(ref _filterRarityCommonEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRarityCommon = (c => c.Rarity == CardRarity.Common);

        private bool _filterRarityRareEnabled;
        public bool FilterRarityRareEnabled
        {
            get { return _filterRarityRareEnabled; }
            set { SetProperty(ref _filterRarityRareEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRarityRare = (c => c.Rarity == CardRarity.Rare);

        private bool _filterRarityEpicEnabled;
        public bool FilterRarityEpicEnabled
        {
            get { return _filterRarityEpicEnabled; }
            set { SetProperty(ref _filterRarityEpicEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRarityEpic = (c => c.Rarity == CardRarity.Epic);

        private bool _filterRarityLegendaryEnabled;
        public bool FilterRarityLegendaryEnabled
        {
            get { return _filterRarityLegendaryEnabled; }
            set { SetProperty(ref _filterRarityLegendaryEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRarityLegendary = (c => c.Rarity == CardRarity.Legendary);

        private List<List<Func<CardInfo, bool>>> _filters;

        public MainViewModel()
        {
            CardInfo.LoadImages();
            CardInfo.LoadJsonDatabase("AllSets.enUS.json");
            

            _nameFilter = (c => _nameFilterText == "" || c.Name.ToLower().Contains(_nameFilterText.ToLower()));
            _nameFilterText = "";

            _filterCost1Enabled = true;
            _filterCost2Enabled = true;
            _filterCost3Enabled = true;
            _filterCost4Enabled = true;
            _filterCost5Enabled = true;
            _filterCost6Enabled = true;
            _filterCost7PlusEnabled = true;

            _filterRarityFreeEnabled = true;
            _filterRarityCommonEnabled = true;
            _filterRarityRareEnabled = true;
            _filterRarityEpicEnabled = true;
            _filterRarityLegendaryEnabled = true;

            UpdateFilters();
        }

        public void FilterCards(Func<CardInfo, bool> filterPredicate)
        {
            Cards = new ObservableCollection<CardInfo>(CardInfo.AllCards.Where(filterPredicate));
        }

        private void UpdateFilters()
        {
            _filters = new List<List<Func<CardInfo, bool>>>();

            List<Func<CardInfo, bool>> nameFilters = new List<Func<CardInfo, bool>>();
            nameFilters.Add(_nameFilter);
            _filters.Add(nameFilters);

            List<Func<CardInfo, bool>> costFilters = new List<Func<CardInfo, bool>>();
            if (_filterCost1Enabled) costFilters.Add(_filterCost1);
            if (_filterCost2Enabled) costFilters.Add(_filterCost2);
            if (_filterCost3Enabled) costFilters.Add(_filterCost3);
            if (_filterCost4Enabled) costFilters.Add(_filterCost4);
            if (_filterCost5Enabled) costFilters.Add(_filterCost5);
            if (_filterCost6Enabled) costFilters.Add(_filterCost6);
            if (_filterCost7PlusEnabled) costFilters.Add(_filterCost7Plus);
            _filters.Add(costFilters);

            List<Func<CardInfo, bool>> rarityFilters = new List<Func<CardInfo, bool>>();
            if (_filterRarityFreeEnabled) rarityFilters.Add(_filterRarityFree);
            if (_filterRarityCommonEnabled) rarityFilters.Add(_filterRarityCommon);
            if (_filterRarityRareEnabled) rarityFilters.Add(_filterRarityRare);
            if (_filterRarityEpicEnabled) rarityFilters.Add(_filterRarityEpic);
            if (_filterRarityLegendaryEnabled) rarityFilters.Add(_filterRarityLegendary);
            _filters.Add(rarityFilters);

            FilterCards(ApplyFilters);
        }

        private bool ApplyFilters(CardInfo card)
        {
            bool matches = true;
            bool matchesCategory = false;

            foreach (List<Func<CardInfo, bool>> filterCategory in _filters)
            {
                matchesCategory = false;
                // AND between filters
                foreach (Func<CardInfo, bool> filter in filterCategory)
                {
                    // OR between filters
                    if (filter(card))
                    {
                        matchesCategory = true;
                        break;
                    }
                }
                if (!matchesCategory)
                {
                    matches = false;
                    break;
                }
            }

            return matches;
        }
    }
}
