﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Alina
{
    class Collections : ICollections
    {
        public int SortPotatoes(List<IPotatoe> potatoeBag, out List<IPotatoe> goodPotatoes, out List<IPotatoe> badPotatoes)
        {
            List<IPotatoe> good = new List<IPotatoe>();
            List<IPotatoe> bad = new List<IPotatoe>();
            foreach (var potatoe in potatoeBag)
            {
                if (potatoe.IsBad)
                {
                    bad.Add(potatoe);
                }
                else
                {
                    good.Add(potatoe);
                }
            }
            goodPotatoes = good;
            badPotatoes = bad;
            potatoeBag.Clear();
            return good.Count;
        }

        private class SensorData
        {
            int codeSensor;
            public int CodeSensor { get { return codeSensor; } }
            int sumValue;
            int counter;
            public void AddValue(int sensorValue)
            {
                sumValue += sensorValue;
                counter++;
            }
            public double GetAvwrage()
            {
                return (double)sumValue / counter;
            }
            public SensorData(int codeSensor, int sumValue)
            {
                this.codeSensor = codeSensor;
                this.sumValue = sumValue;
                counter = 1;
            }
        }
        private class OutData : IOutData
        {
            private int code;
            private double average;
            public int Code
            {
                get { return code; }
            }

            public double Average
            {
                get { return average; }
            }
            public OutData(int code, double average)
            {
                this.code = code;
                this.average = average;
            }
        }
        public List<IOutData> ProcessData(IReadOnlyList<IInData> inputData)
        {
            List<SensorData> dataCollection = new List<SensorData>();
            foreach (var sensor in inputData)
            {
                if (sensor.IsValid)
                {
                    SensorData curentElement = dataCollection.Find(x => x.CodeSensor == sensor.Code);
                    if (curentElement == null)
                    {
                        dataCollection.Add(new SensorData(sensor.Code, sensor.Value));
                    }
                    else
                    {
                        curentElement.AddValue(sensor.Value);
                    }
                }
            }
            List<IOutData> result = new List<IOutData>();
            foreach (var item in dataCollection)
            {
                result.Add(new OutData(item.CodeSensor, item.GetAvwrage()));
            }
            return result;
        }

        public LinkedList<int> CreateOrderedList(IReadOnlyList<int> input)
        {
            List<int> output = new List<int>(input);
            output.Sort();
            return new LinkedList<int>(output);
        }
    }
}
