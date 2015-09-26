using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    abstract class Number<T>
    {
        protected T value;

        public Number(){}

        public Number(T val)
        {
            value = val;
        }

        abstract public T Add(T op1);
    }
}
