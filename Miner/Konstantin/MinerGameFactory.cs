using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Konstantin
{
    class MinerGameFactory : IMinerGameFactory
    {
        IMinerGame game;    
        public IMinerGame NewEmptyGame(string playerName, Tuple<int, int> rowsCols)
        {
            game = new MinerGame(playerName, rowsCols.Item1, rowsCols.Item2);
            return game;
        }

        public IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs)
        {
            game = new MinerGame(playerName, rowsCols.Item1, rowsCols.Item2);
            return game;
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
