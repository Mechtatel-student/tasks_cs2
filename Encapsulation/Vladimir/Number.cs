using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Vladimir
{
    class Number
    {
        public static void Test()
        {
            Money m = new Money(1018);
            Money m1 = new Money(25, 51);
            Money m2 = new Money(1, 58);

            Money m3 = m1 + m2;
            Money m4 = m1 - m2;

            Money m5 = m1 * 2;
            Money m6 = 2 * m1;
            Money m7 = m1 / 2;

            Money m8 = new Money((float)25.51);

            bool m9 = m3 > m2;
            bool m10 = m1 < m2;

            int hrivnas = m1.Hrivnas;
            int kopecks = m1.Kopecks;

            int totalKopecks = (int)m1;
            float someMoney = (float)m1;
            string amount = (string)m1;

            Console.WriteLine("m=  {0}", m);
            Console.WriteLine("m1= {0}", m1);
            Console.WriteLine("m2= {0}", m2);
            Console.WriteLine("m3= {0}", m3);
            Console.WriteLine("m4= {0}", m4);
            Console.WriteLine("m5= {0}", m5);
            Console.WriteLine("m6= {0}", m6);
            Console.WriteLine("m7= {0}", m7);
            Console.WriteLine("m8= {0}", m8);
            Console.WriteLine("m9= {0}", m9);
            Console.WriteLine("m10={0}", m10);
            Console.WriteLine("totalKopecks= {0}", totalKopecks);
            Console.WriteLine("someMoney= {0}", someMoney);
            Console.WriteLine("amount= {0}", amount);

            Console.ReadKey();
            //-------------------------------------

            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, 1);
            Complex totalC = c1 + c2;
            Complex differenceС = c1 - c2;
            Complex multiC = c1 * c2;
            Complex divC = c1 / c2;

            Console.WriteLine();
            Console.WriteLine("c1= {0}", c1);
            Console.WriteLine("totalC= {0}", totalC);
            Console.WriteLine("differenceС= {0}", differenceС);
            Console.WriteLine("multiC= {0}", multiC);
            Console.WriteLine("divC= {0}", divC);

            Console.WriteLine("c1= {0}", c1);
            c1.ViewTrigonom = true;
            Console.WriteLine("c1= {0}", c1);

            Console.ReadKey();
            //-----------------------------

            
        }
    }
}




