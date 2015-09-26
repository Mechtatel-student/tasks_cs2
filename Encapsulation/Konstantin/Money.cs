using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Konstantin
{
    class Money
    {
        private int kopecks = 0;

        public int Kopecks { get { return kopecks % 100; } }
        public int Hrivnas { get { return kopecks / 100; } }

        public Money() { }
        public Money(int kopecks)
        {
            this.kopecks = kopecks;
        }
        public Money(int grivnas, int kopecks)
            : this(kopecks)
        {
            this.kopecks += grivnas * 100;
        }

        public static Money operator +(Money operand1, Money operand2)
        {
            return new Money(operand1.kopecks + operand2.kopecks);
        }
        public static Money operator -(Money operand1, Money operand2)
        {
            return new Money(operand1.kopecks - operand2.kopecks);
        }
        public static Money operator *(Money operand1, int operand2)
        {
            return new Money(operand1.kopecks * operand2);
        }
        public static Money operator /(Money operand1, int operand2)
        {
            return new Money(operand1.kopecks / operand2);
        }
        public static bool operator ==(Money operand1, Money operand2)
        {
            return (operand1.kopecks == operand2.kopecks);
        }
        public static bool operator !=(Money operand1, Money operand2)
        {
            return (operand1.kopecks != operand2.kopecks);
        }
        public static bool operator >(Money operand1, Money operand2)
        {
            return (operand1.kopecks > operand2.kopecks);
        }
        public static bool operator >=(Money operand1, Money operand2)
        {
            return (operand1.kopecks >= operand2.kopecks);
        }
        public static bool operator <(Money operand1, Money operand2)
        {
            return (operand1.kopecks < operand2.kopecks);
        }
        public static bool operator <=(Money operand1, Money operand2)
        {
            return (operand1.kopecks <= operand2.kopecks); ;
        }

        public static implicit operator float(Money operand1)
        {
            return ((float)operand1.kopecks / 100);
        }

        public static implicit operator int(Money operand1)
        {
            return operand1.kopecks;
        }

        public static implicit operator string(Money operand1)
        {
            return String.Format("{0} hrivnas, {1} kopecks.", operand1.Hrivnas, operand1.Kopecks);
        }
        public override string ToString()
        {
            return (string)this;
        }
    }
}
