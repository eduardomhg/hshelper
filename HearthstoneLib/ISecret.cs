using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public interface ISecret
    {
        void Reveal(Board board);
    }
}
