using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public class PlayerAction
    {
        public PlayerActionType Type;        
        public Card PlayedCard;
        public int PlayedCardBoardPosition;
        public ICharacter Source;
        public ICharacter Target;

        public PlayerAction(PlayerActionType type)
        {
            Type = type;
        }
    }
}
