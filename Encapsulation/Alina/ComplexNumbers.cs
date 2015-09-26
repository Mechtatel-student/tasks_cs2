using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class ComplexNumbers
    {
        double real;
        double imaginary;
        public ComplexNumbers(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        double Real { get { return real; } }
        double Imaginary { get { return imaginary; } }
        public static ComplexNumbers operator +(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            return new ComplexNumbers(operand1.real + operand2.real, operand2.imaginary + operand2.imaginary);
        }
        public static ComplexNumbers operator -(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            return new ComplexNumbers(operand1.real - operand2.real, operand2.imaginary - operand2.imaginary);
        }
        public static ComplexNumbers operator *(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            return new ComplexNumbers((operand1.real * operand2.real - operand1.imaginary * operand2.imaginary), (operand1.real * operand2.imaginary + operand1.imaginary * operand2.real));
        }
        public static ComplexNumbers operator *(ComplexNumbers operand1, int coefficient)
        {
            return new ComplexNumbers(operand1.real * coefficient, operand1.imaginary * coefficient);
        }
        public static ComplexNumbers operator /(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            return new ComplexNumbers((operand1.real * operand2.real + operand1.imaginary * operand2.imaginary) / (operand2.imaginary * operand2.imaginary + operand2.real * operand2.real),
                (operand1.imaginary * operand2.real - operand1.real * operand2.imaginary) / (operand2.imaginary * operand2.imaginary + operand2.real * operand2.real));
        }
        public static ComplexNumbers operator /(ComplexNumbers operand1, int denominator)
        {
            return new ComplexNumbers(operand1.real / denominator, operand1.imaginary / denominator);
        }
        public static bool operator ==(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            bool isSame = false;
            if (operand1.real == operand2.real && operand1.imaginary == operand2.imaginary)
            {
                isSame = true;
            }
            return isSame;
        }
        public static bool operator !=(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            bool isSame = false;
            if (operand1.real != operand2.real || operand1.imaginary == operand2.imaginary)
            {
                isSame = true;
            }
            return isSame;
        }
        public override string ToString()
        {
            return String.Format("{0} + {1}i", Real, Imaginary);
        }
    }
}
