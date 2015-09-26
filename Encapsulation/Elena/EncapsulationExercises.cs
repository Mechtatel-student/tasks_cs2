using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m1 = new Money();
            Money m2 = new Money(25,51);
            Money m3 = new Money(768);

            int hrivnas = m1.Hrivnas;
            int kopecks = m1.Kopeks;

            Money m4 = m1 + m3;
            int totalKopecs = (int)m2;
            float someMoney = (float)m2;
            string amount = (string)m2;

            ComplexNumber c1 = new ComplexNumber(2,3);
            ComplexNumber c2 = new ComplexNumber(-8, 5);

            ComplexNumber c3 = c1 + c2;
            c3 = c1 - c2;
            c3 = c1 * 2;
            c3 = c1 * c2;
            c3=c1/4;
            c3 = c1 / c2;
            string complexNumber = (string)c2;


        }

 
        public void WorkPriorityQueue()
        {
            Queue<string> q = new Queue<string>();
            PriorityQueue<string> pq = new PriorityQueue<string>(0, q);
            pq.OurSetWhithData = new SortedSet<PriorityQueue<string>>(new SortQueueByPriority());
            pq.Enqueue("Hi!", 2);
            pq.Enqueue("WTF?", 2);
            pq.Enqueue("Hello!", 1);
            pq.Enqueue("W", 2);
            pq.Enqueue("88", 1);

            string first = pq.First();

            string last = pq.Last();
            int count = pq.Count;
            int countPriority = pq.GetCount(2);
            pq.Clear();

        }


        public void WorkCollectionInheritedClasses()
        {
            MyDictionary dic = new MyDictionary();
            dic.Add(new Student() { FirstName = "Ivan", LastName = "Ivanov", ApplicationDate = new DateTime(2015, 01, 01), personalCode = 2012365566, Rating = 5, BirthDay = new DateTime(1990, 01, 05) });
            dic.Add(new Student() { FirstName = "Stanislav", LastName = "Sidorov", ApplicationDate = new DateTime(2010, 11, 22), personalCode = 265000041, Rating = 3, BirthDay = new DateTime(1970, 08, 15) });
            dic.Add(new Student() { FirstName = "Victoriya", LastName = "Stashatova", ApplicationDate = new DateTime(2014, 08, 21), personalCode = 2012445566, Rating = 5, BirthDay = new DateTime(1978, 09, 17) });
            Student serch = dic[new Tuple<string, string, DateTime, int>("Stanislav", "Sidorov", new DateTime(1970, 08, 15), 265000041)];

            MyCollection collection = new MyCollection();
            collection.Add(new Student() { FirstName = "Ivan", LastName = "Ivanov", ApplicationDate = new DateTime(2015, 01, 01), personalCode = 2012365566, Rating = 5, BirthDay = new DateTime(1990, 01, 05) });
            collection.Add(new Student() { FirstName = "Stanislav", LastName = "Sidorov", ApplicationDate = new DateTime(2010, 11, 22), personalCode = 265000041, Rating = 3, BirthDay = new DateTime(1970, 08, 15) });
            collection.Add(new Student() { FirstName = "Victoriya", LastName = "Stashatova", ApplicationDate = new DateTime(2014, 08, 21), personalCode = 2012445566, Rating = 5, BirthDay = new DateTime(1978, 09, 17) });

            collection.Insert(2, new Student() { FirstName = "Angelina", LastName = "Kucherova", ApplicationDate = new DateTime(2014, 12, 01), personalCode = 222025566, Rating = 4, BirthDay = new DateTime(1984, 12, 30) });
            collection.Remove(new Student(){FirstName = "Ivan", LastName = "Ivanov", ApplicationDate = new DateTime(2015, 01, 01), personalCode = 2012365566, Rating = 5, BirthDay = new DateTime(1990, 01, 05)});
           // collection. .Set(2, new Student() { FirstName = "Sergey", LastName = "Kuprin", ApplicationDate = new DateTime(2013, 12, 08), personalCode = 6545566, Rating = 1, BirthDay = new DateTime(1987, 02, 15) });
            collection.Clear();
        }

        class SortQueueByPriority : IComparer<PriorityQueue<string>>
        {

            public int Compare(PriorityQueue<string> pq1, PriorityQueue<string> pq2)
            {
                int resultOfCompare = 0;
                if (pq1.Priority > pq2.Priority)
                { resultOfCompare = 1; }
                if (pq1.Priority < pq2.Priority)
                { resultOfCompare = -1; }
                return resultOfCompare;
            }


        }
    }
}
