using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Konstantin
{
    class MinerGame : IMinerGame
    {
        private string userName;
        private bool isGameStarted = false;
        private bool changesInField = false;
        private int countOfBombs = 0;
        private Cell[,] field;

        public MinerGame(string userName, int width, int height)
        {
            this.userName = userName;
            Width = width;
            Height = height;
            this.changesInField = true;
            this.field = CreateEmptyField(height, width);
        }

        public MinerGame(string userName, int width, int height, int countOfBombs)
        {
            this.userName = userName;
            Width = width;
            Height = height;
            this.field = CreateRandomField(height, width, countOfBombs);
        }

        private struct Cell
        {
            public bool isOpen;
            public int bombsAround; //bomb is in this cell if value equals 100
            public Cell(bool isOpen, int bombsAround)
            {
                this.isOpen = isOpen;
                this.bombsAround = bombsAround;
            }
        }
        private Cell[,] CreateEmptyField(int row, int col)
        {
            Cell[,] emptyfield = new Cell[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    emptyfield[i, j] = new Cell(false, 0);
                }
            }
            return emptyfield;
        }
        private Cell[,] CreateRandomField(int row, int col, int countOfBombs)
        {
            Cell[,] field = CreateEmptyField(row, col);

            int bombRow = 0;
            int bombCol = 0;
            int bombsCounter = 0;
            Random random = new Random();
            changesInField = true;
            do
            {
                bombRow = random.Next(1, row);
                bombCol = random.Next(1, col);

                if (field[bombRow, bombCol].bombsAround != (int)CellStatus.HasMine)
                {
                    SetBomb(bombRow, bombCol);
                    bombsCounter++;
                }
            }
            while (bombsCounter != countOfBombs);
            changesInField = false;
            return field;
        }
        public bool SetBomb(int row, int col)
        {
            bool isSet;
            if (changesInField&&field[row, col].bombsAround != (int)CellStatus.HasMine)
            {
                field[row, col].bombsAround = (int)CellStatus.HasMine;
                isSet = true;
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (field[i, j].bombsAround != (int)CellStatus.HasMine)
                        {
                            field[i, j].bombsAround++;
                        }
                    }
                }
            }
            else
            {
                isSet = false;
            }
            return isSet;
        }

        public bool IsGameStarted    { get; private set;}

        public void Start()
        {
            isGameStarted = true;
            changesInField = false;
        }

        public bool Win {get; private set;}

        public bool Lose
        {
            get; private set;
        }

        public bool OpenCell(int row, int col)
        {
            bool openCell = true;
            if (row>=Height||col>=Width||row<0||col<0)
            {
                openCell = false;
            }
            field[row + 1, col + 1].isOpen = true;
            if (!IsGameStarted)
            {
                Start();
            }
            if (field[row + 1, col + 1].bombsAround == 0)
            {
                for (int i = row; i <= row + 2; i++)
                {
                    for (int j = col; j < col + 2; j++)
                    {
                        OpenCell(i, j);
                    }
                }
            }
            else if (field[row + 1, col + 1].bombsAround == (int)CellStatus.HasMine)
            {
                for (int i = 1; i < row + 2; i++)
                {
                    for (int j = 0; j < col + 2; j++)
                    {
                        if (field[i, j].bombsAround == (int)CellStatus.HasMine)
                        {
                            OpenCell(i, j);
                        }
                    }
                }
                Lose = true;                
            }
            return openCell;
        }

        public CellStatus this[int row, int col]
        {
            get { throw new NotImplementedException(); }
        }

        public int Width
        {
            get; private set;
        }

        public int Height
        {
            get; private set;
        }
    }
}
