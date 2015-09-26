using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class ClinicRegistry
    {
        private static Dictionary<int, DomesticAnimal> registry = new Dictionary<int, DomesticAnimal>();

        private static int CreateID()
        {
            int count = registry.Count;
            return count++;
        }

        public void AddAnimal (DomesticAnimal animal)
        {
            registry.Add(CreateID(), animal);
        }

        public void RemoveAnimal (int ID)
        {
            registry.Remove(ID);
        }

        public int Count
        {
            get { return registry.Count; }
        }

        public DomesticAnimal this[int elem]
        {
            get { return registry[elem]; }
        }

        public ClinicRegistry()
        {
            
        }
    }
}
