using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    class Money
    {
        private int kopecks;

        public Money(){ }

        public Money(int amountInKopecks)
        {
            //if(amountInKopecks>0)
            kopecks = amountInKopecks;
        }

        public Money(int countCurrencyUnit, int countKopecks)
        {
            if (countKopecks > 0 && countKopecks < 100)
            {
                kopecks = countCurrencyUnit * 100 + countKopecks;
            }
        }

        public int Hrivnas
        {
            get {return kopecks / 100; }
        }

        public int Kopeks
        {
            get {return kopecks % 100; }
        }

        public static Money operator +(Money operand1, Money operand2)
        {
            return new Money(operand1.kopecks + operand2.kopecks);
        }

        public static Money operator *(int multiplier, Money operand)
        {
            return new Money(operand.kopecks*multiplier);
        }

        public static Money operator /(int div, Money operand)
        {
            return new Money(operand.kopecks / div);
        }

        public static bool operator==(Money operand1, Money operand2)
        {
            bool returValue=false;
            if (operand1.kopecks == operand2.kopecks)
            { returValue= true; }

            return returValue;
        }

        public static bool operator !=(Money operand1, Money operand2)
        {
            bool returValue = false;
            if (operand1.kopecks != operand2.kopecks)
            { returValue= true; }
            return returValue;
        }

        public static bool operator<(Money operand1, Money operand2)
        {
             bool returValue=false;
            if(operand1.kopecks<operand2.kopecks)
            {returValue=true;}
            return returValue;
        }

        public static bool operator >(Money operand1, Money operand2)
        {
            bool returValue = false;
            if (operand1.kopecks > operand2.kopecks)
            { returValue = true; }
            return returValue;
        }

        public static bool operator <=(Money operand1, Money operand2)
        {
            bool returValue = false;
            if (operand1.kopecks <= operand2.kopecks)
            { returValue = true; }
            return returValue;
        }

        public static bool operator >=(Money operand1, Money operand2)
        {
            bool returValue = false;
            if (operand1.kopecks >= operand2.kopecks)
            { returValue = true; }
            return returValue;
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
            return String.Format("{0} грн. {1} коп.", operand1.Hrivnas, operand1.Kopeks);
        }


    }
}
