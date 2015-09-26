using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    Console.WriteLine("Argument: {0}", args[0]);
                    switch (args[0])
                    {
                        case "Alina":
                            MainAlina();
                            break;
                        case "Elena":
                            MainElena();
                            break;
                        case "Vladimir":
                            MainVladimir();
                            break;
                        case "Konstantin":
                            MainKonstantin();
                            break;
                        case "Valeriya":
                            MainValeriya();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Not all code implemented. Problem: {0}", e.Message);
                Console.WriteLine("Details: {0}", e.ToString());
            }
        }

        static void MainAlina()
        {
            #region Observer
            #endregion
        }

        static void MainElena()
        {
            #region Observer
            #endregion
        }

        static void MainVladimir()
        {
            #region Observer
            #endregion
        }

        static void MainKonstantin()
        {
            #region Observer
            #endregion
        }
        static void MainValeriya()
        {
            #region Observer
            #endregion
        }
    }
}
