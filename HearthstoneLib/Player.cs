using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public abstract class Player : IPlayer
    {
        private readonly PlayerClass _class;

        public PlayerClass Class
        {
            get { return _class; }
        }

        private Deck _deck;

        public Deck Deck
        {
            get { return _deck; }
        }

        protected Player(PlayerClass playerClass, Deck deck)
        {
            _class = playerClass;
            _deck = deck;
            _turn = PlayerTurn.Player1;
        }

        public abstract PlayerAction ChooseAction(Board board);

        public abstract List<Card> ChooseMulligan(List<Card> initialHand);

        private PlayerTurn _turn;
        public PlayerTurn Turn
        {
            get
            {
                return _turn;
            }
            set
            {
                _turn = value;
            }
        }
    }
}
