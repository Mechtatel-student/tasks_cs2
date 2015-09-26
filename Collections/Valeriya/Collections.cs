using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Valeriya
{
    class Collections : ICollections
    {
        public int SortPotatoes(List<IPotatoe> potatoeBag, out List<IPotatoe> goodPotatoes, out List<IPotatoe> badPotatoes)
        {
            goodPotatoes = new List<IPotatoe>();
            badPotatoes = new List<IPotatoe>();
            int i = 0;
            while (potatoeBag.Count != 0)
            {
                if (potatoeBag[i].IsBad)
                {
                    badPotatoes.Add(potatoeBag[i]);
                    potatoeBag.Remove(potatoeBag[i]);
                }
                else
                {
                    goodPotatoes.Add(potatoeBag[i]);
                    potatoeBag.Remove(potatoeBag[i]);
                }
            }

            return goodPotatoes.Count;
        }

        public List<IOutData> ProcessData(IReadOnlyList<IInData> inputData)
        {
            List<IOutData> sensorsAverage = new List<IOutData>();
            List<IInData> onlyValidFromInputData = new List<IInData>();
            List<int> codesOfSensors = new List<int>();
            List<double> sumsFromSensors = new List<double>();
            List<int> countOfValuesFromEachSensor = new List<int>();

            for (int i = 0; i < inputData.Count; i++)
            {
                if (inputData[i].IsValid == true)
                {
                    onlyValidFromInputData.Add(inputData[i]);
                }
            }

            int count = onlyValidFromInputData.Count;

            for (int i = 0; i < count - 1; i++)
            {
                if (onlyValidFromInputData[i].Code == onlyValidFromInputData[i + 1].Code)
                {
                    codesOfSensors.Add(onlyValidFromInputData[i].Code);
                    sumsFromSensors.Add(onlyValidFromInputData[i].Value);
                    countOfValuesFromEachSensor.Add(1);
                }
                else
                {
                    if (codesOfSensors.Contains(onlyValidFromInputData[i].Code))
                    {
                        sumsFromSensors[codesOfSensors.IndexOf(onlyValidFromInputData[i].Code)] += onlyValidFromInputData[i].Value;
                        countOfValuesFromEachSensor[codesOfSensors.IndexOf(onlyValidFromInputData[i].Code)] += 1;
                    }
                    else
                    {
                        codesOfSensors.Add(onlyValidFromInputData[i].Code);
                        sumsFromSensors.Add(onlyValidFromInputData[i].Value);
                        countOfValuesFromEachSensor.Add(1);
                    }
                }
            }
            if (onlyValidFromInputData[count - 2].Code == onlyValidFromInputData[count - 1].Code)
            {
                sumsFromSensors[codesOfSensors.IndexOf(onlyValidFromInputData[count - 1].Code)] += onlyValidFromInputData[count - 1].Value;
                countOfValuesFromEachSensor[codesOfSensors.IndexOf(onlyValidFromInputData[count - 1].Code)] += 1;
            }
            else
            {
                if (codesOfSensors.Contains(onlyValidFromInputData[count - 1].Code))
                {
                    sumsFromSensors[codesOfSensors.IndexOf(onlyValidFromInputData[count - 1].Code)] += onlyValidFromInputData[count - 1].Value;
                    countOfValuesFromEachSensor[codesOfSensors.IndexOf(onlyValidFromInputData[count - 1].Code)]++;
                }
                else
                {
                    codesOfSensors.Add(onlyValidFromInputData[count - 1].Code);
                    sumsFromSensors.Add(onlyValidFromInputData[count - 1].Value);
                    countOfValuesFromEachSensor.Add(1);
                }
            }

            for (int i = 0; i < sumsFromSensors.Count; i++)
            {
                sensorsAverage.Add(new OutData(codesOfSensors[i], sumsFromSensors[i] / countOfValuesFromEachSensor[i]));
            }

            return sensorsAverage;
        }

        public LinkedList<int> CreateOrderedList(IReadOnlyList<int> input)
        {
            LinkedList<int> orderedList = new LinkedList<int>();
            orderedList.AddFirst(input[0]);
            int insertFlag = 0;
            for (int i = 1; i < input.Count; i++)
            {
                var node = orderedList.First;
                while (node != orderedList.Last)
                {
                    if (node.Value >= input[i])
                    {
                        orderedList.AddBefore(node, input[i]);
                        insertFlag = 1;
                        break;
                    }

                    node = node.Next;
                }
                if (insertFlag == 0)
                {
                    if (input[i] > orderedList.Last.Value)
                    {
                        orderedList.AddAfter(node, input[i]);
                    }
                    else
                    {
                        orderedList.AddBefore(node, input[i]);
                    }
                }

                insertFlag = 0;
            }

            return orderedList;
        }


        public IReadOnlyDictionary<char, IList<string>> OrganizeByFirstCharacter(IEnumerable<string> text)
        {
            Dictionary<char, IList<string>> returnDictionary = new Dictionary<char, IList<string>>();
            foreach (var elem in text)
            {
                if (!returnDictionary.ContainsKey(elem[0]))
                {
                    returnDictionary.Add(elem[0], new List<string>());
                    returnDictionary[elem[0]].Add(elem);
                }
                else
                {
                    returnDictionary[elem[0]].Add(elem);
                }
            }

            return returnDictionary;
        }


        public ISimpleNumbers GetSimpleNumbersInstance(int limit)
        {
            throw new NotImplementedException();
        }
    }
}
