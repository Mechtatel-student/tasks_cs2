using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryKonstantin.KindOfAnimal
{
    class Bird : AnimalInClinic
    {
        public Bird() : base() { }
        public Bird(string name, int birthYear, double weight, string anamnesis) : base(name, birthYear, weight,anamnesis) { }
        public override void ExaminationReaction()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bird can fly out the doctor");
            Console.ResetColor();
        }
        
    }
}
