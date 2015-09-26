using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    class Complex
    {
        public double RealPart 
        {
            get
            {return realPart ;}
        }

        public double ImaginaryPart
        {
            get { return imaginaryPart; }
        }

        private double realPart;
        private double imaginaryPart;
        private double module;
        private double argument;

        public bool ViewTrigonom
        { get; set; }

        public Complex()
            : this(0.0, 0.0) { }
        
        public Complex(double re, double im)
        {
            realPart = re;
            imaginaryPart = im;
            ConvertComplexToTrigonomViev();
            ViewTrigonom = false;
            Tuple<double, double> complex = Tuple.Create<double, double>(realPart, imaginaryPart);
        }

        static public explicit operator string(Complex operand1)
        {
            return operand1.ToString();
        }

        public override string ToString()
        {
            string stringFormat;
            if (this.ViewTrigonom != true)
            {
               stringFormat = string.Format( "Re = {0:000}, Im = {1:000} ", realPart, imaginaryPart);
            }
            else
            {
               stringFormat = string.Format( "mod = {0:000}, arg = {1:000} ", module, argument);
            }
            
            return stringFormat;
        }

        public static Complex operator+ (Complex operand1, Complex operand2)
        {
            return new Complex(operand1.RealPart + operand2.RealPart, operand1.ImaginaryPart + operand2.ImaginaryPart);
        }

        public static Complex operator- (Complex operand1, Complex operand2)
        {
            return new Complex(operand1.RealPart - operand2.RealPart, operand1.ImaginaryPart - operand2.ImaginaryPart);
        }

        public static Complex operator* (Complex operand1, Complex operand2)
        {
            return new Complex((operand1.RealPart * operand2.RealPart - operand1.ImaginaryPart * operand2.ImaginaryPart),  
                                operand1.ImaginaryPart * operand2.RealPart + operand1.RealPart * operand2.ImaginaryPart);  
        }

        public static Complex operator /(Complex operand1, Complex operand2)
        {
            double denominator = operand1.RealPart * operand1.RealPart + operand2.ImaginaryPart * operand2.ImaginaryPart;
            double re =  operand1.RealPart * operand2.RealPart + operand1.ImaginaryPart * operand2.ImaginaryPart;
            double im = operand1.ImaginaryPart * operand2.RealPart - operand1.RealPart * operand2.ImaginaryPart;
            
            return new Complex(re / denominator, im / denominator);
        }

        private void ConvertComplexToTrigonomViev()
        {
            // z=a+bi =>  z=|z|*(cos r + i sin r)
            
            module = Math.Sqrt(realPart*realPart+imaginaryPart*imaginaryPart);

            if(realPart >0)
            {
              argument =  Math.Atan2(imaginaryPart,imaginaryPart);           
            }
            else if(imaginaryPart >0)
            {
                argument = Math.PI + Math.Atan2(imaginaryPart, imaginaryPart);           
            }
              else if (imaginaryPart < 0)
              {
                argument = - Math.PI + Math.Atan2(imaginaryPart, imaginaryPart);
              }
        }
    }
}
