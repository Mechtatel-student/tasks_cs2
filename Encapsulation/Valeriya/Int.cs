using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class Int: Number<int>
    {
        public override int Add(int oper)
        {
            return oper + value;
        }

    }
}
