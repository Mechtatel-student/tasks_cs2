using System;

namespace VeterinaryValeriya
{
    class Fish: DomesticAnimal
    {
        public Fish(string name, int age) : base(name, age)
        {
            Name = name;
            Age = age;
        }

        public override void ExamReaction()
        {
            Console.WriteLine("Fish {0} has slipped:(", Name);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, Type: {2}", Name, Age, TypeOfAnimal.Fish.ToString());
        }
    }
}
