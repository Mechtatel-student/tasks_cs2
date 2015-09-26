using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class Money
    {
        private int kopeiky;
        public int Hrivnas
        {
            get { return kopeiky / 100; }
        }
        public int Kopeyki
        {
            get { return kopeiky % 100; }

        }
        public Money(int hrivnas, int kopeiky)
        {
            this.kopeiky = hrivnas * 100 + kopeiky;
        }

        public Money(int kopeiky)
        {
            this.kopeiky = kopeiky;
        }
        public Money(): this(0)
        {
        }

        public static Money operator+ (Money operand1, Money operand2)
        {
            return new Money(operand1.kopeiky + operand2.kopeiky);
        }

        public static Money operator* (Money operand1, int operand2)
        {
            return new Money(operand1.kopeiky * operand2);
        }

        public static Money operator* (int operand1, Money operand2)
        {
            return new Money(operand2.kopeiky * operand1);
        }

        public static Money operator- (Money operand1, Money operand2)
        {
            return new Money(operand1.kopeiky - operand2.kopeiky);
        }

        public static Money operator/ (int operand1, Money operand2)
        {
            return new Money(operand2.kopeiky / operand1);
        }

        public static bool operator!= (Money operand1, Money operand2)
        {
            return operand1.kopeiky != operand2.kopeiky;
        }

        public static bool operator== (Money operand1, Money operand2)
        {
           return operand1.kopeiky == operand2.kopeiky;
        }

        public static bool operator> (Money operand1, Money operand2)
        {
            return operand1.kopeiky > operand2.kopeiky;
        }

        public static bool operator< (Money operand1, Money operand2)
        {
            return operand1.kopeiky < operand2.kopeiky;
        }

        public static bool operator>= (Money operand1, Money operand2)
        {
            return operand1.kopeiky >= operand2.kopeiky;
        }

        public static bool operator<= (Money operand1, Money operand2)
        {
            return operand1.Kopeyki <= operand2.Kopeyki;
        }

        public override string ToString()
        {
            return string.Format("Your sum is {0} kopecs", kopeiky);
        }

        public static explicit operator int (Money operand)
        {
            int kopecs = operand.kopeiky;
            return kopecs;
        }

        public static explicit operator float (Money operand)
        {
            float kopecs = operand.kopeiky;
            return kopecs;
        }
    }
}
