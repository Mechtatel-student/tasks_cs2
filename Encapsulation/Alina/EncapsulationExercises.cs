using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m1 = new Money(25, 51);
            Money m2 = new Money(1, 58);
            Money m3 = new Money(1005);
            int hrivnas = m1.Hrivnas;
            Console.WriteLine("{0} грн", hrivnas);
            int kopecs = m1.Kopeks;
            Console.WriteLine("{0} коп", kopecs);
            int hrivnas2 = m2.Hrivnas;
            Console.WriteLine("{0} грн", hrivnas2);
            int kopecs2 = m2.Kopeks;
            Console.WriteLine("{0} коп", kopecs2);
            int hrivnas3 = m3.Hrivnas;
            Console.WriteLine("{0} грн", hrivnas3);
            int kopecs3 = m3.Kopeks;
            Console.WriteLine("{0} коп", kopecs3);
            Money m4 = m2 + m3;
            Console.WriteLine(m4.ToString());
            Money m5 = m1 - m3;
            Console.WriteLine(m5.ToString());
            Money m6 = m1 * 2;
            Console.WriteLine(m6.ToString());
            Money m7 = m3 / 5;
            Console.WriteLine(m7.ToString());
            bool isMatrix1EqualMatrix2 = m1 == m2;
            Console.WriteLine(isMatrix1EqualMatrix2);
            bool isMatrix1NotEqualMatrix2 = m1 != m2;
            Console.WriteLine(isMatrix1NotEqualMatrix2);
            bool isMatrix1LargeMatrix2 = m1 > m2;
            Console.WriteLine(isMatrix1LargeMatrix2);
            bool isMatrix1LessMatrix2 = m1 < m2;
            Console.WriteLine(isMatrix1LessMatrix2);
            Money m12 = Money.Clone(m2);
            Console.WriteLine(m12);

            //------------------------------------------------------------------
            //          class Matrix

            int[,] myArr1 = new int[,]
            {
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
            };
            int[,] myArr2 = new int[,]
            {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1},
            };
            Matrix matrix1 = new Matrix(myArr1);
            Matrix matrix2 = new Matrix(myArr2);
            Matrix matrix3 = matrix1 + matrix2;
            Matrix matrix4 = matrix1 - matrix2;
            Matrix matrix5 = matrix1 * 5;
            Matrix.PrintMatrix(matrix1);
            Matrix.PrintMatrix(matrix3);
            Matrix.PrintMatrix(matrix5);

            //------------------------------------------------------------------
            //          class ComplexNumbers

            ComplexNumbers number1 = new ComplexNumbers(4, 8);
            ComplexNumbers number2 = new ComplexNumbers(3, 7);
            ComplexNumbers number3 = number1 + number2;
            ComplexNumbers number4 = number1 - number2;
            ComplexNumbers number5 = number1 * number2;
            ComplexNumbers number6 = number1 / number2;
            ComplexNumbers number7 = number1 * 2;
            ComplexNumbers number8 = number1 / 2;
            Console.WriteLine(number1);
            Console.WriteLine(number4);
            Console.WriteLine(number5);
            Console.WriteLine(number6);
            Console.WriteLine(number7);
            Console.WriteLine(number8);
            bool isNumber1EqualNumber2 = number1 == number2;
            bool isNumber1NotEqualNumber2 = number1 != number2;
            Console.WriteLine(isNumber1EqualNumber2);
            Console.WriteLine(isNumber1NotEqualNumber2);
            
            Console.ReadKey();

        }


        public void WorkPriorityQueue()
        {
            Student firstStudent = new Student("Alina", "Kylish", 123456789, new DateTime(1988, 4, 3));
            Student secondStudent = new Student("Elena", "Kylish", 987654321, new DateTime(1987, 8, 15));
            Student thirdStudent = new Student("Oleg", "Ivanov", 975312468, new DateTime(1992, 11, 20));
            Student fourthStudent = new Student("Andrey", "Pavlov", 1243576890, new DateTime(1977, 8, 10));
            PriorityQueue<Student> students = new PriorityQueue<Student>();
            students.Enqueue(firstStudent, 0);
            students.Enqueue(secondStudent, 1);
            students.Enqueue(thirdStudent, 2);
            students.Enqueue(fourthStudent, 0);
            Console.WriteLine(students.Count());
            Console.WriteLine(students.First());
            Console.WriteLine(students.Last());  
            students.Dequeue();
            Console.WriteLine(students.Count());
            Console.ReadKey();
            students.Clear();
            students.Dequeue(); // throw exeption with message "Queue is empty. There is no value in queue"
        }

        public void WorkCollectionInheritedClasses()
        {
            Student firstStudent = new Student("Alina", "Kylish", 123456789, new DateTime(1988, 4, 3));
            Student secondStudent = new Student("Elena", "Kylish", 987654321, new DateTime(1987, 8, 15));
            Student thirdStudent = new Student("Oleg", "Ivanov", 975312468, new DateTime(1992, 11, 20));
            MyDictionary students = new MyDictionary();
            Tuple<string, string, int> key = new Tuple<string,string,int>("Alina", "Kylish", 123456789);
            students.Add(firstStudent);
            if (!students.Contains(key))
            {
                Console.WriteLine("This key is not found");
            }
            else
            {
                Console.WriteLine("This key is found");      
            }

            MyCollection students1 = new MyCollection();
            students1.Add(firstStudent);
            students1.Add(secondStudent);
            students1.Insert(0, thirdStudent);
            students1.Add(firstStudent);
            students1.Remove(firstStudent);
            students1.Clear();
            Console.ReadKey();

        }
    }
}
