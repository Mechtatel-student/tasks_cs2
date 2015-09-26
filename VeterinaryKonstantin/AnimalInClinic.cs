using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryKonstantin
{
    abstract class AnimalInClinic
    {
        private static int counter = 0;

        public string Name { get; private set; }
        public int BirthYear { get; private set; }
        public double Weight { get; private set; }
        public string HPI { get; private set; } //History of the present illness
        public DateTime ReceiptDate { get; private set; }
        public DateTime OutDate { get; private set; }
        public bool IsInClinic { get; private set; }
        public int Identifier { get; private set; }
        private List<string> personalCard = new List<string>();
        
        public AnimalInClinic()
        {
            Name = null; BirthYear = 0; Weight = 0; HPI = null; ReceiptDate = DateTime.Now; OutDate = new DateTime(); IsInClinic = true;
            Identifier = counter;
            counter++;
        }
        public AnimalInClinic(string name, int birthYear, double weight, string anamnesis)
            : this()
        {
            Name = name; 
            BirthYear = birthYear; 
            Weight = weight;
            personalCard.Add(anamnesis);
        }
        public void HPIInsert(string textHPI)
        {
            HPI = textHPI;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetBirthYear(int birthYear)
        {
            BirthYear = birthYear;
        }
        public void DischargeAnimal()
        {
            if (IsInClinic)
	        {
		        IsInClinic = false;
                OutDate = DateTime.Now;
                personalCard.Add(HPI);
	        }
            
        }
        public abstract void ExaminationReaction();

    }
}
