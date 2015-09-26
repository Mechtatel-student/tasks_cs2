using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    enum TypeOfAnimal
    {
        Cat,
        Dog,
        Hamsted,
        Fish,
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClinicRegistry AnimalRegistry = new ClinicRegistry();

            Console.WriteLine("[H] About company\n[R] Put new animal in clinic\n[E]Examinate animal\n[L] Show list of animals\n[D] Discharge animal\n[Q] Quit\n");
            string menuChoise = "";

            do
            {
                menuChoise = Console.ReadLine();

                if (menuChoise.ToUpper() == "H")
                {
                    Console.WriteLine("This is veterinary clinic for domestic animals:)");
                }
                else if (menuChoise.ToUpper() == "R")
                {
                    Console.WriteLine("Input animal name:");
                    string nameOfAnimal = Console.ReadLine();
                    Console.WriteLine("\nPlease, input age of animal");
                    int ageOfAnimal;
                    Int32.TryParse(Console.ReadLine(), out ageOfAnimal);
                    int inputTypeOfanimal;
                    Console.WriteLine("Input type of animal from the list below:\n");
                    PrintEnumOfAnimalTypes();
                    Int32.TryParse(Console.ReadLine(), out inputTypeOfanimal);
                    DomesticAnimal newAnimal = null;
                    switch (inputTypeOfanimal)
                    {
                        case 0:
                            newAnimal = new Cat(nameOfAnimal, ageOfAnimal);
                            break;
                        case 1:
                            newAnimal = new Dog(nameOfAnimal, ageOfAnimal);
                            break;
                        case 2:
                            newAnimal = new Hamsted(nameOfAnimal, ageOfAnimal);
                            break;
                        case 3:
                            newAnimal = new Fish(nameOfAnimal, ageOfAnimal);
                            break;
                        default:
                            Console.WriteLine("Unfortunately, our clinic doesn't take care of such animals");
                            break;
                    }
                    
                    AnimalRegistry.AddAnimal(newAnimal);
                }
                else if (menuChoise.ToUpper() == "E")
                {
                    for (int i = 0; i < AnimalRegistry.Count; i++)
                    {
                        AnimalRegistry[i].ExamReaction();
                    }
                }
                else if (menuChoise.ToUpper() == "L")
                {
                    PrintListOfAnimals(AnimalRegistry);
                }
                else if (menuChoise.ToUpper() == "D")
                {
                    Console.WriteLine("Input number of animal:");
                    int number;
                    Int32.TryParse(Console.ReadLine(), out number);
                    AnimalRegistry.RemoveAnimal(number);
                }
            } while (menuChoise.ToUpper() != "Q");

            Environment.Exit(0);
            Console.ReadKey();
        }

        static void PrintListOfAnimals (ClinicRegistry inputRegistry)
        {
            Console.WriteLine("\n-----List of animals-----");
            for (int i = 0; i < inputRegistry.Count; i++)
            {
                Console.WriteLine(inputRegistry[i].ToString());
            }
        }

        static void PrintEnumOfAnimalTypes()
        {
            Console.WriteLine("<0> for {0}", TypeOfAnimal.Cat.ToString());
            Console.WriteLine("<1> for {0}", TypeOfAnimal.Dog.ToString());
            Console.WriteLine("<2> for {0}", TypeOfAnimal.Hamsted.ToString());
            Console.WriteLine("<3> for {0}", TypeOfAnimal.Fish.ToString());
            Console.WriteLine();
        }
    }
}
