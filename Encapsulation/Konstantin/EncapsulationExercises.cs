using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Konstantin
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m1 = new Money();
            Money m2 = new Money(25,51);
            Money m3 = new Money(1024);

            int hrivnas = m1.Hrivnas;
            int kopecks = m1.Kopecks;

            Money m4 = m1 + m3;
            int totalKopecs = (int)m2;
            float someMoney = (float)m2;
            string moneyString = (string)m2;
            string moneyString1 = m2.ToString();
        }


        public void WorkPriorityQueue()
        {
            throw new NotImplementedException();
        }


        public void WorkCollectionInheritedClasses()
        {
            MyDictionary studentsBase = new MyDictionary();
            
            Student st1 = new Student() {firstName = "1", lastName = "2", birthDate = new DateTime(12,12,2012) };
            Tuple<string, string, DateTime> st1Key = new Tuple<string, string, DateTime>("1", "2", new DateTime(12, 12, 2012));

            if (studentsBase.Contains(st1))
            {
                studentsBase.Add(st1);
                Student st1Copy = studentsBase[st1Key];
            }
            else
            {
                Console.WriteLine("Student is not found");
            }
            
        }
    }
}
