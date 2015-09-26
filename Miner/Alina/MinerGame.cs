using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Alina
{
    class MinerGame : IMinerGame
    {
        int bombs;
        string playerName;
        string PlayerName { get { return playerName; } }
        public int Width { get; private set; }
        public int Height { get; private set; }

        enum Statuses
        {
            Undefined,
            Empty = 1,
            HasMine,
            OneAround, TwoAround, ThreeAround, FourAround, FiveAround, SixAround, SevenAround, EightAround,
        };
        class OneCell
        {
            public bool StartStatus { get; set; }
            public Statuses StatusInGame { get; set; }
            public OneCell()
            {
                StartStatus = false;
                this.StatusInGame = Statuses.Undefined;
            }
        }
        OneCell[,] gameField;
        public MinerGame(string playerName, int heigh, int width)
            : this(playerName, heigh, width, 0)
        {

        }
        public MinerGame(string playerName, int heigh, int width, int bombs)
        {
            this.playerName = playerName;
            Height = heigh;
            Width = width;
            gameField = new OneCell[heigh, width];
            for (int row = 0; row < heigh; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    gameField[row, col] = new OneCell();
                }
            }
            Random randomNumber = new Random();
            for (int i = 0; i < bombs; i++)
            {
                SetBomb(randomNumber.Next(0, heigh - 1), randomNumber.Next(0, width - 1));
            }
        }

        public bool SetBomb(int row, int col)
        {
            if (IsGameStarted)
            {
                throw new InvalidOperationException("Нельзя устанавливать бомбы после старта игры");
            }
            bool inField = InField(row, col);
            if (inField)
            {
                gameField[row, col].StatusInGame = Statuses.HasMine;
                inField = true;
                bombs += 1;
            }
            return inField;

        }
        public bool IsGameStarted { get; private set; }

        public void Start()
        {
            IsGameStarted = true;
        }
        bool win;
        public bool Win
        {
            get
            {
                int counter = 0;
                foreach (var element in gameField)
                {
                    if (element.StartStatus == false)
                    {
                        counter++;
                    }
                }
                return counter == bombs;
            }
        }
        bool lose;
        public bool Lose
        {
            get {return lose; }
        }
        int BombCalculation(int row, int col)
        {
            int sum = 0;
            if (row != 0 && col != 0 && gameField[row - 1, col - 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (row != 0 && gameField[row - 1, col].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (row != 0 && col != Width && gameField[row - 1, col + 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != 0 && gameField[row, col - 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != Width && gameField[row, col + 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != 0 && row != Height && gameField[row + 1, col - 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (row != Height && gameField[row + 1, col].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != Width && row != Height && gameField[row + 1, col + 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            return sum;
        }
        public bool OpenCell(int row, int col)
        {
            int counter = 0;
            bool inField = InField(row, col);
            if (lose || win)
            {
                inField = false; 
            }
            if (!IsGameStarted)
            {
                throw new InvalidOperationException("Нельзя открывать ячейки до начала игры");
            }           
            if (inField)
            {
                gameField[row, col].StartStatus = true;
                if (gameField[row, col].StatusInGame == Statuses.HasMine)
                {
                    lose = true;
                }
                else if (counter == gameField.Rank - bombs)
                {
                    win = true;
                }
                else
                {
                    switch (BombCalculation(row, col))
                    {
                        case 0: gameField[row, col].StatusInGame = Statuses.Empty;
                            break;
                        case 1: gameField[row, col].StatusInGame = Statuses.OneAround;
                            break;
                        case 2: gameField[row, col].StatusInGame = Statuses.TwoAround;
                            break;
                        case 3: gameField[row, col].StatusInGame = Statuses.ThreeAround;
                            break;
                        case 4: gameField[row, col].StatusInGame = Statuses.FourAround;
                            break;
                        case 5: gameField[row, col].StatusInGame = Statuses.FiveAround;
                            break;
                        case 6: gameField[row, col].StatusInGame = Statuses.SixAround;
                            break;
                        case 7: gameField[row, col].StatusInGame = Statuses.SevenAround;
                            break;
                        case 8: gameField[row, col].StatusInGame = Statuses.EightAround;
                            break;
                    }
                }
            }
            counter++;
            return inField;
        }

        public CellStatus this[int row, int col]
        {
            get
            {
                bool inField = InField(row, col);
                CellStatus statusReturn = 0;
                if (inField)
                {
                    if (gameField[row, col].StartStatus == false)
                    {
                        statusReturn = CellStatus.NotOpened;
                    }
                    else
                    {
                        switch (gameField[row, col].StatusInGame)
                        {
                            case Statuses.Empty: statusReturn = CellStatus.Empty;
                                break;
                            case Statuses.HasMine: statusReturn = CellStatus.HasMine;
                                break;
                            case Statuses.OneAround: statusReturn = CellStatus.OneAround;
                                break;
                            case Statuses.TwoAround: statusReturn = CellStatus.TwoAround;
                                break;
                            case Statuses.ThreeAround: statusReturn = CellStatus.ThreeAround;
                                break;
                            case Statuses.FourAround: statusReturn = CellStatus.FourAround;
                                break;
                            case Statuses.FiveAround: statusReturn = CellStatus.FiveAround;
                                break;
                            case Statuses.SixAround: statusReturn = CellStatus.SixAround;
                                break;
                            case Statuses.SevenAround: statusReturn = CellStatus.SevenAround;
                                break;
                            case Statuses.EightAround: statusReturn = CellStatus.EightAround;
                                break;
                        }
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                return statusReturn;
            }
        }
        bool InField(int row, int col)
        {
            return (col >= 0 && row >= 0 && row <= Height - 1 && col <= Width - 1);
        }
    }
}
