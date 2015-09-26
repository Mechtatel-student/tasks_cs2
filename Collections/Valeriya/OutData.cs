using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Valeriya
{
    class OutData : IOutData
    {
        public int Code { get { return 0; } }
        public double Average { get { return 0; } }
        public OutData (int code, double average)
        {
            //this.Code = code;
            //this.Average = average;
        }
    }
}
