using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    class ComplexNumber
    {
        private float real;
        private float imegion;

        public ComplexNumber()
        {
            real=0;
            imegion=0;
        }

        public ComplexNumber(float r, float i)
        {
            real=r;
            imegion=i;
        }

        public float Real
        {
            get { return real; }
        }

        public float Imegion
        {
            get { return imegion; }
        }

        public static ComplexNumber operator+(ComplexNumber operand1, ComplexNumber operand2)
        {
            return new ComplexNumber(operand1.real + operand2.real, operand1.imegion + operand2.imegion);
        }

        public static ComplexNumber operator -(ComplexNumber operand1, ComplexNumber operand2)
        {
            return new ComplexNumber(operand1.real - operand2.real, operand1.imegion - operand2.imegion);
        }

        public static ComplexNumber operator *(ComplexNumber operand1, int multiplier)
        {
            return new ComplexNumber(operand1.real *multiplier, operand1.imegion*multiplier);
        }

        public static ComplexNumber operator *(ComplexNumber operand1, ComplexNumber operand2)
        {
            return new ComplexNumber((operand1.real * operand2.real-operand1.imegion*operand2.imegion), (operand1.imegion * operand2.real+operand1.imegion*operand2.imegion));
        }

        public static ComplexNumber operator /(ComplexNumber operand1, ComplexNumber operand2)
        {
            float real;
            float imegion;

            real = (operand1.real * operand2.real + operand1.imegion * operand2.imegion) / (operand2.imegion * operand2.imegion + operand2.real * operand2.real);
            imegion=(operand1.imegion*operand2.real-operand1.real*operand2.imegion)/ (operand2.imegion * operand2.imegion + operand2.real * operand2.real);
            return new ComplexNumber(real, imegion);
        }

        public static ComplexNumber operator /(ComplexNumber operand1, int div)
        {
            if (div != 0)
            {
                return new ComplexNumber(operand1.real / div, operand1.imegion / div);
            }
            else { return null; }
        }

        public static bool operator ==(ComplexNumber operand1, ComplexNumber operand2)
        {
            bool returnValue = false;
            if (operand1.real == operand2.real && operand1.imegion == operand2.imegion)
            { returnValue = true; }
            return returnValue;
        }

        public static bool operator !=(ComplexNumber operand1, ComplexNumber operand2)
        {
            bool returnValue = false;
            if (operand1.real != operand2.real && operand1.imegion != operand2.imegion)
            { returnValue = true; }
            return returnValue;
        }

        public static implicit operator string(ComplexNumber operand1)
        {
            return String.Format("{0}+{1}i",operand1.Real,operand1.imegion);
        }
    }
}
