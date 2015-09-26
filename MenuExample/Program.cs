using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuExample
{
    enum DogBreed { Terier = 500, Dog = 3 };

    class Program
    {
        private static Menu mainMenu = new Menu(
                new Menu.ItemAction[] {
                    new Menu.ItemAction { Text = "Enter data", MyAction = Enter },
                    new Menu.ItemAction { Text = "Exit",       MyAction = null }
                }
            );

        private static Menu subMenuData = new Menu(
                new Menu.ItemIntCode[] {
                    new Menu.ItemIntCode { Code = (int)DogBreed.Terier, Text = "Terier breed" },
                    new Menu.ItemIntCode { Code = (int)DogBreed.Dog,    Text = "Dog breed" }
                }
            );

        private static void Enter()
        {
            Console.WriteLine("Entering data...");
            switch ((DogBreed)subMenuData.GetChoice())
            { 
                case DogBreed.Terier:
                    Console.WriteLine("Terier was chosen");
                    break;
                case DogBreed.Dog:
                    Console.WriteLine("Dog was chosen");
                    break;
                default:
                    throw new ApplicationException("Something wrong with data submenu choice");
                    break;
            }
        }

        static void Main(string[] args)
        {
            mainMenu.Show();
            Console.ReadKey(true);
        }
    }
}
