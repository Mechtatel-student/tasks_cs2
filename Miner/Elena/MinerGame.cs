using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Elena
{
   /* [Flags] enum CellStatus
{
        notOpened=0x0,
        Empty=0x1,
        OneAround=0x2,
        TwoAround=0x4,
        ThreeAround=0x8,
        FourAround=0x16,
        FiveAround=0x32,
        SixAround=0x64,
        SevenAround=0x128,
        EightAround=0x256,
        HasMine=0x512
}*/

    class MinerGame : IMinerGame
    {

        struct FieldCells
        {
            public CellStatus OpenClose;
            public CellStatus BombAround;
        }
        int width;
        int height;
        bool isGameStarted;
        FieldCells[,] plaingField;
        bool win;
        bool lose;


       public MinerGame(int row, int col, int bomb)
        {
           
            width=col;
            height=row;
            plaingField=new FieldCells[row,col];
            int countOfBomb = 1;
            int colNumber;
            int rowNumber;
           
            List<CellStatus> AroudCells = new List<CellStatus>();

            while (countOfBomb < bomb + 1)
            {
                Random rendBombRows = new Random();
                rowNumber = rendBombRows.Next(0, this.Height );

                Random rendBombCols = new Random();
                colNumber = rendBombRows.Next(0, this.Width );

                if (plaingField[rowNumber, colNumber].BombAround != CellStatus.HasMine)
                {

                   plaingField[rowNumber, colNumber].BombAround= CellStatus.HasMine;
                   plaingField[rowNumber, colNumber].OpenClose = CellStatus.NotOpened;
                    
                    countOfBomb++;
                }

            }

            //заполняем незаполненные бомбами поля
            for (int i = 0; i < this.Height; i++)
            {

                for (int j = 0; j < this.Width; j++)
                {
                    if (plaingField[i, j].BombAround != CellStatus.HasMine)

                        if (j == 0)
                        {
                            if (i == 0)
                            {
                                AroudCells.Add(plaingField[i, j + 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j].BombAround);
                                AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                                plaingField[i, j].BombAround=(ArroundCellsStatus(AroudCells) );
                                plaingField[i,j].OpenClose=CellStatus.NotOpened;
                                AroudCells.Clear();
                            }

                            else if (i == this.Height - 1)
                            {
                                AroudCells.Add(plaingField[i - 1, j].BombAround);
                                AroudCells.Add(plaingField[i, j + 1].BombAround);
                                AroudCells.Add(plaingField[i - 1, j + 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }

                            else
                            {
                                AroudCells.Add(plaingField[i - 1, j].BombAround);
                                AroudCells.Add(plaingField[i, j + 1].BombAround);
                                AroudCells.Add(plaingField[i - 1, j + 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j].BombAround);
                                AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }
                        }

                        else if (j == this.Width - 1)
                        {
                            if (i == 0)
                            {
                                AroudCells.Add(plaingField[i, j - 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j - 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }

                            else if (i == this.Height - 1)
                            {
                                AroudCells.Add(plaingField[i - 1, j-1].BombAround);
                                AroudCells.Add(plaingField[i-1, j ].BombAround);
                                AroudCells.Add(plaingField[i , j- 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                               
                            }

                            else
                            {
                                AroudCells.Add(plaingField[i - 1, j-1].BombAround);
                                AroudCells.Add(plaingField[i-1, j ].BombAround);
                                AroudCells.Add(plaingField[i , j - 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j].BombAround);
                                AroudCells.Add(plaingField[i+1, j - 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }
                        }

                        else
                        {
                            if (i == 0)
                            {
                                AroudCells.Add(plaingField[i , j - 1].BombAround);
                                AroudCells.Add(plaingField[i, j+1].BombAround);
                                AroudCells.Add(plaingField[i+1, j - 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j].BombAround);
                                AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }

                            else if (i == this.Height - 1)
                            {
                                AroudCells.Add(plaingField[i - 1, j - 1].BombAround);
                                AroudCells.Add(plaingField[i - 1, j].BombAround);
                                AroudCells.Add(plaingField[i-1, j + 1].BombAround);
                                AroudCells.Add(plaingField[i , j+1].BombAround);
                                AroudCells.Add(plaingField[i , j - 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }
                            else
                            {
                                AroudCells.Add(plaingField[i - 1, j - 1].BombAround);
                                AroudCells.Add(plaingField[i - 1, j].BombAround);
                                AroudCells.Add(plaingField[i-1, j + 1].BombAround);
                                AroudCells.Add(plaingField[i, j-1].BombAround);
                                AroudCells.Add(plaingField[i, j + 1].BombAround);
                                AroudCells.Add(plaingField[i + 1, j - 1].BombAround);
                                AroudCells.Add(plaingField[i+1, j ].BombAround);
                                AroudCells.Add(plaingField[i+1, j + 1].BombAround);
                                plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                                plaingField[i, j].OpenClose = CellStatus.NotOpened;
                                AroudCells.Clear();
                            }
                        }
                }
            }
        }


        //constructor for empty  game
       public MinerGame(int row, int col)
       {

           width = col;
           height = row;
           plaingField = new FieldCells[row, col];
          // int countOfBomb = 1;
           //int colNumber;
          // int rowNumber;
           string yesNo = string.Empty;
           int rowsCount;
           int colsCount;

           List<CellStatus> AroudCells = new List<CellStatus>();
           //set bombs
           Console.WriteLine("Would you like set the boombs? Enter Y or N");
           yesNo = Console.ReadLine();
           while (yesNo == "Y" || yesNo == "y")
           {
               Console.WriteLine("Enter rows number");
               while (!Int32.TryParse(Console.ReadLine(), out rowsCount) && (rowsCount < 0 || rowsCount > this.Width))
               { Console.WriteLine("You enter not correct number. Please, enter number"); }

               Console.WriteLine("Enter rows number");
               while (!Int32.TryParse(Console.ReadLine(), out colsCount) && (colsCount < 0 || colsCount > this.Height))
               { Console.WriteLine("You enter not correct number. Please, enter number"); }

               if (!this.SetBomb(rowsCount, colsCount))
               {
                   Console.WriteLine("There is bomb in this cell");
               }

               Console.WriteLine("Would you like set the boombs? Enter Y or N");
               yesNo = Console.ReadLine();
           }

          //заполняем незаполненные бомбами поля
           for (int i = 0; i < this.Height; i++)
           {

               for (int j = 0; j < this.Width; j++)
               {
                   if (plaingField[i, j].BombAround != CellStatus.HasMine)

                       if (j == 0)
                       {
                           if (i == 0)
                           {
                               AroudCells.Add(plaingField[i, j + 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j].BombAround);
                               AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }

                           else if (i == this.Height - 1)
                           {
                               AroudCells.Add(plaingField[i - 1, j].BombAround);
                               AroudCells.Add(plaingField[i, j + 1].BombAround);
                               AroudCells.Add(plaingField[i - 1, j + 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }

                           else
                           {//тут ошибка на последнем значении i
                               AroudCells.Add(plaingField[i - 1, j].BombAround);
                               AroudCells.Add(plaingField[i, j + 1].BombAround);
                               AroudCells.Add(plaingField[i - 1, j + 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j].BombAround);
                               AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }
                       }

                       else if (j == this.Width - 1)
                       {
                           if (i == 0)
                           {
                               AroudCells.Add(plaingField[i, j - 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }

                           else if (i == this.Height - 1)
                           {
                               AroudCells.Add(plaingField[i - 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i - 1, j].BombAround);
                               AroudCells.Add(plaingField[i, j - 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();

                           }

                           else
                           {
                               AroudCells.Add(plaingField[i - 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i - 1, j].BombAround);
                               AroudCells.Add(plaingField[i, j - 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j].BombAround);
                               AroudCells.Add(plaingField[i + 1, j - 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }
                       }

                       else
                       {
                           if (i == 0)
                           {
                               AroudCells.Add(plaingField[i, j - 1].BombAround);
                               AroudCells.Add(plaingField[i, j + 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j].BombAround);
                               AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }

                           else if (i == this.Height - 1)
                           {
                               AroudCells.Add(plaingField[i - 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i - 1, j].BombAround);
                               AroudCells.Add(plaingField[i - 1, j + 1].BombAround);
                               AroudCells.Add(plaingField[i, j + 1].BombAround);
                               AroudCells.Add(plaingField[i, j - 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }
                           else
                           {
                               AroudCells.Add(plaingField[i - 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i - 1, j].BombAround);
                               AroudCells.Add(plaingField[i - 1, j + 1].BombAround);
                               AroudCells.Add(plaingField[i, j - 1].BombAround);
                               AroudCells.Add(plaingField[i, j + 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j - 1].BombAround);
                               AroudCells.Add(plaingField[i + 1, j].BombAround);
                               AroudCells.Add(plaingField[i + 1, j + 1].BombAround);
                               plaingField[i, j].BombAround = (ArroundCellsStatus(AroudCells));
                               plaingField[i, j].OpenClose = CellStatus.NotOpened;
                               AroudCells.Clear();
                           }
                       }
               }
           }
       }
      /* public bool GetBomb(FieldCells[,] plaingField)
       {
           return 
       }*/

       public  bool SetBomb(int row, int col)
        {
            bool isSetBomb=true;
            if (this.plaingField[row, col].BombAround != CellStatus.HasMine)
            {
                this.plaingField[row, col].BombAround = CellStatus.HasMine;
            }
            else
            { isSetBomb = false; }
           
            return isSetBomb;
        }

      

        public bool IsGameStarted
        {
            get { return this.isGameStarted; }
        }

        public void Start()
        {
            this.isGameStarted = true;
          
        }


        public bool Win
        {
            get { return this.win; }
        }

        public bool Lose
        {
            get { return this.lose; }
        }

        public bool OpenCell(int row, int col)
        {
            bool isCell=true;
            if ((row < 0 && row > this.Width) || (col < 0 && col > this.Height))
            {
                isCell = false;
            }

            return isCell;
        }


        public Tuple<int,char> getFieldsCells(int row, int col)
        {
            Tuple<int, char> getCellStatus ;
            int open=0;
            char countOfBomb=' ';
               // FieldCells thisCells = new FieldCells();
                if (OpenCell(row, col))
                {
                    switch (this.plaingField[row, col].BombAround)
                    {
                        case CellStatus.Empty:
                            countOfBomb = '0';
                            break;
                        case CellStatus.OneAround:
                            countOfBomb = '1';
                            break;
                        case CellStatus.TwoAround:
                            countOfBomb = '2';
                            break;
                        case CellStatus.ThreeAround:
                            countOfBomb = '3';
                            break;
                        case CellStatus.FourAround:
                            countOfBomb = '4';
                            break;
                        case CellStatus.FiveAround:
                            countOfBomb ='5';
                            break;
                        case CellStatus.SixAround:
                            countOfBomb = '6';
                            break;
                        case CellStatus.SevenAround:
                            countOfBomb = '7';
                            break;
                        case CellStatus.EightAround:
                            countOfBomb = '8';
                            break;
                        case CellStatus.HasMine:
                            countOfBomb = 'X';
                            break;
                    }

                    switch (this.plaingField[row, col].OpenClose)
                    {
                        case CellStatus.NotOpened:
                            open = -1;
                            break;
                        
                    }
                    
                }

                getCellStatus = Tuple.Create(open, countOfBomb);
                return getCellStatus;
            
        }

        public CellStatus this[int row, int col]//add null parameter for return BombAround or OpenClose
        {
            
            get
            {
                return this.plaingField[row, col].BombAround;
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

        public bool chengeStatusCells(int row, int col)
        {
            bool isChenged = true;
            if (OpenCell(row, col))
            {
                this.plaingField[row, col].OpenClose = CellStatus.Empty;
            }

            else
            { isChenged = false; }
            return isChenged;
        }
        public CellStatus ArroundCellsStatus(List<CellStatus> listStatus)
        {
            CellStatus status = CellStatus.Empty;
            int countOfBomb = 0;
            foreach (CellStatus s in listStatus)
            {
                if (s.HasFlag(CellStatus.HasMine))
                { countOfBomb++; }
            }

            switch (countOfBomb)
            {
                case 0:
                    status = CellStatus.Empty;
                    break;
                case 1:
                    status = CellStatus.OneAround;
                    break;
                case 2:
                    status = CellStatus.TwoAround;
                    break;
                case 3:
                    status = CellStatus.ThreeAround;
                    break;
                case 4:
                    status = CellStatus.FourAround;
                    break;
                case 5:
                    status = CellStatus.FiveAround;
                    break;
                case 6:
                    status = CellStatus.SixAround;
                    break;
                case 7:
                    status = CellStatus.SevenAround;
                    break;
                case 8:
                    status = CellStatus.EightAround;
                    break;

            }

            return status;
        }

        public void IfLose()
        {
            this.lose = true;
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (this.plaingField[i, j].BombAround == CellStatus.HasMine)
                    { this.plaingField[i, j].OpenClose = CellStatus.Empty; }
                }
            }
        }

        public void IfWim()
        {
            int closeCell = 0;
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (this.plaingField[i,j].OpenClose==CellStatus.NotOpened&&this.plaingField[i,j].BombAround!=CellStatus.HasMine)
                    { closeCell++; }
                }
            }

            if (closeCell == 0)
            {
                this.win = true;
            }
        }
    }
}
