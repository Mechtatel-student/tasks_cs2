using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Elena
{
    class Collections:ICollections
    {
        public class OutData:IOutData
        {
           public int code;
           public double average;

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

        public class ResultRegistr 
        {
           public int code;
            public double value;
            public int countOfData;

           public ResultRegistr(int c, double v, int count)
            {
                code = c;
                value = v;
                countOfData = count;
            }
        }
        public int SortPotatoes(List<IPotatoe> potatoeBag, out List<IPotatoe> goodPotatoes, out List<IPotatoe> badPotatoes)
        {
            int goodCount=0;
             badPotatoes = new List<IPotatoe>();
             goodPotatoes = new List<IPotatoe>();
            for (int i=0; i<potatoeBag.Count; i++)
            {
                if (potatoeBag[i].IsBad)
                {
                    badPotatoes.Add(potatoeBag[i]);
                    
                }

                else
                {
                    goodPotatoes.Add(potatoeBag[i]);
                  
                    goodCount++;
                }
            }
            potatoeBag.Clear();
            return goodCount;
         }



        public List<IOutData> ProcessData(IReadOnlyList<IInData> inputData)
        {
          
            List<ResultRegistr> resultData = new List<ResultRegistr>();
            List<int> codeCollestions=new List<int>();
            int indexList;
            
            foreach(IInData element in inputData)
            {
                if (element.IsValid)
                {
                    if (!codeCollestions.Contains(element.Code))
                    {
                        codeCollestions.Add(element.Code);
                        ResultRegistr rr = new ResultRegistr(element.Code, element.Value, 1);
                        resultData.Add(rr);
                    }
                    else
                    {
                        indexList = resultData.FindIndex(elementCode => elementCode.code == element.Code);
                        resultData[indexList].value += element.Value;
                        resultData[indexList].countOfData++;
                    }
                }

            }
            List<OutData> listRezult = new List<OutData>();
            for (int i = 0; i < resultData.Count; i++)
            {

                listRezult.Add(new OutData ( resultData[i].code, resultData[i].value / resultData[i].countOfData ));
               
            }

           //В этой строке невозможно преобразовать список
           List<IOutData> result = listRezult.ConvertAll( new Converter<OutData,IOutData>(MyConverter));
          
            return result;
        }

        public LinkedList<int> CreateOrderedList(IReadOnlyList<int> input)
        {
            LinkedList<int> outputList = new LinkedList<int>();
            List<int> newInput = new List<int>();
            foreach (int element in input)
            {
                newInput.Add(element);
            }

            newInput.Sort();

            foreach (int element in newInput)
            {
                outputList.AddLast(element);
            }
            
            return outputList;
        }
        

        public IReadOnlyDictionary<char, IList<string>> OrganizeByFirstCharacter(IEnumerable<string> text)
        {
           
            Dictionary <char, IList<string>> returnValue= new Dictionary<char, IList<string>>();

            char firstChar;
            foreach(string element in text)
            {
                firstChar = Convert.ToChar(element.Substring(0, 1));
                if (!returnValue.ContainsKey(firstChar))
                {
                    returnValue.Add(firstChar, new List<string>());
                }

                returnValue[firstChar].Add(element);  
               
            }
            return returnValue;

        }

        public static IOutData MyConverter(OutData element)
        {return   (IOutData)element;}


        public ISimpleNumbers GetSimpleNumbersInstance(int limit)
        {
            throw new NotImplementedException();
        }
    }
}
