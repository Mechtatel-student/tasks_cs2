using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class EmptyQueueException: ApplicationException
    {
        public EmptyQueueException(string msg) : base (msg)
        {
        }
    }
}
