using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    
    class MinerGame : IMinerGame
    {
        private bool isGameEmpty;
        private bool isGameStarted = false;
        private bool isGameLost;
        private bool isGameWon;
        int gameFieldWidth = 0;
        int gameFieldHeight = 0;
        int countOfOpenedCells = 0;
        int countOfSetBombs = 0;
        static Random rand = new Random();
        GameCell[,] gameField;
        public MinerGame (int rowNumber, int collNumber)
        {
            isGameEmpty = true;
            gameField = new GameCell[rowNumber, collNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < collNumber; j++)
                {
                    gameField[i,j] = new GameCell(isEmpty: true, isOpened: false);
                }
            }
            gameFieldWidth = collNumber;
            gameFieldHeight = rowNumber;
        }

        public MinerGame (int rowNumber, int collNumber, int countOfBombs)
        {
            isGameEmpty = false;
            gameField = new GameCell[rowNumber,collNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < collNumber; j++)
                {
                    gameField[i, j] = new GameCell(isEmpty: true, isOpened: false);
                }
            }
            gameFieldWidth = rowNumber;
            gameFieldHeight = collNumber;
            while (countOfBombs != 0)
            {
                int i = rand.Next(0, rowNumber);
                int j = rand.Next(0, collNumber);
                if (SetBomb(i, j))
                {
                    countOfBombs--;
                }
            }
        }

        public bool SetBomb(int row, int col)
        {
            bool bombIsSet = false;
            if (IsCellWithinField(row, col) && gameField[row, col].IsEmpty && !isGameStarted && !gameField[row, col].IsOpened)
            {
                gameField[row,col].IsEmpty = false;
                if (IsCellWithinField(row - 1, col - 1) && col - 1 < Width && gameField[row - 1,col - 1].IsEmpty)
                {
                    gameField[row - 1, col - 1].CountOfBombsAround++;
                }
                if (IsCellWithinField(row - 1, col) && gameField[row - 1, col].IsEmpty)
                {
                    gameField[row - 1, col].CountOfBombsAround++;
                }
                if (IsCellWithinField(row - 1, col + 1) && gameField[row - 1, col + 1].IsEmpty)
                {
                    gameField[row - 1, col + 1].CountOfBombsAround++;
                }
                if (IsCellWithinField(row, col - 1) && gameField[row, col - 1].IsEmpty)
                {
                    gameField[row, col - 1].CountOfBombsAround++;
                }
                if (IsCellWithinField(row, col + 1) && gameField[row, col + 1].IsEmpty)
                {
                    gameField[row, col + 1].CountOfBombsAround++;
                }
                if (IsCellWithinField(row + 1, col - 1) && gameField[row, col].IsEmpty)
                {
                    gameField[row + 1, col - 1].CountOfBombsAround++;
                }
                if (IsCellWithinField(row + 1, col) && gameField[row + 1, col].IsEmpty)
                {
                    gameField[row + 1, col].CountOfBombsAround++;
                }
                if (IsCellWithinField(row + 1, col + 1) && gameField[row + 1, col + 1].IsEmpty)
                {
                    gameField[row + 1, col + 1].CountOfBombsAround++;
                }
                bombIsSet = true;
                countOfSetBombs++;
            }

            return bombIsSet;
        }

        public bool IsGameStarted
        {
            get { return isGameStarted; }
        }

        public void Start()
        {
            isGameStarted = true;
        }

        public bool Win
        {
            get
            {
                if (gameField.Length - countOfOpenedCells == countOfSetBombs)
                {
                    isGameWon = true;
                }

                return isGameWon;
            }
        }

        public bool Lose
        {
            get { return isGameLost; }
        }

        public bool OpenCell(int row, int col)
        {
            if (IsCellWithinField(row, col) && !gameField[row, col].IsOpened && isGameStarted)
            {
                if (!gameField[row, col].IsEmpty)
                {
                    isGameLost = true;
                }
                gameField[row, col].IsOpened = true;
                countOfOpenedCells++;
            }

            return gameField[row, col].IsOpened;
        }

        public CellStatus this[int row, int col]
        {
            get {
                CellStatus statusOfCell = 0;
                if (gameField[row, col].IsEmpty)
                {
                    statusOfCell = CellStatus.Empty;
                }
                else if (!gameField[row, col].IsEmpty && !gameField[row,col].IsOpened)
                {
                    statusOfCell = CellStatus.HasMine;
                }
                else if (!gameField[row, col].IsOpened)
                {
                    statusOfCell = CellStatus.NotOpened;
                }
                if (gameField[row, col].CountOfBombsAround == 1)
                {
                    statusOfCell = CellStatus.OneAround;
                }
                if (gameField[row, col].CountOfBombsAround == 2)
                {
                    statusOfCell = CellStatus.TwoAround;
                }
                if (gameField[row, col].CountOfBombsAround == 3)
                {
                    statusOfCell = CellStatus.ThreeAround;
                }
                if (gameField[row, col].CountOfBombsAround == 4)
                {
                    statusOfCell = CellStatus.FourAround;
                }
                if (gameField[row, col].CountOfBombsAround == 5)
                {
                    statusOfCell = CellStatus.FiveAround;
                }
                if (gameField[row, col].CountOfBombsAround == 6)
                {
                    statusOfCell = CellStatus.SixAround;
                }
                if (gameField[row, col].CountOfBombsAround == 7)
                {
                    statusOfCell = CellStatus.SevenAround;
                }
                if (gameField[row, col].CountOfBombsAround == 8)
                {
                    statusOfCell = CellStatus.EightAround;
                }
                return statusOfCell;
            }
        }

        bool IsCellWithinField (int row, int col)
        {
            bool isCellInField = false;
            if (row >= 0 && row < Width && col >= 0 && col < Height)
            {
                isCellInField = true;
            }

            return isCellInField;
        }

        public int Width
        {
            get { return gameFieldWidth; }
        }

        public int Height
        {
            get { return gameFieldHeight; }
        }

        

    }
}
