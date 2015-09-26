using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryKonstantin
{
    class Dog : AnimalInClinic
    {
        public Dog() : base() { }
        public Dog(string name, int birthYear, double weight, string anamnesis) : base(name, birthYear, weight,anamnesis) { } 
        public override void ExaminationReaction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Dog can bite the doctor");
            Console.ResetColor();
        }
    }
}
