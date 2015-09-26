using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    class GameCell
    {
        public bool IsOpened { get; set; }
        public bool IsEmpty { get; set; }
        public int CountOfBombsAround{ get; set; }

        public GameCell(bool isEmpty, bool isOpened)
        {
            IsEmpty = isEmpty;
            IsOpened = isOpened;
            CountOfBombsAround = 0;
        }


    }
}
