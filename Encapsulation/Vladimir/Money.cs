using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    class Money
    {
        public int Hrivnas
        {
            get
            {return hrivnas;}
        }

        public int Kopecks
        {
            get { return kopecks; }
        }

        private int kopecks;
        private int hrivnas;

        public Money()
        {
            hrivnas = 0;
            kopecks = 0;
        }
        
        public Money(int i)
        {
            hrivnas = i / 100;
            kopecks = i % 100;
        }
        
        public Money(float i)
        {
            hrivnas = (int) i ;
            kopecks =  (int) Math.Round((i-hrivnas)*100);
        }

        public Money(int i, int j)
        {
            hrivnas = i;
            kopecks = j;
        }

        public Money(Money m)
        {
            throw new NotImplementedException();
        }

        static public explicit operator int(Money operand1)
        {
            return operand1.Hrivnas*100+operand1.Kopecks; 
        }

        static public explicit operator float(Money operand1)
        {
            return (float)operand1.Hrivnas + (float)operand1.Kopecks/100;
        }


        static public explicit operator string(Money operand1)
        {
            return operand1.ToString();
        }

        public override string ToString()
        {
            return string.Format( "{0} грн. {1:00} коп.", hrivnas, kopecks);
        }


        public static Money operator+ (Money operand1, Money operand2)
        {
            return new Money( (int)operand1 + (int)operand2);
        }

        public static Money operator- (Money operand1, Money operand2)
        {
            return new Money((int)operand1 - (int)operand2);
        }

        public static Money operator* (int operand1, Money operand2)
        {
            return new Money(operand1*(int)operand2);
        }

        public static Money operator *(Money operand1, int operand2)
        {
            return new Money((int)operand1 * operand2);
        }
        
        public static Money operator /(Money operand1, float operand2)
        {
            return new Money((float)operand1 / operand2);
        }

        public static bool operator==(Money operand1, Money operand2)
        {
            return (int)operand1 == (int)operand2;
        }

        public static bool operator !=(Money operand1, Money operand2)
        {
            return (int)operand1 != (int)operand2;
        }

        public static bool operator <=(Money operand1, Money operand2)
        {
            return (int)operand1 <= (int)operand2;
        }

        public static bool operator >=(Money operand1, Money operand2)
        {
            return (int)operand1 >= (int)operand2;
        }

        public static bool operator <(Money operand1, Money operand2)
        {
            return (int)operand1 < (int)operand2;
        }

        public static bool operator >(Money operand1, Money operand2)
        {
            return (int)operand1 > (int)operand2;
        }

    }
}
