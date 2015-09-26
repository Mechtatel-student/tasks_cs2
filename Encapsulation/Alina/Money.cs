using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class Money
    {
        int kopeks;
        
        public int Hrivnas
        {
            get
            {
                return kopeks / 100;
            }
        }
        public int Kopeks
        {
            get
            {
                return kopeks%100;
            }
        }
        public int TotalKopeks
        {
            get { return kopeks; }
        }
        public Money()
        {

        }
        public Money(int kopeks)
            : this(0, kopeks)
        {

        }
        public Money(int hrivnas, int kopeks)
        {
            this.kopeks = hrivnas*100 + kopeks;
        }

        public static Money Clone (Money original)
        {
            return new Money(original.TotalKopeks);
        }
        public static Money operator + (Money operand1, Money operand2)
        {
            return new Money(operand1.kopeks + operand2.kopeks);
        }
        public static Money operator -(Money operand1, Money operand2)
        {
            return new Money(operand1.kopeks - operand2.kopeks);
        }
        public static Money operator * (Money operand1, int operand2)
        {
            return new Money(operand1.kopeks * operand2);
        }
        public static Money operator / (Money operand1, int operand2)
        {
            return new Money(operand1.kopeks / operand2);
        }
        public static bool operator ==  (Money operand1, Money operand2)
        {
            return operand1.kopeks == operand2.kopeks;
        }
        public static bool operator != (Money operand1, Money operand2)
        {
            return operand1.kopeks != operand2.kopeks;
        }
        public static bool operator > (Money operand1, Money operand2)
        {
            return operand1.kopeks > operand2.kopeks;
        }
        public static bool operator >= (Money operand1, Money operand2)
        {
            return operand1.kopeks >= operand2.kopeks;
        }
        public static bool operator < (Money operand1, Money operand2)
        {
            return operand1.kopeks < operand2.kopeks;
        }
        public static bool operator <= (Money operand1, Money operand2)
        {
            return operand1.kopeks <= operand2.kopeks;
        }

        public override string ToString()
        {
            return String.Format("{0} грн {1} коп", Hrivnas, Kopeks);
        }
    }
}
