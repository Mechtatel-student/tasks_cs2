using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Vladimir
{
    class MinerGameFactory : IMinerGameFactory
    {
        public IMinerGame NewEmptyGame(string playerName, Tuple<int, int> rowsCols)
        {
            MinerGame game = new MinerGame(rowsCols);
            return game;
        }

        public IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs)
        {
            MinerGame game = new MinerGame(rowsCols);

            // установка бомб
            Random rand = new Random();
            while (game.CountBomb < bombs)
            {
                game.SetBomb(rand.Next(0, rowsCols.Item1 - 1), rand.Next(0, rowsCols.Item2 - 1));
            }
            game.SetCanMakeBomb(false);

            return game;
        }

        internal void Test()
        {
            do
            {
                int row = 5;  // размеры поля   row = 5;
                int col = 4;  //                col = 4;
                int i = 0;    // координаты открываемой клетки
                int j = 0;

                IMinerGame game = NewRandomGame("Vladimir", new Tuple<int, int>(row, col), 8);
                game.Start();

                Console.Clear();
                Console.SetCursorPosition(0, 0);

                do
                {  
                    Console.Write("Введите, пожалуйста, координату I (целое число от 1 до {0}): ", row);
                    while (!int.TryParse(Console.ReadLine(), out i) || i > row || i<1)
                    {
                        Console.Write("Попробуйте еще раз. Число должно быть целым от 1 до (включительно) {0}: ", row);
                    }

                    Console.Write("Введите, пожалуйста, координату J (целое число от 1 до {0}): ", col);
                    while (!int.TryParse(Console.ReadLine(), out j) || j > col || j < 1)
                    {
                        Console.Write("Попробуйте еще раз. Число должно быть целым от 1 до (включительно) {0}: ", col);
                    }

                    game.OpenCell(i-1,j-1);

                    PrintPole(game);
                }
                while (game.Win != true && game.Lose != true);
                if (game.Win)
                {
                    Console.WriteLine("Будьте здоровы! Вы выиграли!");
                }
                else if (game.Lose)
                {
                    Console.WriteLine("Попробуйте снова. Увы, этот сет Вы проиграли");
                }

                Console.WriteLine("Для выхода нажмите Escape; для продолжения - любую другую клавишу");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        void PrintPole(IMinerGame game)
        {
            for (int poleRow = 0; poleRow < game.Height; poleRow++)
            {
                for (int poleCol = 0; poleCol < game.Width; poleCol++)
                {
                    switch (game[poleRow, poleCol])
                    {
                        case CellStatus.NotOpened:   Console.Write("-");
                            break;
                        case CellStatus.Empty:       Console.Write("0");  // открывать все с нулевым весом! 
                            break;
                        case CellStatus.OneAround:   Console.Write("1");
                            break;
                        case CellStatus.TwoAround:   Console.Write("2");
                            break;
                        case CellStatus.ThreeAround: Console.Write("3");
                            break;
                        case CellStatus.FourAround:  Console.Write("4");
                            break;
                        case CellStatus.FiveAround:  Console.Write("5");
                            break;
                        case CellStatus.SixAround:   Console.Write("6");
                            break;
                        case CellStatus.SevenAround: Console.Write("7");
                            break;
                        case CellStatus.EightAround: Console.Write("8");
                            break;
                        case CellStatus.HasMine:     Console.Write("M");
                            break;
                        default: Console.Write("что-то не то");
                            break;
                    } 
                } Console.WriteLine();
            }
        }

        void IMinerGameFactory.Test()
        {
            throw new NotImplementedException();
        }

  }
}
