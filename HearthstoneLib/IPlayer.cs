using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface IPlayer
    {
        PlayerClass Class { get; }
        Deck Deck { get; }
        PlayerTurn Turn { get; set; }

        PlayerAction ChooseAction(Board board);
        List<Card> ChooseMulligan(List<Card> initialHand);
    }
}
