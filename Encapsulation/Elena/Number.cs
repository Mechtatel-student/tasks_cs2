using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    abstract class Number<T>
    {
        protected T value;
        public Number() { }
        public Number(T val)
        {
            value=val;
        }

        public abstract T Add(T op1, T op2);

    }

  /*  class Int : Number<int>
    {
        int Add(int op)
        { return value + op; }
    }

    class Double : Number<double>
    {
        double Add(double op)
        { return value + op; }
    }*/
}
