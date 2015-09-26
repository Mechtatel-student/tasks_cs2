using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                IEncapsulationExercises exercises = null;
                switch (args[0])
                {
                    case "Alina":
                        exercises = new Alina.EncapsulationExercises();
                        break;
                    case "Andrey":
                        exercises = new Andrey.EncapsulationExercises();
                        break;
                    case "Elena":
                        exercises = new Elena.EncapsulationExercises();
                        break;
                    case "Konstantin":
                        exercises = new Konstantin.EncapsulationExercises();
                        break;
                    case "Valeriya":
                        exercises = new Valeriya.EncapsulationExercises();
                        break;
                    case "Vladimir":
                        exercises = new Vladimir.EncapsulationExercises();
                        break;
                    case "MatrixExample":
                        MatrixExample.MatrixExample.Do();
                        break;
                    default:
                        Console.WriteLine("Wrong argument. Choose one of: Alina, Andrey, Elena, Konstantin, Valeriya, Vladimir, MatrixExample");
                        break;
                }
                if (exercises != null)
                {
                   
                    exercises.MoneyMoney();
                    exercises.WorkPriorityQueue();
                    exercises.WorkCollectionInheritedClasses();
                }
            }
        }
    }
}
