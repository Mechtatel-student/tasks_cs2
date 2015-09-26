using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    interface IMinerGameFactory
    {
        IMinerGame NewEmptyGame(string playerName, Tuple<int,int> rowsCols);
        IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs);
        void Test();
    }
}
