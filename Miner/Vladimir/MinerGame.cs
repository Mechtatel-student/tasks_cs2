using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Vladimir
{
    class MinerGame : IMinerGame
    {
        public bool SetBomb(int row, int col)
        {
            bool answer = false;
            if ((row < Height && col < Width) && (row >= 0 && col >= 0) && canMakeBomb)
            {
                if (!poleGame[row][col].yesOrNoBomb)
                {
                    countBomb++;
                }

                poleGame[row][col].yesOrNoBomb = true;
                answer = true;
            }
            return answer;
        }

        public bool IsGameStarted
        {
            get { return isStartedGame; }
        }

        public void Start()
        {
            WeightCells();
            canMakeBomb = false;
            isStartedGame = true;
        }

        public bool Win
        {
            get { return win; }
        }

        public bool Lose
        {
            get { return lose; }
        }

        public bool OpenCell(int row, int col)
        {
            bool answer = false;
            if ((row < Height && col < Width) && (row >= 0 && col >= 0) && isStartedGame)
            {
                poleGame[row][col].openCell = true;
                checkWin();

                if (poleGame[row][col].yesOrNoBomb)
                {
                    lose = true;
                }
                answer = true;
            }
            return answer;
        }

        private void checkWin()
        {
            int countCells = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
               {
                   if (poleGame[i][j].openCell && !poleGame[i][j].yesOrNoBomb)
                   {
                       countCells++;
                   }
               }
            }
            win = (countCells == width*height-countBomb);
        }


        public CellStatus this[int row, int col]
        {
            get
            {
                CellStatus answer = CellStatus.NotOpened;
                if (!IsGameStarted || poleGame[row][col].openCell)
                {
                    if (poleGame[row][col].yesOrNoBomb)
                    {
                        answer = CellStatus.HasMine;
                    }
                    else
                    {
                        answer = (CellStatus)poleGame[row][col].weightCells;
                    }
                }
                
                return answer;
            }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        // ------------- объявление структур и переменных ------------------------------
        private bool isStartedGame = false;
        private bool canMakeBomb = true;
        private bool win = false;
        private bool lose = false;
        private int countBomb = 0;

        private struct CellsGame
        {
            public bool yesOrNoBomb;          // наличие вомбы в клетке T/F
            public int weightCells;           // вес клетки (по количеству бомб в соседних клетках)
            public bool flagOfPlayer;         // наличие флага игрока в клетке T/F
            public bool qгestionOfPlayer;     // наличие вопроса игрока в клетке T/F
            public bool openCell;             // признак Открыта/Закрыта клетка
        }

        public bool OpenStatus (int row, int col)
        {
            return poleGame[row][col].openCell;
        }

        public void SetCanMakeBomb(bool inCanMakeBomb)
        {
            if (!IsGameStarted)
            {
                canMakeBomb = inCanMakeBomb;
            }
        }

        public int CountBomb
        {
            get { return countBomb; }
        }

        private int height, width;
        private CellsGame[][] poleGame;

        public MinerGame(Tuple<int, int> rowsCols)
        {
            height = rowsCols.Item1; // height = rowsCols.Item2;                            под старый тест мастера
            width = rowsCols.Item2; // width = rowsCols.Item1;                              под старый тест мастера

            poleGame = new CellsGame[Height][]; // poleGame = new CellsGame[Width][];       под старый тест мастера

            for (int i = 0; i < Height; i++) // for (int i = 0; i < Width ; i++)            под старый тест мастера
            {
                poleGame[i] = new CellsGame[Width]; // poleGame[i] = new CellsGame[Height]; под старый тест мастера
                for (int j = 0; j < Width; j++)     // for (int j = 0; j < Height; j++)     под старый тест мастера
                {
                    poleGame[i][j].yesOrNoBomb = false;
                    poleGame[i][j].weightCells = 0;
                    poleGame[i][j].flagOfPlayer = false;
                    poleGame[i][j].qгestionOfPlayer = false;
                    poleGame[i][j].openCell = false;
                }
            }
        }

        //------------------------подсчет веса клетки--------------------------------
        private void WeightCells()
        {
            // Создание и инициализация массива с нулевыми первыми и последними строками и солбцами
            int[][] workArray = new int[poleGame.Length + 2][];
            int secondIndex = poleGame[0].Length;

            for (int i = 0; i < poleGame.Length + 2; i++)
            {
                workArray[i] = new int[secondIndex + 2];
            }

            // Подсчет весов ячеек входного массива (вес ячейки = сумма количества бомб в окружающих ячейках)
            // Заливка значений входного массива в массив, в котором значения 1-й, последней строки и столбы = 0
            for (int i = 0; i < poleGame.Length; i++)
            {
                for (int j = 0; j < poleGame[i].Length; j++)
                {
                    workArray[i + 1][j + 1] = poleGame[i][j].yesOrNoBomb ? 1 : 0;
                }
            }
            // Посчет весов ячеек входного массива (вес ячейки = количества бомб в окружающих ячейках)
            int indexI = 1;
            for (int i = 0; i < poleGame.Length; i++)
            {
                int indexJ = 1;
                for (int j = 0; j < poleGame[i].Length; j++)
                {
                    poleGame[i][j].weightCells = workArray[indexI - 1][indexJ - 1] + workArray[indexI - 1][indexJ] + workArray[indexI - 1][indexJ + 1] +
                                                  workArray[indexI][indexJ - 1] + workArray[indexI][indexJ + 1] +
                                                  workArray[indexI + 1][indexJ - 1] + workArray[indexI + 1][indexJ] + workArray[indexI + 1][indexJ + 1];
                    indexJ++;
                }
                indexI++;
            }


        }
        
        //------------------------

    }
}
