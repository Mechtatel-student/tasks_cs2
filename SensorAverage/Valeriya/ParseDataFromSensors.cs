using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Valeriya
{
    public class ParseDataFromSensors
    {
        public struct AverageBySensor
        {
           public ushort code;
           public double value;
           
           public AverageBySensor (ushort code, double value)
            {
                this.code = code;
                this.value = value;
            }
        }

        int countOfSetBit (ushort number)
        {
            int count = 0;
            for (; number != 0; number >>= 1)
            {
                if ((number & 1) == 1)
                {
                    count++;
                }
            }
            return count;
        }


        public List<AverageBySensor> ParseData (ushort[] data)
        {
            List<AverageBySensor> dataFromSensors = new List<AverageBySensor>();
            for (int i = 0; i < data.Length; i++)
            {
                ushort codeOfSensor = (ushort)(data[i] >> 13);
                int valueFromSensor = (data[i] & 0x1FFE) >> 1;
                int count = countOfSetBit((ushort)(data[i] >> 1));
                if ( ((count % 2 == 0) && ((data[i] & 0x1) == 0)) || 
                     ((count % 2 != 0) && ((data[i] & 0x1) == 1)) )
                {
                    dataFromSensors.Add(new AverageBySensor(codeOfSensor, valueFromSensor));
                }
            }

            return dataFromSensors;
        }
    }
    public class CodesComparer : IComparer<ParseDataFromSensors.AverageBySensor>

    {
        public int Compare(ParseDataFromSensors.AverageBySensor x, ParseDataFromSensors.AverageBySensor y)

        {
            int result = 0;
            if (x.code > y.code)
            {
                result = -1;
            }
            else if (x.code < y.code)
            {
                result = 1;
            }
            else if (x.code == y.code)
            {
                result = 0;
            }

            return result;
        }

    }
}
