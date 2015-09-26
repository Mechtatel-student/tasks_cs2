using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Konstantin
{
    class ComplexNumber
    {
        public double Real { get; private set;}
        public double Imaginary { get; private set; }
        public double Magnitude 
        {
            get
            {
                return Math.Sqrt(Math.Pow(Real,2)+Math.Pow(Imaginary,2));
            }
        }

        public ComplexNumber() { Real=0; Imaginary=0;}

        public ComplexNumber(double real, double imaginary)
        {
            Real=real;
            Imaginary=imaginary;
        }

        public static ComplexNumber operator+(ComplexNumber operand1, ComplexNumber operand2)
        {
            return new ComplexNumber(operand1.Real + operand2.Real, operand1.Imaginary + operand2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber operand1, ComplexNumber operand2)
        {
            return new ComplexNumber(operand1.Real - operand2.Real, operand1.Imaginary - operand2.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber operand1, int multiplier)
        {
            return new ComplexNumber(operand1.Real *multiplier, operand1.Imaginary*multiplier);
        }

        public static ComplexNumber operator *(ComplexNumber operand1, ComplexNumber operand2)
        {
            return new ComplexNumber((operand1.Real * operand2.Real-operand1.Imaginary*operand2.Imaginary), (operand1.Imaginary * operand2.Real+operand1.Imaginary*operand2.Imaginary));
        }

        public static ComplexNumber operator /(ComplexNumber operand1, ComplexNumber operand2)
        {
            
            return new ComplexNumber((operand1.Real * operand2.Real + operand1.Imaginary * operand2.Imaginary) / (operand2.Imaginary * operand2.Imaginary + operand2.Real * operand2.Real),
                (operand1.Imaginary*operand2.Real-operand1.Real*operand2.Imaginary)/ (operand2.Imaginary * operand2.Imaginary + operand2.Real * operand2.Real));
        }

        public static ComplexNumber operator /(ComplexNumber operand1, int divisor)
        {
            return new ComplexNumber(operand1.Real/divisor, operand1.Imaginary/divisor);
        }

        public static bool operator ==(ComplexNumber operand1, ComplexNumber operand2)
        {
            return (operand1.Real == operand2.Real && operand1.Imaginary == operand2.Imaginary);
        }

        public static bool operator !=(ComplexNumber operand1, ComplexNumber operand2)
        {
            return (operand1.Real != operand2.Real || operand1.Imaginary != operand2.Imaginary);
        }

        public static implicit operator string(ComplexNumber operand1)
        {
            return String.Format("{0}+{1}i",operand1.Real,operand1.Imaginary);
        }
        public override string ToString()
        {
 	        return (string)this;
        }
        public static bool operator <(ComplexNumber operand1, ComplexNumber operand2)
        {
            return (operand1.Magnitude < operand2.Magnitude);
        }
        public static bool operator >(ComplexNumber operand1, ComplexNumber operand2)
        {
            return (operand1.Magnitude > operand2.Magnitude);
        }
        public static bool operator >=(ComplexNumber operand1, ComplexNumber operand2)
        {
            return (operand1.Magnitude >= operand2.Magnitude);
        }
        public static bool operator <=(ComplexNumber operand1, ComplexNumber operand2)
        {
            return (operand1.Magnitude < operand2.Magnitude);
        }
    }
}
