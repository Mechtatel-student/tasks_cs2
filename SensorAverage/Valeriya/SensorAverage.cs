using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Valeriya
{
    class SensorAverage : ISensorsAverage
    {
        CodesComparer sortCodesOfSensors = new CodesComparer();
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            int numberOfSensors = 3;
            ParseDataFromSensors dataParser = new ParseDataFromSensors();
            List<ParseDataFromSensors.AverageBySensor> dataFromSensors = dataParser.ParseData(data);
            double[] sumOfSensorsData = new double[numberOfSensors];
            ushort[] codesOfSensors = new ushort[numberOfSensors];
            int[] countOfDataForEachSensor = new int[numberOfSensors];
            int indexOfSum = 0;
            Tuple<ushort, double>[] averageFromSensors = new Tuple<ushort, double>[numberOfSensors];
            int countOfValues = dataFromSensors.Count;

            for (int i = 0; i < countOfValues - 1; i++)
            {
                if (dataFromSensors[i].code == dataFromSensors[i + 1].code)
                {
                    codesOfSensors[indexOfSum] = dataFromSensors[i].code;
                    sumOfSensorsData[indexOfSum] += dataFromSensors[i].value;
                    countOfDataForEachSensor[indexOfSum]++;
                }
                else
                {
                    sumOfSensorsData[indexOfSum] += dataFromSensors[i].value;
                    countOfDataForEachSensor[indexOfSum]++;
                    indexOfSum++;
                }
            }

            if (dataFromSensors[countOfValues-2].code == dataFromSensors[countOfValues-1].code)
                {
                    codesOfSensors[indexOfSum] = dataFromSensors[countOfValues-1].code;
                    sumOfSensorsData[indexOfSum] += dataFromSensors[countOfValues-1].value;
                    countOfDataForEachSensor[indexOfSum]++;
                }
                else
                {
                    sumOfSensorsData[indexOfSum] += dataFromSensors[countOfValues-1].value;
                    countOfDataForEachSensor[indexOfSum]++;
                    indexOfSum++;
                } 

            for (int i = 0; i < sumOfSensorsData.Length; i++)
            {
                averageFromSensors[i] = Tuple.Create(codesOfSensors[i], sumOfSensorsData[i] / countOfDataForEachSensor[i]);
            }
            
           return averageFromSensors;

        }
    }
}
