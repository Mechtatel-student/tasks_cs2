using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryKonstantin.KindOfAnimal;

namespace VeterinaryKonstantin
{
    
    class Veterinary : IVeterinary
    {

        private class AnimalDictionary : KeyedCollection<int, AnimalInClinic>
        {
            protected override int GetKeyForItem(AnimalInClinic item)
            {
                return item.Identifier;
            }
        }
        private string aboutCompany = "Our company was founded... etc";
        private AnimalDictionary animalDictionary = new AnimalDictionary();
        public void AboutCompany()
        {
            Console.WriteLine(aboutCompany);
        }

        public void PutANewAnimalInClinic()
        {
            Console.WriteLine("Please write a kind of animal which puts in clinic (Dog, Cat, Bird, Hamster).");
           
            string animalKind;
            do
            {
                animalKind = (Console.ReadLine()).ToLower();
                switch (animalKind)
                {
                    case "dog":
                        animalDictionary.Add(new Dog());
                        break;
                    case "cat":
                        animalDictionary.Add(new Cat());
                        break;
                    case "bird":
                        animalDictionary.Add(new Bird());
                        break;
                    case "hamster":
                        animalDictionary.Add(new Hamster());
                        break;

                    default:
                        Console.WriteLine("Animal in clinic can be dog, cat, bird or hamster");
                        break;
                }
            } while (!(animalKind == "dog" || animalKind == "cat" || animalKind == "bird" || animalKind == "hamster"));
        }

        public void ShowListOfAnimals()
        {
            foreach (var animal in animalDictionary)
            {
                Console.WriteLine("{0}, identifier is a {1}, borned {2}", animal.Name, animal.Identifier, animal.BirthYear);
            }
        }

        public void DischargeAnimal()
        {
            int keyAnimal = -1;
            do
            {
                Console.WriteLine("Enter identifier for animal discharging.");

            } while (!Int32.TryParse(Console.ReadLine(), out keyAnimal)|| !animalDictionary.Contains(keyAnimal));

            animalDictionary[keyAnimal].DischargeAnimal();
            if (animalDictionary.Contains(keyAnimal))
            {
                Console.WriteLine("{0}, identifier is a {1}, borned {2}. Animal discharged", animalDictionary[keyAnimal].Name, animalDictionary[keyAnimal].Identifier, animalDictionary[keyAnimal].BirthYear);
            }
        }

        public void ExaminationInClinic()
        {
            foreach (var animal in animalDictionary)
            {
                Console.Write("Animal's identifier: {0}. ", animal.Identifier);
                animal.ExaminationReaction();
            }
        }
    }
}
