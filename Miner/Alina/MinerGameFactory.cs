using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Alina
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
            game = new MinerGame(playerName, rowsCols.Item1, rowsCols.Item2, bombs);
            return game;
        }

        internal void Test()
        {
            IMinerGame test = NewRandomGame("Alina", new Tuple<int, int>(10, 20), 50);
            PrintGame(test);
            test.Start();
            test.OpenCell(0, 0);
            PrintGame(test);
            test.OpenCell(7, 6);
            PrintGame(test);
            test.OpenCell(1, 2);
            PrintGame(test);
            test.OpenCell(8, 8);
            PrintGame(test);
            Console.ReadKey();
        }


        void IMinerGameFactory.Test()
        {
            throw new NotImplementedException();
        }
        void PrintGame(IMinerGame game)
        {
            Console.Clear();
            for (int row = 0; row < game.Height; row++)
            {
                for (int col = 0; col < game.Width; col++)
                {
                    switch (game[row, col])
                    {
                        case CellStatus.NotOpened: Console.Write("X");
                            break;
                        case CellStatus.Empty: Console.Write(" ");
                            break;
                        case CellStatus.OneAround: Console.Write("1");
                            break;
                        case CellStatus.TwoAround: Console.Write("2");
                            break;
                        case CellStatus.ThreeAround: Console.Write("3");
                            break;
                        case CellStatus.FourAround: Console.Write("4");
                            break;
                        case CellStatus.FiveAround: Console.Write("5");
                            break;
                        case CellStatus.SixAround: Console.Write("6");
                            break;
                        case CellStatus.SevenAround: Console.Write("7");
                            break;
                        case CellStatus.EightAround: Console.Write("8");
                            break;
                        case CellStatus.HasMine: Console.Write("@");
                            break;
                        default:
                            break;
                    }
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadKey();
        }
    }
}
