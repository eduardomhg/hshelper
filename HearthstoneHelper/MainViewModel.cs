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
            set { SetProperty(ref _cards, value); OnPropertyChanged("NumberOfCards"); OnPropertyChanged("NumberOfCardsWithImage"); }
        }

        public int TotalNumberOfCards
        {
            get { return CardInfo.AllCards.Count; }
        }

        public int NumberOfCards
        {
            get { return _cards.Count; }
        }

        public int NumberOfCardsWithImage
        {
            get { return _cards.Count(c => c.Image != null); }
        }

        private string _nameFilterText;
        public string NameFilterText
        {
            get { return _nameFilterText; }
            set { SetProperty(ref _nameFilterText, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _nameFilter;

        private string _textFilterText;
        public string TextFilterText
        {
            get { return _textFilterText; }
            set { SetProperty(ref _textFilterText, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _textFilter;


        private bool _filterCost0Enabled;
        public bool FilterCost0Enabled
        {
            get { return _filterCost0Enabled; }
            set { SetProperty(ref _filterCost0Enabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCost0 = (c => c.Cost == 0);

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

        private bool _filterSetBasicEnabled;
        public bool FilterSetBasicEnabled
        {
            get { return _filterSetBasicEnabled; }
            set { SetProperty(ref _filterSetBasicEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetBasic = (c => c.Set == CardSet.Basic);

        private bool _filterSetClassicEnabled;
        public bool FilterSetClassicEnabled
        {
            get { return _filterSetClassicEnabled; }
            set { SetProperty(ref _filterSetClassicEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetClassic = (c => c.Set == CardSet.Classic);

        private bool _filterSetNaxxramasEnabled;
        public bool FilterSetNaxxramasEnabled
        {
            get { return _filterSetNaxxramasEnabled; }
            set { SetProperty(ref _filterSetNaxxramasEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetNaxxramas = (c => c.Set == CardSet.Naxxramas);

        private bool _filterSetGoblinsVsGnomesEnabled;
        public bool FilterSetGoblinsVsGnomesEnabled
        {
            get { return _filterSetGoblinsVsGnomesEnabled; }
            set { SetProperty(ref _filterSetGoblinsVsGnomesEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetGoblinsVsGnomes = (c => c.Set == CardSet.GoblinsVsGnomes);

        private bool _filterSetBlackrockMountainEnabled;
        public bool FilterSetBlackrockMountainEnabled
        {
            get { return _filterSetBlackrockMountainEnabled; }
            set { SetProperty(ref _filterSetBlackrockMountainEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetBlackrockMountain = (c => c.Set == CardSet.BlackrockMountain);

        private bool _filterSetPromotionEnabled;
        public bool FilterSetPromotionEnabled
        {
            get { return _filterSetPromotionEnabled; }
            set { SetProperty(ref _filterSetPromotionEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetPromotion = (c => c.Set == CardSet.Promotion);

        private bool _filterSetRewardEnabled;
        public bool FilterSetRewardEnabled
        {
            get { return _filterSetRewardEnabled; }
            set { SetProperty(ref _filterSetRewardEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterSetReward = (c => c.Set == CardSet.Reward);

        private bool _filterTypeMinionEnabled;
        public bool FilterTypeMinionEnabled
        {
            get { return _filterTypeMinionEnabled; }
            set { SetProperty(ref _filterTypeMinionEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterTypeMinion = (c => c.Type == CardType.Minion);

        private bool _filterTypeSpellEnabled;
        public bool FilterTypeSpellEnabled
        {
            get { return _filterTypeSpellEnabled; }
            set { SetProperty(ref _filterTypeSpellEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterTypeSpell = (c => c.Type == CardType.Spell);

        private bool _filterTypeHeroPowerEnabled;
        public bool FilterTypeHeroPowerEnabled
        {
            get { return _filterTypeHeroPowerEnabled; }
            set { SetProperty(ref _filterTypeHeroPowerEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterTypeHeroPower = (c => c.Type == CardType.HeroPower);

        private bool _filterTypeHeroEnabled;
        public bool FilterTypeHeroEnabled
        {
            get { return _filterTypeHeroEnabled; }
            set { SetProperty(ref _filterTypeHeroEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterTypeHero = (c => c.Type == CardType.Hero);

        private bool _filterTypeWeaponEnabled;
        public bool FilterTypeWeaponEnabled
        {
            get { return _filterTypeWeaponEnabled; }
            set { SetProperty(ref _filterTypeWeaponEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterTypeWeapon = (c => c.Type == CardType.Weapon);

        private bool _filterTypeEnchantmentEnabled;
        public bool FilterTypeEnchantmentEnabled
        {
            get { return _filterTypeEnchantmentEnabled; }
            set { SetProperty(ref _filterTypeEnchantmentEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterTypeEnchantment = (c => c.Type == CardType.Enchantment);

        private bool _filterRaceNoneEnabled;
        public bool FilterRaceNoneEnabled
        {
            get { return _filterRaceNoneEnabled; }
            set { SetProperty(ref _filterRaceNoneEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceNone = (c => c.Race == MinionRace.None);

        private bool _filterRaceDemonEnabled;
        public bool FilterRaceDemonEnabled
        {
            get { return _filterRaceDemonEnabled; }
            set { SetProperty(ref _filterRaceDemonEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceDemon = (c => c.Race == MinionRace.Demon);


        private bool _filterRaceDragonEnabled;
        public bool FilterRaceDragonEnabled
        {
            get { return _filterRaceDragonEnabled; }
            set { SetProperty(ref _filterRaceDragonEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceDragon = (c => c.Race == MinionRace.Dragon);


        private bool _filterRacePirateEnabled;
        public bool FilterRacePirateEnabled
        {
            get { return _filterRacePirateEnabled; }
            set { SetProperty(ref _filterRacePirateEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRacePirate = (c => c.Race == MinionRace.Pirate);

        private bool _filterRaceBeastEnabled;
        public bool FilterRaceBeastEnabled
        {
            get { return _filterRaceBeastEnabled; }
            set { SetProperty(ref _filterRaceBeastEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceBeast = (c => c.Race == MinionRace.Beast);

        private bool _filterRaceMechEnabled;
        public bool FilterRaceMechEnabled
        {
            get { return _filterRaceMechEnabled; }
            set { SetProperty(ref _filterRaceMechEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceMech = (c => c.Race == MinionRace.Mech);

        private bool _filterRaceMurlocEnabled;
        public bool FilterRaceMurlocEnabled
        {
            get { return _filterRaceMurlocEnabled; }
            set { SetProperty(ref _filterRaceMurlocEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceMurloc = (c => c.Race == MinionRace.Murloc);

        private bool _filterRaceTotemEnabled;
        public bool FilterRaceTotemEnabled
        {
            get { return _filterRaceTotemEnabled; }
            set { SetProperty(ref _filterRaceTotemEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterRaceTotem = (c => c.Race == MinionRace.Totem);

        private bool _filterCollectibleEnabled;
        public bool FilterCollectibleEnabled
        {
            get { return _filterCollectibleEnabled; }
            set { SetProperty(ref _filterCollectibleEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterCollectible = (c => c.IsCollectible);

        private bool _filterNonCollectibleEnabled;
        public bool FilterNonCollectibleEnabled
        {
            get { return _filterNonCollectibleEnabled; }
            set { SetProperty(ref _filterNonCollectibleEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterNonCollectible = (c => !c.IsCollectible);


        private bool _filterWithImageEnabled;
        public bool FilterWithImageEnabled
        {
            get { return _filterWithImageEnabled; }
            set { SetProperty(ref _filterWithImageEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterWithImage = (c => c.Image != null);

        private bool _filterWithoutImageEnabled;
        public bool FilterWithoutImageEnabled
        {
            get { return _filterWithoutImageEnabled; }
            set { SetProperty(ref _filterWithoutImageEnabled, value); UpdateFilters(); }
        }
        private Func<CardInfo, bool> _filterWithoutImage = (c => c.Image == null);

        private List<List<Func<CardInfo, bool>>> _filters;

        public MainViewModel()
        {
            CardInfo.LoadImages();
            CardInfo.LoadJsonDatabase("AllSets.enUS.json");
            

            _nameFilter = (c => _nameFilterText == "" || c.Name.ToLower().Contains(_nameFilterText.ToLower()));
            _nameFilterText = "";

            _textFilter = (c => _textFilterText == "" || (c.Text != null && c.Text.ToLower().Contains(_textFilterText.ToLower())));
            _textFilterText = "";

            _filterCost0Enabled = true;
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

            _filterSetBasicEnabled = true;
            _filterSetClassicEnabled = true;
            _filterSetNaxxramasEnabled = false;
            _filterSetGoblinsVsGnomesEnabled = false;
            _filterSetBlackrockMountainEnabled = false;
            _filterSetPromotionEnabled = true;
            _filterSetRewardEnabled = true;

            _filterTypeMinionEnabled = true;
            _filterTypeSpellEnabled = true;
            _filterTypeWeaponEnabled = true;
            _filterTypeHeroEnabled = true;
            _filterTypeHeroPowerEnabled = true;
            _filterTypeEnchantmentEnabled = true;

            _filterRaceNoneEnabled = true;
            _filterRaceMechEnabled = true;
            _filterRaceDragonEnabled = true;
            _filterRaceBeastEnabled = true;
            _filterRaceTotemEnabled = true;
            _filterRaceDemonEnabled = true;
            _filterRaceMurlocEnabled = true;
            _filterRacePirateEnabled = true;

            _filterCollectibleEnabled = true;
            _filterNonCollectibleEnabled = false;

            _filterWithImageEnabled = false;
            _filterWithoutImageEnabled = true;

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

            List<Func<CardInfo, bool>> textFilters = new List<Func<CardInfo, bool>>();
            textFilters.Add(_textFilter);
            _filters.Add(textFilters);

            List<Func<CardInfo, bool>> costFilters = new List<Func<CardInfo, bool>>();
            if (_filterCost0Enabled) costFilters.Add(_filterCost0);
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

            List<Func<CardInfo, bool>> setFilters = new List<Func<CardInfo, bool>>();
            if (_filterSetBasicEnabled) setFilters.Add(_filterSetBasic);
            if (_filterSetClassicEnabled) setFilters.Add(_filterSetClassic);
            if (_filterSetNaxxramasEnabled) setFilters.Add(_filterSetNaxxramas);
            if (_filterSetGoblinsVsGnomesEnabled) setFilters.Add(_filterSetGoblinsVsGnomes);
            if (_filterSetBlackrockMountainEnabled) setFilters.Add(_filterSetBlackrockMountain);
            if (_filterSetPromotionEnabled) setFilters.Add(_filterSetPromotion);
            if (_filterSetRewardEnabled) setFilters.Add(_filterSetReward);
            _filters.Add(setFilters);

            List<Func<CardInfo, bool>> typeFilters = new List<Func<CardInfo, bool>>();
            if (_filterTypeMinionEnabled) typeFilters.Add(_filterTypeMinion);
            if (_filterTypeSpellEnabled) typeFilters.Add(_filterTypeSpell);
            if (_filterTypeWeaponEnabled) typeFilters.Add(_filterTypeWeapon);
            if (_filterTypeHeroEnabled) typeFilters.Add(_filterTypeHero);
            if (_filterTypeHeroPowerEnabled) typeFilters.Add(_filterTypeHeroPower);
            if (_filterTypeEnchantmentEnabled) typeFilters.Add(_filterTypeEnchantment);
            _filters.Add(typeFilters);

            List<Func<CardInfo, bool>> raceFilters = new List<Func<CardInfo, bool>>();
            if (_filterRaceNoneEnabled) raceFilters.Add(_filterRaceNone);
            if (_filterRaceMechEnabled) raceFilters.Add(_filterRaceMech);
            if (_filterRaceDragonEnabled) raceFilters.Add(_filterRaceDragon);
            if (_filterRaceBeastEnabled) raceFilters.Add(_filterRaceBeast);
            if (_filterRaceTotemEnabled) raceFilters.Add(_filterRaceTotem);
            if (_filterRaceDemonEnabled) raceFilters.Add(_filterRaceDemon);
            if (_filterRaceMurlocEnabled) raceFilters.Add(_filterRaceMurloc);
            if (_filterRacePirateEnabled) raceFilters.Add(_filterRacePirate);
            _filters.Add(raceFilters);

            List<Func<CardInfo, bool>> collectibleFilters = new List<Func<CardInfo, bool>>();
            if (_filterCollectibleEnabled) collectibleFilters.Add(_filterCollectible);
            if (_filterNonCollectibleEnabled) collectibleFilters.Add(_filterNonCollectible);
            _filters.Add(collectibleFilters);

            List<Func<CardInfo, bool>> imageFilters = new List<Func<CardInfo, bool>>();
            if (_filterWithImageEnabled) imageFilters.Add(_filterWithImage);
            if (_filterWithoutImageEnabled) imageFilters.Add(_filterWithoutImage);
            _filters.Add(imageFilters);

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
