using System;

namespace Encapsulation.Valeriya
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        static Random rnd = new Random();

        public static void PrintQueue(PriorityQueue<int> queue)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue[i]);
            }
        }

        public void WorkPriorityQueue()
        {
            PriorityQueue<int> intPriorityQueue = new PriorityQueue<int>();
            int priorityTest;
            int valueTest;
            int inputIndexForTestLat;
            int inputIndexForTestFirst;
            int inputIndexForTestGetCount;
            intPriorityQueue.Add(0, rnd.Next(1, 100));
            intPriorityQueue.Add(1, rnd.Next(1, 100));
            intPriorityQueue.Add(1, rnd.Next(1, 100));
            intPriorityQueue.Add(3, rnd.Next(1, 100));
            intPriorityQueue.Add(5, rnd.Next(1, 100));
            intPriorityQueue.Add(5, rnd.Next(1, 100));
            intPriorityQueue.Add(6, rnd.Next(1, 100));
            intPriorityQueue.Add(7, rnd.Next(1, 100));
            intPriorityQueue.Add(8, rnd.Next(1, 100));
            intPriorityQueue.Add(8, rnd.Next(1, 100));
            intPriorityQueue.Add(8, rnd.Next(1, 100));
            PrintQueue(intPriorityQueue);

            try
            {
                Console.WriteLine("Count of elems = {0}", intPriorityQueue.Count);

                Console.WriteLine("Enter priority to find last elem");
                Int32.TryParse(Console.ReadLine(), out inputIndexForTestLat);
                Console.WriteLine("The last elem is {0}", intPriorityQueue.Last(inputIndexForTestLat));

                Console.WriteLine("Enter priority to find first elem");
                Int32.TryParse(Console.ReadLine(), out inputIndexForTestFirst);
                Console.WriteLine("The first elem is {0}", intPriorityQueue.First(inputIndexForTestFirst));

                Console.WriteLine("Enter priority to find count elems");
                Int32.TryParse(Console.ReadLine(), out inputIndexForTestGetCount);
                Console.WriteLine("Count of elems with priority {0} is {1}", inputIndexForTestGetCount, intPriorityQueue.GetCount(inputIndexForTestFirst));

                Console.WriteLine("The element {0} dequeued", intPriorityQueue.Dequeue());
                PrintQueue(intPriorityQueue);

                Console.WriteLine("Enter the element<priority, value> to push");
                Int32.TryParse(Console.ReadLine(), out priorityTest);
                Int32.TryParse(Console.ReadLine(), out valueTest);
                intPriorityQueue.Enqueue(valueTest, priorityTest);
                PrintQueue(intPriorityQueue);
            }
            catch (EmptyQueueException e)
            {
                Console.WriteLine("Error: The queue is empty", e.Message);
            }

            Console.ReadKey();
        }

        public void MoneyMoney()
        {
            Money m = new Money(1018);
            Money m1 = new Money(26,56);
            Money m2 = new Money(1, 58);
            Money m3 = m1 + m2;
            //Console.WriteLine("string: {0}", m1.ToString());
            //Console.WriteLine("int: {0}", (int)m1);
            //Console.WriteLine("float: {0}", (float)m1);
            //Console.WriteLine(m3);
            //Console.WriteLine("------------SquarredMatrix------------");
            SquarredMatrix matrix1 = new SquarredMatrix(3);
            SquarredMatrix matrix2 = new SquarredMatrix(3);
            SquarredMatrix matrix3 = matrix1 + matrix2;
            SquarredMatrix.PrintMatrix(matrix1);
            SquarredMatrix.PrintMatrix(matrix2);
            SquarredMatrix.PrintMatrix(matrix3);
            Console.ReadKey();
        }


        public void WorkCollectionInheritedClasses()
        {
            MyDictionary students = new MyDictionary();
            students.Add(new Student("Name", "Surname", new DateTime(2015, 9, 8), 100000000));
            Tuple<string, string, DateTime, int> key = Tuple.Create("Name", "Surname", new DateTime(2015, 9, 8), 100000000);
            if (students.Contains(key))
            {
                Console.WriteLine("Succeed");
            }

            Console.ReadKey();
        }
    }
}
