using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Vladimir
{
    class Collections : ICollections
    {
        public int SortPotatoes(List<IPotatoe> potatoeBag, out List<IPotatoe> goodPotatoes, out List<IPotatoe> badPotatoes)
        { 
            goodPotatoes = new List<IPotatoe>();
            badPotatoes = new List<IPotatoe>();

            foreach (IPotatoe workPotatoe in potatoeBag)
            {
                if (workPotatoe.IsBad)
                {
                    badPotatoes.Add(workPotatoe);
                    //potatoeBag.Remove(workPotatoe);
                }
                else
                {
                    goodPotatoes.Add(workPotatoe);
                }
            }
            potatoeBag.Clear();
         return goodPotatoes.Count;
        }
        
        public List<IOutData> ProcessData(IReadOnlyList<IInData> inputData)
        {
                
            int maxNumberCode = 0;
            int index = 0;
            foreach (IInData workData in inputData)
            {
                if (workData.IsValid)
                {
                    index++;
                    if (maxNumberCode < workData.Code)
                    {
                        maxNumberCode = workData.Code;  // максимальный №(код) контроллера
                    }
                }
            }

            int[] codes = new int[index];
            int[] values = new int[index];

            index = 0;
            foreach (IInData workData in inputData)
            {
                if (workData.IsValid)
                {
                    codes[index] = workData.Code;
                    values[index] = workData.Value;
                    index++;
                }
            }

            int inCountControllers = maxNumberCode+1; // или вычисление количества возможных кодировок контроллеров, с нулевым значением.

           AverageByBit[] answerData = new AverageByBit[inCountControllers];  //всего разных датчиков от 000 до 111 - 8 шт.
           answerData = CountAverage(codes, values, inCountControllers);

           List<IOutData> outData = new List<IOutData>();
           
           for (int i = 0; i < inCountControllers; i++)
           {
               if (answerData[i].value != 0)
               {
    
                   outData.Add(new OutData { Code = answerData[i].code, Average = answerData[i].value });
                }
           }
         return outData;
        }


        public LinkedList<int> CreateOrderedList(IReadOnlyList<int> input)
        {
            //throw new NotImplementedException();

            int[] workArray = new int[input.Count];
            int i = 0;
            foreach (int workInt in input)
            {
                workArray[i] = workInt;
                i++;
            }

            Array.Sort(workArray);

            LinkedList<int> workList = new LinkedList<int>();
            
            for (int index = 0; index < input.Count; index++)
            {
                workList.AddLast(workArray[index]);  
            }
        return workList;
        }

        //---использование метода с массивами для высичления среднего значения по конроллерам
        public struct AverageByBit
        {
            public int code;
            public double value;
        }

        public AverageByBit[] CountAverage(int[] inCodes, int[] inValues, int inCountControllers)
        {
            AverageByBit[] answerData = new AverageByBit[inCountControllers];

            for (int i = 0; i < inCountControllers; i++)
            {
                answerData[i].code = i;    // инициализируем сруктуру ответов
                answerData[i].value = 0.0;
            }

            int[] countValueForAverage = new int[inCountControllers];

            for (int i = 0; i < inCodes.Length; i++)
            {
                int currentCode = inCodes[i];

                answerData[currentCode].value += inValues[i];
                countValueForAverage[currentCode]++;
            }

            for (int i = 0; i < inCountControllers; i++)
            {
                if (countValueForAverage[i] != 0)
                {
                    answerData[i].value /= countValueForAverage[i];
                }
                else
                {
                    answerData[i].value = 0.0;
                }
            }
            return answerData;
        }
        //--------------------------------------------------------


        
        //
        //List<string> inData = new List<string>();
        //inData[0] = "abcd";
        //inData[1] = "45da";
        //inData[2] = "naa";
        //inData[3] = "nasdfas";


        public IReadOnlyDictionary<char, IList<string>> OrganizeByFirstCharacter(IEnumerable<string> text)
        {
            Dictionary<char, IList<string>> answer = new Dictionary<char, IList<string>>();
            foreach (string item in text)
            {
                answer.Add(item[0], new List<string>());
                do
                {
                    answer[item[0]].Add(item);  // .Substring(1, item.Length));
                }
                while (answer.ContainsKey(item[0]));
            }
            return answer;
        }














        public ISimpleNumbers GetSimpleNumbersInstance(int limit)
        {
            throw new NotImplementedException();
        }
    }
}
