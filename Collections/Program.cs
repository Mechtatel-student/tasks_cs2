using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static bool Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine("ERROR: " + message);
            }
            else
            {
                Console.WriteLine("Passed.");
            }
            return condition;
        }

        private class Potatoe : IPotatoe
        {
            public Potatoe(bool isBad) { IsBad = isBad; }

            public bool IsBad { get; private set; }
        }

        private class InData : IInData
        {
            public InData(SensorCodes code, int value, bool valid)
            {
                Code = (int)code;
                Value = value;
                IsValid = valid;
            }

            public int Code { get; private set; }

            public int Value { get; private set; }

            public bool IsValid { get; private set; }
        }

        private enum SensorCodes { Sensor1 = 3, Sensor2 = 278, Sensor3 = 1 };

        static void Main(string[] args)
        {
            List<ICollections> localCollections = new List<ICollections>();
            localCollections.Add(new Alina.Collections());
            localCollections.Add(new Andrey.Collections());
            localCollections.Add(new Elena.Collections());
            localCollections.Add(new Konstantin.Collections());
            localCollections.Add(new Valeriya.Collections());
            localCollections.Add(new Vladimir.Collections());

            foreach (var collection in localCollections)
            {
                try
                {
                    // simple numbers
                    int[] arrToCheck = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19 };
                    int index = 0;
                    foreach (var number in collection.GetSimpleNumbersInstance(20))
                    {
                        if (index > arrToCheck.Length - 1)
                        {
                            Assert(false, "Too many simple numbers generated!");
                        }
                        Assert(number == arrToCheck[index], "Wrong simple number " + number + " must be " + arrToCheck[index]);
                    }

                    // Potatoes
                    List<IPotatoe> myPotatoes = new List<IPotatoe>();
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(true));

                    List<IPotatoe> goodPotatoes;
                    List<IPotatoe> badPotatoes;

                    Console.WriteLine("Working at: " + collection.ToString());
                    int good = collection.SortPotatoes(myPotatoes, out goodPotatoes, out badPotatoes);
                    Assert(good == 4, "Возвращено неверное количество хорошей картошки");
                    if (!Assert(goodPotatoes != null, "мешок с хорошей картошкой не существует!"))
                    {
                        continue;
                    }
                    if (!Assert(badPotatoes != null, "мешок с плохой картошкой не существует!"))
                    {
                        continue;
                    }
                    Assert(goodPotatoes.Count == 4, "в мешке с хорошей картошкой неверное количество");
                    Assert(badPotatoes.Count == 5, "в мешке с плохой картошкой неверное количество");

                    Assert(goodPotatoes.TrueForAll((p) => { return !p.IsBad; }), "в мешок с хорошей картошкой попала плохая");
                    Assert(badPotatoes.TrueForAll((p) => { return p.IsBad; }), "в мешок с плохой картошкой попала хорошая");

                    Assert(myPotatoes.Count == 0, "Изначальный мешок с картошкой не пустой");

                    // Sensors
                    {
                        List<IInData> data = new List<IInData>();
                        data.Add(new InData(SensorCodes.Sensor1, 18, true));
                        data.Add(new InData(SensorCodes.Sensor1, 20, false));
                        data.Add(new InData(SensorCodes.Sensor1, 22, true));
                        data.Add(new InData(SensorCodes.Sensor2, 2, true));
                        data.Add(new InData(SensorCodes.Sensor2, 1, true));
                        data.Add(new InData(SensorCodes.Sensor3, 15, false));

                        List<IOutData> result = collection.ProcessData(data);

                        if (!Assert(result != null, "не существует результата")
                            || !Assert(result.Count == 2, "результат неверной длины"))
                        {
                            continue;
                        }

                        int indexSensor1 = result.FindIndex((element) => { return element.Code == (int)SensorCodes.Sensor1; });
                        int indexSensor2 = result.FindIndex((element) => { return element.Code == (int)SensorCodes.Sensor2; });
                        int indexSensor3 = result.FindIndex((element) => { return element.Code == (int)SensorCodes.Sensor3; });

                        if (Assert(indexSensor1 >= 0, "Нет одного из требуемых кодов"))
                        {
                            Assert(result[indexSensor1].Average == 20.0, "Неверное среднее значение для одного из датчиков");
                        }
                        if (Assert(indexSensor2 >= 0, "Нет одного из требуемых кодов"))
                        {
                            Assert(result[indexSensor2].Average == 1.5, "Неверное среднее значение для одного из датчиков");
                        }
                        Assert(indexSensor3 < 0, "Ненужный код был возвращён");
                    }

                    // linked list
                    {
                        LinkedList<int> result = collection.CreateOrderedList(new List<int>(new int[] { 1, -9, 6, 124, -7, 34, 1, 2, 0, 99, -56 }));
                        if(Assert(result != null, "нет результата!"))
                        {
                            if (Assert(result.Count == 11, "длина списка неверная"))
                            {
                                Assert(result.First.Value == -56, "-56 on wrong place");
                                Assert(result.First.Next.Value == -9, "-9 on wrong place");
                                Assert(result.First.Next.Next.Value == -7, "-7 on wrong place");
                                Assert(result.First.Next.Next.Next.Value == 0, "0 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Value == 1, "1 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Value == 1, "1 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Next.Value == 2, "2 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Next.Next.Value == 6, "6 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Next.Next.Next.Value == 34, "34 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Next.Next.Next.Next.Value == 99, "99 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Value == 124, "124 on wrong place");
                                Assert(result.First.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next == null, "wrong end of list");
                            }
                        }
                    }

                    // dictionary
                    {
                        List<string> myText = new List<string>();
                        myText.AddRange(new string[]{ "12345", "af", "333", "f", "aff", "aa", "aa" });
                        IReadOnlyDictionary<char, IList<string>> result = collection.OrganizeByFirstCharacter(myText);
                        if (Assert(result != null, "нет результата!"))
                        {
                            Assert(result.Count == 4, "размер словарика неверный");
                            int goodValues = 0;
                            foreach (var item in result)
                            {
                                if (Assert(item.Value != null, "нет списка по ключу " + item.Key))
                                {
                                    if (Assert(item.Value.Count > 0, "пустой список по ключу " + item.Key))
                                    {
                                        goodValues++;
                                    }
                                }
                            }
                            if (goodValues == result.Count)
                            {
                                HashSet<char> modelKeys = new HashSet<char>();
                                modelKeys.Add('1');
                                modelKeys.Add('a');
                                modelKeys.Add('3');
                                modelKeys.Add('f');
                                foreach (var key in modelKeys)
                                {
                                    if (Assert(result.ContainsKey(key), "Результат не содержит ключ " + key))
                                    { 
                                        IList<string> list = result[key];
                                        if (list != null)
                                        {
                                            switch (key)
                                            { 
                                                case 'a':
                                                    Assert(list.Count == 4, "Длина списка по ключу " + key + " неверная");
                                                    break;
                                                case '1':
                                                    Assert(list.Count == 1, "Длина списка по ключу " + key + " неверная");
                                                    break;
                                                case '3':
                                                    Assert(list.Count == 1, "Длина списка по ключу " + key + " неверная");
                                                    break;
                                                case 'f':
                                                    Assert(list.Count == 1, "Длина списка по ключу " + key + " неверная");
                                                    break;
                                            }
                                        }
                                    }
                                }
                                foreach(var key in result.Keys)
                                {
                                    Assert(modelKeys.Contains(key), "Лишний ключ " + key + " в результате");
                                }
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Где-то ошибка {0}: {1}", collection.ToString(), e.Message);
                }

            }
            Console.ReadKey(true);
        }
    }
}
