using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMinerGameFactory> factories = new List<IMinerGameFactory>();
            factories.Add(new Alina.MinerGameFactory());
            factories.Add(new Andrey.MinerGameFactory());
            factories.Add(new Elena.MinerGameFactory());
            factories.Add(new Konstantin.MinerGameFactory());
            factories.Add(new Valeriya.MinerGameFactory());
            factories.Add(new Vladimir.MinerGameFactory());

            if (args.Length > 0)
            {
                switch (args[0])
                { 
                    case "Alina":
                        new Alina.MinerGameFactory().Test();
                        break;
                    case "Andrey":
                        new Andrey.MinerGameFactory().Test();
                        break;
                    case "Elena":
                        new Elena.MinerGameFactory().Test();
                        break;
                    case "Konstantin":
                        new Konstantin.MinerGameFactory().Test();
                        break;
                    case "Valeriya":
                        new Valeriya.MinerGameFactory().Test();
                        break;
                    case "Vladimir":
                        new Vladimir.MinerGameFactory().Test();
                        break;
                    default:
                        Console.WriteLine("Wrong argument. Choose one of: Alina, Andrey, Elena, Konstantin, Valeriya, Vladimir");
                        break;
                }
            }
            else
            {
                foreach (var factory in factories)
                {
                    Console.WriteLine("Testing factory {0}...", factory.ToString());
                    try
                    {
                        /* empty game */
                        {
                            Console.WriteLine("Testing empty game...");
                            IMinerGame game = factory.NewEmptyGame("Dummy", new Tuple<int, int>(5, 6));
                            Assert(!game.IsGameStarted, "Game shouldn't be started yet");
                            Assert(game.Height == 5, "Высота не совпадает");
                            Assert(game.Width == 6, "Ширина не совпадает");
                        }

                        /* random game */
                        {
                            Console.WriteLine("Testing random game...");
                            IMinerGame game = factory.NewRandomGame("Dummy", new Tuple<int, int>(7, 8), 50);
                            Assert(!game.IsGameStarted, "Game shouldn't be started yet");
                            Assert(game.Height == 7, "Высота не совпадает");
                            Assert(game.Width == 8, "Ширина не совпадает");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    Console.WriteLine("Factory {0} done.", factory.ToString());
                }
            } // args
            Console.ReadKey();
        }

        static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine("ASSERTION FAILED: {0}", message);
            }
        }
    }
}
