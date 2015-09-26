using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryKonstantin
{
    class Program
    {
        static void Main(string[] args)
        {
            IVeterinary veterenary = new Veterinary();
            string menuChoice = string.Empty;

            Console.WriteLine("[H] About company\n[R] Put new animal in clinic\n[L] Show list of animals\n[D] Discharge animal \n[E] Examination in clinic \n[Q] Quit\n");

            do
            {
                Console.WriteLine("Enter your choice please, it must be H, R, L, D, E or Q");
                menuChoice = (Console.ReadLine()).ToUpper();
                
                switch (menuChoice)
                {
                    case "H":
                        veterenary.AboutCompany();
                        break;
                    case "R":
                        veterenary.PutANewAnimalInClinic();
                        break;
                    case "L":
                        veterenary.ShowListOfAnimals();
                        break;
                    case "D":
                        veterenary.DischargeAnimal();
                        break;
                    case "E":
                        veterenary.ExaminationInClinic();
                        break;
                    default:
                        break;
                }
            } while (menuChoice!="Q");

            Console.ReadKey(true);
        }        
    }
}
