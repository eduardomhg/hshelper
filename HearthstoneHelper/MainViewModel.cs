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
        private ObservableCollection<ExtendedCardInfo> _cards;
        public ObservableCollection<ExtendedCardInfo> Cards
        {
            get { return _cards; }
            set 
            { 
                SetProperty(ref _cards, value);
                OnPropertyChanged("TotalNumberOfCards");
                OnPropertyChanged("NumberOfFilteredCardsWithImage");
                OnPropertyChanged("NumberOfFilteredCardsAll");
                OnPropertyChanged("NumberOfFilteredCardsAtLeastOne");
                OnPropertyChanged("NumberOfFilteredCards"); 
            }
        }

        public int TotalNumberOfCards
        {
            get { return ExtendedCardInfo.AllCardsExtended.Count; }
        }

        public int NumberOfFilteredCards
        {
            get { return _cards.Count; }
        }

        public int NumberOfFilteredCardsWithImage
        {
            get { return _cards.Count(c => c.Image != null); }
        }

        public int NumberOfFilteredCardsAll
        {
            get { return _cards.Count(c => (c.NumberOfTotalCards >= 2) || (c.IsElite && c.NumberOfTotalCards >= 1) ); }
        }

        public int NumberOfFilteredCardsAtLeastOne
        {
            get { return _cards.Count(c => (c.NumberOfTotalCards >= 1)); }
        }

        private string _nameFilterText;
        public string NameFilterText
        {
            get { return _nameFilterText; }
            set { SetProperty(ref _nameFilterText, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _nameFilter;

        private string _textFilterText;
        public string TextFilterText
        {
            get { return _textFilterText; }
            set { SetProperty(ref _textFilterText, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _textFilter;


        private bool _filterCost0Enabled;
        public bool FilterCost0Enabled
        {
            get { return _filterCost0Enabled; }
            set { SetProperty(ref _filterCost0Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost0 = (c => c.Cost == 0);

        private bool _filterCost1Enabled;
        public bool FilterCost1Enabled
        {
            get { return _filterCost1Enabled; }
            set { SetProperty(ref _filterCost1Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost1 = (c => c.Cost == 1);

        private bool _filterCost2Enabled;
        public bool FilterCost2Enabled
        {
            get { return _filterCost2Enabled; }
            set { SetProperty(ref _filterCost2Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost2 = (c => c.Cost == 2);

        private bool _filterCost3Enabled;
        public bool FilterCost3Enabled
        {
            get { return _filterCost3Enabled; }
            set { SetProperty(ref _filterCost3Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost3 = (c => c.Cost == 3);

        private bool _filterCost4Enabled;
        public bool FilterCost4Enabled
        {
            get { return _filterCost4Enabled; }
            set { SetProperty(ref _filterCost4Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost4 = (c => c.Cost == 4);

        private bool _filterCost5Enabled;
        public bool FilterCost5Enabled
        {
            get { return _filterCost5Enabled; }
            set { SetProperty(ref _filterCost5Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost5 = (c => c.Cost == 5);

        private bool _filterCost6Enabled;
        public bool FilterCost6Enabled
        {
            get { return _filterCost6Enabled; }
            set { SetProperty(ref _filterCost6Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost6 = (c => c.Cost == 6);

        private bool _filterCost7PlusEnabled;
        public bool FilterCost7PlusEnabled
        {
            get { return _filterCost7PlusEnabled; }
            set { SetProperty(ref _filterCost7PlusEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCost7Plus = (c => c.Cost >= 7);


        private bool _filterClassNeutralEnabled;
        public bool FilterClassNeutralEnabled
        {
            get { return _filterClassNeutralEnabled; }
            set { SetProperty(ref _filterClassNeutralEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassNeutral = (c => c.PlayerClass == PlayerClass.None);

        private bool _filterClassMageEnabled;
        public bool FilterClassMageEnabled
        {
            get { return _filterClassMageEnabled; }
            set { SetProperty(ref _filterClassMageEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassMage = (c => c.PlayerClass == PlayerClass.Mage);

        private bool _filterClassHunterEnabled;
        public bool FilterClassHunterEnabled
        {
            get { return _filterClassHunterEnabled; }
            set { SetProperty(ref _filterClassHunterEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassHunter = (c => c.PlayerClass == PlayerClass.Hunter);



        private bool _filterClassRogueEnabled;
        public bool FilterClassRogueEnabled
        {
            get { return _filterClassRogueEnabled; }
            set { SetProperty(ref _filterClassRogueEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassRogue = (c => c.PlayerClass == PlayerClass.Rogue);




        private bool _filterClassShamanEnabled;
        public bool FilterClassShamanEnabled
        {
            get { return _filterClassShamanEnabled; }
            set { SetProperty(ref _filterClassShamanEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassShaman = (c => c.PlayerClass == PlayerClass.Shaman);


        private bool _filterClassPaladinEnabled;
        public bool FilterClassPaladinEnabled
        {
            get { return _filterClassPaladinEnabled; }
            set { SetProperty(ref _filterClassPaladinEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassPaladin = (c => c.PlayerClass == PlayerClass.Paladin);


        private bool _filterClassPriestEnabled;
        public bool FilterClassPriestEnabled
        {
            get { return _filterClassPriestEnabled; }
            set { SetProperty(ref _filterClassPriestEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassPriest = (c => c.PlayerClass == PlayerClass.Priest);


        private bool _filterClassWarriorEnabled;
        public bool FilterClassWarriorEnabled
        {
            get { return _filterClassWarriorEnabled; }
            set { SetProperty(ref _filterClassWarriorEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassWarrior = (c => c.PlayerClass == PlayerClass.Warrior);


        private bool _filterClassWarlockEnabled;
        public bool FilterClassWarlockEnabled
        {
            get { return _filterClassWarlockEnabled; }
            set { SetProperty(ref _filterClassWarlockEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassWarlock = (c => c.PlayerClass == PlayerClass.Warlock);


        private bool _filterClassDruidEnabled;
        public bool FilterClassDruidEnabled
        {
            get { return _filterClassDruidEnabled; }
            set { SetProperty(ref _filterClassDruidEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterClassDruid = (c => c.PlayerClass == PlayerClass.Druid);



        private bool _filterRarityFreeEnabled;
        public bool FilterRarityFreeEnabled
        {
            get { return _filterRarityFreeEnabled; }
            set { SetProperty(ref _filterRarityFreeEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRarityFree = (c => c.Rarity == CardRarity.Free);

        private bool _filterRarityCommonEnabled;
        public bool FilterRarityCommonEnabled
        {
            get { return _filterRarityCommonEnabled; }
            set { SetProperty(ref _filterRarityCommonEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRarityCommon = (c => c.Rarity == CardRarity.Common);

        private bool _filterRarityRareEnabled;
        public bool FilterRarityRareEnabled
        {
            get { return _filterRarityRareEnabled; }
            set { SetProperty(ref _filterRarityRareEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRarityRare = (c => c.Rarity == CardRarity.Rare);

        private bool _filterRarityEpicEnabled;
        public bool FilterRarityEpicEnabled
        {
            get { return _filterRarityEpicEnabled; }
            set { SetProperty(ref _filterRarityEpicEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRarityEpic = (c => c.Rarity == CardRarity.Epic);

        private bool _filterRarityLegendaryEnabled;
        public bool FilterRarityLegendaryEnabled
        {
            get { return _filterRarityLegendaryEnabled; }
            set { SetProperty(ref _filterRarityLegendaryEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRarityLegendary = (c => c.Rarity == CardRarity.Legendary);

        private bool _filterSetBasicEnabled;
        public bool FilterSetBasicEnabled
        {
            get { return _filterSetBasicEnabled; }
            set { SetProperty(ref _filterSetBasicEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetBasic = (c => c.Set == CardSet.Basic);

        private bool _filterSetClassicEnabled;
        public bool FilterSetClassicEnabled
        {
            get { return _filterSetClassicEnabled; }
            set { SetProperty(ref _filterSetClassicEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetClassic = (c => c.Set == CardSet.Classic);

        private bool _filterSetNaxxramasEnabled;
        public bool FilterSetNaxxramasEnabled
        {
            get { return _filterSetNaxxramasEnabled; }
            set { SetProperty(ref _filterSetNaxxramasEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetNaxxramas = (c => c.Set == CardSet.Naxxramas);

        private bool _filterSetGoblinsVsGnomesEnabled;
        public bool FilterSetGoblinsVsGnomesEnabled
        {
            get { return _filterSetGoblinsVsGnomesEnabled; }
            set { SetProperty(ref _filterSetGoblinsVsGnomesEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetGoblinsVsGnomes = (c => c.Set == CardSet.GoblinsVsGnomes);

        private bool _filterSetBlackrockMountainEnabled;
        public bool FilterSetBlackrockMountainEnabled
        {
            get { return _filterSetBlackrockMountainEnabled; }
            set { SetProperty(ref _filterSetBlackrockMountainEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetBlackrockMountain = (c => c.Set == CardSet.BlackrockMountain);

        private bool _filterSetPromotionEnabled;
        public bool FilterSetPromotionEnabled
        {
            get { return _filterSetPromotionEnabled; }
            set { SetProperty(ref _filterSetPromotionEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetPromotion = (c => c.Set == CardSet.Promotion);

        private bool _filterSetRewardEnabled;
        public bool FilterSetRewardEnabled
        {
            get { return _filterSetRewardEnabled; }
            set { SetProperty(ref _filterSetRewardEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetReward = (c => c.Set == CardSet.Reward);

        private bool _filterSetTheGrandTournamentEnabled;
        public bool FilterSetTheGrandTournamentEnabled
        {
            get { return _filterSetTheGrandTournamentEnabled; }
            set { SetProperty(ref _filterSetTheGrandTournamentEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterSetTheGrandTournament = (c => c.Set == CardSet.TheGrandTournament);

        private bool _filterTypeMinionEnabled;
        public bool FilterTypeMinionEnabled
        {
            get { return _filterTypeMinionEnabled; }
            set { SetProperty(ref _filterTypeMinionEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterTypeMinion = (c => c.Type == CardType.Minion);

        private bool _filterTypeSpellEnabled;
        public bool FilterTypeSpellEnabled
        {
            get { return _filterTypeSpellEnabled; }
            set { SetProperty(ref _filterTypeSpellEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterTypeSpell = (c => c.Type == CardType.Spell);

        private bool _filterTypeHeroPowerEnabled;
        public bool FilterTypeHeroPowerEnabled
        {
            get { return _filterTypeHeroPowerEnabled; }
            set { SetProperty(ref _filterTypeHeroPowerEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterTypeHeroPower = (c => c.Type == CardType.HeroPower);

        private bool _filterTypeHeroEnabled;
        public bool FilterTypeHeroEnabled
        {
            get { return _filterTypeHeroEnabled; }
            set { SetProperty(ref _filterTypeHeroEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterTypeHero = (c => c.Type == CardType.Hero);

        private bool _filterTypeWeaponEnabled;
        public bool FilterTypeWeaponEnabled
        {
            get { return _filterTypeWeaponEnabled; }
            set { SetProperty(ref _filterTypeWeaponEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterTypeWeapon = (c => c.Type == CardType.Weapon);

        private bool _filterTypeEnchantmentEnabled;
        public bool FilterTypeEnchantmentEnabled
        {
            get { return _filterTypeEnchantmentEnabled; }
            set { SetProperty(ref _filterTypeEnchantmentEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterTypeEnchantment = (c => c.Type == CardType.Enchantment);

        private bool _filterRaceNoneEnabled;
        public bool FilterRaceNoneEnabled
        {
            get { return _filterRaceNoneEnabled; }
            set { SetProperty(ref _filterRaceNoneEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceNone = (c => c.Race == MinionRace.None);

        private bool _filterRaceDemonEnabled;
        public bool FilterRaceDemonEnabled
        {
            get { return _filterRaceDemonEnabled; }
            set { SetProperty(ref _filterRaceDemonEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceDemon = (c => c.Race == MinionRace.Demon);


        private bool _filterRaceDragonEnabled;
        public bool FilterRaceDragonEnabled
        {
            get { return _filterRaceDragonEnabled; }
            set { SetProperty(ref _filterRaceDragonEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceDragon = (c => c.Race == MinionRace.Dragon);


        private bool _filterRacePirateEnabled;
        public bool FilterRacePirateEnabled
        {
            get { return _filterRacePirateEnabled; }
            set { SetProperty(ref _filterRacePirateEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRacePirate = (c => c.Race == MinionRace.Pirate);

        private bool _filterRaceBeastEnabled;
        public bool FilterRaceBeastEnabled
        {
            get { return _filterRaceBeastEnabled; }
            set { SetProperty(ref _filterRaceBeastEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceBeast = (c => c.Race == MinionRace.Beast);

        private bool _filterRaceMechEnabled;
        public bool FilterRaceMechEnabled
        {
            get { return _filterRaceMechEnabled; }
            set { SetProperty(ref _filterRaceMechEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceMech = (c => c.Race == MinionRace.Mech);

        private bool _filterRaceMurlocEnabled;
        public bool FilterRaceMurlocEnabled
        {
            get { return _filterRaceMurlocEnabled; }
            set { SetProperty(ref _filterRaceMurlocEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceMurloc = (c => c.Race == MinionRace.Murloc);

        private bool _filterRaceTotemEnabled;
        public bool FilterRaceTotemEnabled
        {
            get { return _filterRaceTotemEnabled; }
            set { SetProperty(ref _filterRaceTotemEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterRaceTotem = (c => c.Race == MinionRace.Totem);

        private bool _filterCollectibleEnabled;
        public bool FilterCollectibleEnabled
        {
            get { return _filterCollectibleEnabled; }
            set { SetProperty(ref _filterCollectibleEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterCollectible = (c => c.IsCollectible);

        private bool _filterNonCollectibleEnabled;
        public bool FilterNonCollectibleEnabled
        {
            get { return _filterNonCollectibleEnabled; }
            set { SetProperty(ref _filterNonCollectibleEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterNonCollectible = (c => !c.IsCollectible);


        private bool _filterWithImageEnabled;
        public bool FilterWithImageEnabled
        {
            get { return _filterWithImageEnabled; }
            set { SetProperty(ref _filterWithImageEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterWithImage = (c => c.Image != null);

        private bool _filterWithoutImageEnabled;
        public bool FilterWithoutImageEnabled
        {
            get { return _filterWithoutImageEnabled; }
            set { SetProperty(ref _filterWithoutImageEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterWithoutImage = (c => c.Image == null);

        private bool _filterNumber0Enabled;
        public bool FilterNumber0Enabled
        {
            get { return _filterNumber0Enabled; }
            set { SetProperty(ref _filterNumber0Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterNumber0 = (c => c.NumberOfTotalCards == 0);

        private bool _filterNumber1Enabled;
        public bool FilterNumber1Enabled
        {
            get { return _filterNumber1Enabled; }
            set { SetProperty(ref _filterNumber1Enabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterNumber1 = (c => c.NumberOfTotalCards == 1);

        private bool _filterNumber2PlusEnabled;
        public bool FilterNumber2PlusEnabled
        {
            get { return _filterNumber2PlusEnabled; }
            set { SetProperty(ref _filterNumber2PlusEnabled, value); UpdateFilters(); }
        }
        private Func<ExtendedCardInfo, bool> _filterNumber2Plus = (c => c.NumberOfTotalCards >= 2);


        private List<List<Func<ExtendedCardInfo, bool>>> _filters;

        public MainViewModel()
        {
            ExtendedCardInfo.LoadImages();
            ExtendedCardInfo.LoadJsonDatabase("AllSets.json");

            if (!ExtendedCardInfo.LoadXmlDatabase("Extended.xml"))
            {
                ExtendedCardInfo.CreateXmlDatabaseFromJsonDatabase("Extended.xml");
            }

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
            _filterSetNaxxramasEnabled = true;
            _filterSetGoblinsVsGnomesEnabled = true;
            _filterSetBlackrockMountainEnabled = true;
            _filterSetPromotionEnabled = true;
            _filterSetRewardEnabled = true;
            _filterSetTheGrandTournamentEnabled = true;

            _filterTypeMinionEnabled = true;
            _filterTypeSpellEnabled = true;
            _filterTypeWeaponEnabled = true;
            _filterTypeHeroEnabled = false;
            _filterTypeHeroPowerEnabled = false;
            _filterTypeEnchantmentEnabled = false;

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

            _filterWithImageEnabled = true;
            _filterWithoutImageEnabled = true;

            _filterNumber0Enabled = true;
            _filterNumber1Enabled = true;
            _filterNumber2PlusEnabled = true;

            _filterClassNeutralEnabled = true;
            _filterClassDruidEnabled = true;
            _filterClassMageEnabled = true;
            _filterClassHunterEnabled = true;
            _filterClassPaladinEnabled = true;
            _filterClassPriestEnabled = true;
            _filterClassShamanEnabled = true;
            _filterClassRogueEnabled = true;
            _filterClassWarlockEnabled = true;
            _filterClassWarriorEnabled = true;

            UpdateFilters();
        }

        public void FilterCards(Func<ExtendedCardInfo, bool> filterPredicate)
        {
            Cards = new ObservableCollection<ExtendedCardInfo>(ExtendedCardInfo.AllCardsExtended.Where(filterPredicate));
        }

        private void UpdateFilters()
        {
            _filters = new List<List<Func<ExtendedCardInfo, bool>>>();

            List<Func<ExtendedCardInfo, bool>> nameFilters = new List<Func<ExtendedCardInfo, bool>>();
            nameFilters.Add(_nameFilter);
            _filters.Add(nameFilters);

            List<Func<ExtendedCardInfo, bool>> textFilters = new List<Func<ExtendedCardInfo, bool>>();
            textFilters.Add(_textFilter);
            _filters.Add(textFilters);

            List<Func<ExtendedCardInfo, bool>> costFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterCost0Enabled) costFilters.Add(_filterCost0);
            if (_filterCost1Enabled) costFilters.Add(_filterCost1);
            if (_filterCost2Enabled) costFilters.Add(_filterCost2);
            if (_filterCost3Enabled) costFilters.Add(_filterCost3);
            if (_filterCost4Enabled) costFilters.Add(_filterCost4);
            if (_filterCost5Enabled) costFilters.Add(_filterCost5);
            if (_filterCost6Enabled) costFilters.Add(_filterCost6);
            if (_filterCost7PlusEnabled) costFilters.Add(_filterCost7Plus);
            _filters.Add(costFilters);

            List<Func<ExtendedCardInfo, bool>> rarityFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterRarityFreeEnabled) rarityFilters.Add(_filterRarityFree);
            if (_filterRarityCommonEnabled) rarityFilters.Add(_filterRarityCommon);
            if (_filterRarityRareEnabled) rarityFilters.Add(_filterRarityRare);
            if (_filterRarityEpicEnabled) rarityFilters.Add(_filterRarityEpic);
            if (_filterRarityLegendaryEnabled) rarityFilters.Add(_filterRarityLegendary);
            _filters.Add(rarityFilters);

            List<Func<ExtendedCardInfo, bool>> setFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterSetBasicEnabled) setFilters.Add(_filterSetBasic);
            if (_filterSetClassicEnabled) setFilters.Add(_filterSetClassic);
            if (_filterSetNaxxramasEnabled) setFilters.Add(_filterSetNaxxramas);
            if (_filterSetGoblinsVsGnomesEnabled) setFilters.Add(_filterSetGoblinsVsGnomes);
            if (_filterSetBlackrockMountainEnabled) setFilters.Add(_filterSetBlackrockMountain);
            if (_filterSetTheGrandTournamentEnabled) setFilters.Add(_filterSetTheGrandTournament);
            if (_filterSetPromotionEnabled) setFilters.Add(_filterSetPromotion);
            if (_filterSetRewardEnabled) setFilters.Add(_filterSetReward);
            _filters.Add(setFilters);

            List<Func<ExtendedCardInfo, bool>> typeFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterTypeMinionEnabled) typeFilters.Add(_filterTypeMinion);
            if (_filterTypeSpellEnabled) typeFilters.Add(_filterTypeSpell);
            if (_filterTypeWeaponEnabled) typeFilters.Add(_filterTypeWeapon);
            if (_filterTypeHeroEnabled) typeFilters.Add(_filterTypeHero);
            if (_filterTypeHeroPowerEnabled) typeFilters.Add(_filterTypeHeroPower);
            if (_filterTypeEnchantmentEnabled) typeFilters.Add(_filterTypeEnchantment);
            _filters.Add(typeFilters);

            List<Func<ExtendedCardInfo, bool>> raceFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterRaceNoneEnabled) raceFilters.Add(_filterRaceNone);
            if (_filterRaceMechEnabled) raceFilters.Add(_filterRaceMech);
            if (_filterRaceDragonEnabled) raceFilters.Add(_filterRaceDragon);
            if (_filterRaceBeastEnabled) raceFilters.Add(_filterRaceBeast);
            if (_filterRaceTotemEnabled) raceFilters.Add(_filterRaceTotem);
            if (_filterRaceDemonEnabled) raceFilters.Add(_filterRaceDemon);
            if (_filterRaceMurlocEnabled) raceFilters.Add(_filterRaceMurloc);
            if (_filterRacePirateEnabled) raceFilters.Add(_filterRacePirate);
            _filters.Add(raceFilters);

            List<Func<ExtendedCardInfo, bool>> collectibleFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterCollectibleEnabled) collectibleFilters.Add(_filterCollectible);
            if (_filterNonCollectibleEnabled) collectibleFilters.Add(_filterNonCollectible);
            _filters.Add(collectibleFilters);

            List<Func<ExtendedCardInfo, bool>> imageFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterWithImageEnabled) imageFilters.Add(_filterWithImage);
            if (_filterWithoutImageEnabled) imageFilters.Add(_filterWithoutImage);
            _filters.Add(imageFilters);

            List<Func<ExtendedCardInfo, bool>> numberFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterNumber0Enabled) numberFilters.Add(_filterNumber0);
            if (_filterNumber1Enabled) numberFilters.Add(_filterNumber1);
            if (_filterNumber2PlusEnabled) numberFilters.Add(_filterNumber2Plus);
            _filters.Add(numberFilters);


            List<Func<ExtendedCardInfo, bool>> classFilters = new List<Func<ExtendedCardInfo, bool>>();
            if (_filterClassNeutralEnabled) classFilters.Add(_filterClassNeutral);
            if (_filterClassMageEnabled) classFilters.Add(_filterClassMage);
            if (_filterClassHunterEnabled) classFilters.Add(_filterClassHunter);
            if (_filterClassDruidEnabled) classFilters.Add(_filterClassDruid);
            if (_filterClassShamanEnabled) classFilters.Add(_filterClassShaman);
            if (_filterClassRogueEnabled) classFilters.Add(_filterClassRogue);
            if (_filterClassPaladinEnabled) classFilters.Add(_filterClassPaladin);
            if (_filterClassPriestEnabled) classFilters.Add(_filterClassPriest);
            if (_filterClassWarlockEnabled) classFilters.Add(_filterClassWarlock);
            if (_filterClassWarriorEnabled) classFilters.Add(_filterClassWarrior);            
            _filters.Add(classFilters);

            FilterCards(ApplyFilters);
        }

        private bool ApplyFilters(ExtendedCardInfo card)
        {
            bool matches = true;
            bool matchesCategory = false;

            foreach (List<Func<ExtendedCardInfo, bool>> filterCategory in _filters)
            {
                matchesCategory = false;
                // AND between filters
                foreach (Func<ExtendedCardInfo, bool> filter in filterCategory)
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
