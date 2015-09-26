using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Vladimir
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void WorkPriorityQueue()
        {
            //throw new NotImplementedException();
            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            testQueue.Enqueue(1, 0);
            testQueue.Enqueue(2, 0);
            testQueue.Enqueue(3, 0);
            testQueue.Enqueue(4, 0);
            testQueue.Enqueue(5, 0);

            testQueue.Enqueue(1, 2);
            testQueue.Enqueue(2, 2);
            testQueue.Enqueue(3, 3);
            testQueue.Enqueue(4, 3);
            testQueue.Enqueue(5, 5);

            Console.WriteLine();
            Console.WriteLine("First test {0}", testQueue.First());  // 1
            Console.WriteLine("Last test {0}", testQueue.Last());    // 5

            Console.WriteLine("First test {0} с приоритетом {1}", testQueue.First(2), 2);  //1
            Console.WriteLine("Last test {0} с приоритетом {1}", testQueue.Last(3), 3);    // 4

            int p1 = 0;
            Console.WriteLine("число элементов с приоритетом {0} = {1}", p1, testQueue.GetCount(p1));  //5
            p1 = 2;
            Console.WriteLine("число элементов с приоритетом {0} = {1}", p1, testQueue.GetCount(p1));  //2
            p1 = 5;
            Console.WriteLine("число элементов с приоритетом {0} = {1}", p1, testQueue.GetCount(p1));  //1

            Console.ReadKey();

        }

        public void MoneyMoney()
        {
            Number.Test();

        }


        public void WorkCollectionInheritedClasses()
        {
            //throw new NotImplementedException();
            Student student1 = new Student("Имя", "Фамилия", 11, new DateTime(1967, 1, 1), 1);
            Student student2 = new Student("Имя", "Фамилия", 22, new DateTime(1967, 1, 1), 2);
            Student student3 = new Student("Имя", "Фамилия", 33, new DateTime(1967, 1, 1), 3);
            Student student4 = new Student("Имя", "Фамилия", 44, new DateTime(1967, 1, 1), 4);

            MyDictionary groupForDictionary = new MyDictionary();
            groupForDictionary.Add(student1);
            groupForDictionary.Add(student2);
            groupForDictionary.Add(student3);
            groupForDictionary.Add(student4);

            Tuple<string, string, int, DateTime> workKey = Tuple.Create<string, string, int, DateTime>("Имя", "Фамилия", 22, new DateTime(1967, 1, 1));
            if (!groupForDictionary.Contains(workKey))
            {
                Console.WriteLine("Нет такого студента");
            }

            MyCollection<Student> groupForCollection = new MyCollection<Student>();
            groupForCollection.Add(student1);
            groupForCollection.Add(student3);

            Console.WriteLine("Студент 1,3");
            foreach (Student workStudent in groupForCollection)
            {
                Console.WriteLine("{0} {1} : {2}, {3}, {4} ", workStudent.firstName,
                                                              workStudent.secondName,
                                                              workStudent.birthDate,
                                                              workStudent.rating,
                                                              workStudent.personalCode);
            }

            groupForCollection.Insert(1, student2);
            groupForCollection.Remove(student1);
            groupForCollection.Add(student4);

            Console.WriteLine("+ Студент2, -Студент1,+ Студент4");
            foreach (Student workStudent in groupForCollection)
            {
                Console.WriteLine("{0} {1} : {2}, {3}, {4} ", workStudent.firstName,
                                                                  workStudent.secondName,
                                                                  workStudent.birthDate,
                                                                  workStudent.rating,
                                                                  workStudent.personalCode);
            }

            Console.ReadKey();

        }
    }
}
