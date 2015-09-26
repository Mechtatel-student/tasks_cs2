using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryKonstantin.KindOfAnimal
{
    class Hamster : AnimalInClinic
    {
        public Hamster() : base() { }
        public Hamster(string name, int birthYear, double weight, string anamnesis) : base(name, birthYear, weight,anamnesis) { } 
        public override void ExaminationReaction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hamster can run away from the doctor");
            Console.ResetColor();
        }
    }
}
