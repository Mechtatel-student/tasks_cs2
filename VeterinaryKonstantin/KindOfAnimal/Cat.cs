using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryKonstantin.KindOfAnimal
{
    class Cat : AnimalInClinic
    {
        public Cat() : base() { }
        public Cat(string name, int birthYear, double weight, string anamnesis) : base(name, birthYear, weight, anamnesis) { }
        public override void ExaminationReaction()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Cat can scratch the doctor");
            Console.ResetColor();
        }
    }
}
