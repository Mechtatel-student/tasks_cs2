using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Elena
{
    class MinerGameFactory : IMinerGameFactory
    {
        public IMinerGame NewEmptyGame(string playerName, Tuple<int, int> rowsCols)
        {

            MinerGame game = new MinerGame(rowsCols.Item1, rowsCols.Item2);

            return game;
        }

        public IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs)
        {
            MinerGame game = new MinerGame(rowsCols.Item1, rowsCols.Item2, bombs);

            game.Start();

            return game;
        }

        internal void Test()
        {
            int rows;
            int cols;
            int bombs;
            Console.WriteLine("Hello!\n Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter count of rows");
            while (!Int32.TryParse(Console.ReadLine(), out rows) && (rows < 0))
            { Console.WriteLine("You enter not correct number. Please, enter number"); }

            Console.WriteLine("Enter count of colums");
            while (!Int32.TryParse(Console.ReadLine(), out cols) && (cols < 0))
            { Console.WriteLine("You enter not correct number. Please, enter number"); }

            Console.WriteLine("Enter count of bombs");
            while (!Int32.TryParse(Console.ReadLine(), out bombs) && (bombs < 0))
            { Console.WriteLine("You enter not correct number. Please, enter number"); }

            MinerGame game = new MinerGame(rows, cols, bombs);
            game.Start();

            Console.WriteLine("Youre game is starting");

            PrintField(game);

            
            while (!game.Lose && game.IsGameStarted)
            {
                Console.WriteLine("Enter row");
                while (!Int32.TryParse(Console.ReadLine(), out rows) && (rows < 0))
                { Console.WriteLine("You enter not correct number. Please, enter number"); }

                Console.WriteLine("Enter  colum");
                while (!Int32.TryParse(Console.ReadLine(), out cols) && (cols < 0))
                { Console.WriteLine("You enter not correct number. Please, enter number"); }

                if (game.chengeStatusCells(rows, cols))
                {
                    game.IfWim();
                    if (game.Win)
                    { Console.WriteLine("You win!!!!!!"); }
                    PrintField(game);
                }
                else
                { Console.WriteLine("You entered wrong data"); }
            }

        }


        void IMinerGameFactory.Test()
        {
            throw new NotImplementedException();
        }

        public void PrintField(MinerGame mg)
        {
            Tuple<int, char> resultCellStatus;
            Console.Write("+");
            for (int p = 0; p < mg.Width * 2 - 1; p++)
            { Console.Write("-"); }
            Console.Write("+");
            Console.WriteLine();
            for (int i = 0; i < mg.Height; i++)
            {
                Console.Write("|");
                for (int j = 0; j < mg.Width; j++)
                {
                    resultCellStatus = mg.getFieldsCells(i, j);
                    if (resultCellStatus.Item2 == 'X' && resultCellStatus.Item1 != -1)
                    {
                        Console.Write("{0}|", resultCellStatus.Item2);
                      
                        mg.IfLose();
                        break;
                    }

                    else
                    {
                        if (resultCellStatus.Item1 == -1)
                        {
                            Console.Write(" |");
                        }

                        else
                       {

                           Console.Write("{0}|", resultCellStatus.Item2);

                        }
                    }
            

                }



                Console.WriteLine();
                Console.Write("+");
                for (int p = 0; p < mg.Width * 2 - 1; p++)
                { Console.Write("-"); }
                Console.Write("+");
                Console.WriteLine();
            }
        }
    }

    }

