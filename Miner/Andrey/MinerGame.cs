using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Andrey
{
    class MinerGame : IMinerGame
    {
        public bool SetBomb(int row, int col)
        {
            throw new NotImplementedException();
        }

        public bool IsGameStarted
        {
            get { throw new NotImplementedException(); }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public bool Win
        {
            get { throw new NotImplementedException(); }
        }

        public bool Lose
        {
            get { throw new NotImplementedException(); }
        }

        public bool OpenCell(int row, int col)
        {
            throw new NotImplementedException();
        }

        public CellStatus this[int row, int col]
        {
            get { throw new NotImplementedException(); }
        }


        public int Width
        {
            get { throw new NotImplementedException(); }
        }

        public int Height
        {
            get { throw new NotImplementedException(); }
        }
    }
}
