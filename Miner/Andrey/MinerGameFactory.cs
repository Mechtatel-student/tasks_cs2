using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Andrey
{
    class MinerGameFactory : IMinerGameFactory
    {
        public IMinerGame NewEmptyGame(string playerName, Tuple<int, int> rowsCols)
        {
            throw new NotImplementedException();
        }

        public IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs)
        {
            throw new NotImplementedException();
        }

        internal void Test()
        {
            throw new NotImplementedException();
        }


        void IMinerGameFactory.Test()
        {
            throw new NotImplementedException();
        }
    }
}
