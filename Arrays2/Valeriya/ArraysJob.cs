using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Valeriya
{
    class ArraysJob : IArraysJob
    {
        public bool JaggedArrayExchange(int[][] inputArray)
        {
            bool flagExchange = false;
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[0].Length == inputArray[i].Length)
                {
                    int[] tmp = inputArray[0];
                    inputArray[0] = inputArray[i];
                    inputArray[i] = tmp;
                    flagExchange = true;
                    break;
                }
            }

            return flagExchange;
        }

        public int[][] LifeCalculations(int[][] inputArray)
        {
            int[][] copyOfInputArray = {
                        new int[] { 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0 },
                        new int[] { 0, 0, 0, 0 }
                    };
           int index = 0;
           foreach (int[] elem in inputArray)
            {
                elem.CopyTo(copyOfInputArray[index], 0);
                index++;         
            }

            for (int i = 1; i <= inputArray.Length-2; i++)
            {
                for (int j = 1; j <= inputArray[i].Length-2; j++)
                {
                    if ((inputArray[i][j] == 1 && (inputArray[i-1][j-1]+inputArray[i-1][j]+inputArray[i-1][j+1]+inputArray[i][j-1]+inputArray[i][j+1]
                        +inputArray[i+1][j-1]+inputArray[i+1][j]+inputArray[i+1][j+1]) > 3) || (inputArray[i][j] == 1 && (inputArray[i - 1][j - 1] + 
                        inputArray[i - 1][j] + inputArray[i - 1][j + 1] + inputArray[i][j - 1] + inputArray[i][j + 1]
                        + inputArray[i + 1][j - 1] + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) < 2))
                    {
                        copyOfInputArray[i][j] = 0;
                    }
                    else if (inputArray[i][j] == 0 && inputArray[i - 1][j - 1] + inputArray[i - 1][j] + 
                        inputArray[i - 1][j + 1] + inputArray[i][j - 1] + inputArray[i][j + 1]
                        + inputArray[i + 1][j - 1] + inputArray[i + 1][j] + inputArray[i + 1][j + 1] == 3)
                    {
                        copyOfInputArray[i][j] = 1;
                    }
                }
            }

            for (int i = 1; i <= inputArray.Length - 2; i++)
            {
                int j = 0;
                    if ((inputArray[i][j] == 1 && (inputArray[i - 1][j] + inputArray[i - 1][j + 1] + inputArray[i][j + 1]
                        + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) > 3) || (inputArray[i][j] == 1 && (inputArray[i - 1][j] + inputArray[i - 1][j + 1] + inputArray[i][j + 1]
                        + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) < 2))
                    {
                        copyOfInputArray[i][j] = 0;
                    }
                    else if ((inputArray[i][j] == 0 && (inputArray[i - 1][j] + inputArray[i - 1][j + 1] + inputArray[i][j + 1]
                        + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) == 3))
                    {
                        copyOfInputArray[i][j] = 1;
                    }
                }

            for (int i = 1; i <= inputArray.Length - 2; i++)
            {
                int j = inputArray[i].Length - 1;
                if ( (inputArray[i][j] == 1 && (inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i][j - 1]
                    + inputArray[i + 1][j - 1] + inputArray[i + 1][j]) > 3) || (inputArray[i][j] == 1 && (inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i][j - 1]
                    + inputArray[i + 1][j - 1] + inputArray[i + 1][j]) < 2) )
                {
                    copyOfInputArray[i][j] = 0;
                }
                else if ( (inputArray[i][j] == 0 && (inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i][j - 1]
                    + inputArray[i + 1][j - 1] + inputArray[i + 1][j]) == 3) )
                {
                    copyOfInputArray[i][j] = 1;
                }
            }

            int arrayLenght = 0;
            for (int j = 1; j <= inputArray[arrayLenght].Length - 2; j++)
            {
                int i = 0;
                if ((inputArray[i][j] == 1 && (inputArray[i][j - 1] + inputArray[i][j + 1] + inputArray[i + 1][j - 1]
                    + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) > 3) || (inputArray[i][j] == 1 && (inputArray[i][j - 1] + inputArray[i][j + 1] + inputArray[i + 1][j - 1]
                    + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) < 2))
                {
                    copyOfInputArray[i][j] = 0;
                }
                else if ((inputArray[i][j] == 0 && (inputArray[i][j - 1] + inputArray[i][j + 1] + inputArray[i + 1][j - 1]
                    + inputArray[i + 1][j] + inputArray[i + 1][j + 1]) == 3))
                {
                    copyOfInputArray[i][j] = 1;
                }
            }

            for (int j = 1; j <= inputArray[arrayLenght].Length - 2; j++)
            {
                int i = inputArray.Length - 1;
                if ((inputArray[i][j] == 1 && (inputArray[i - 1][j - 1] + inputArray[i - 1][j + 1] + inputArray[i][j - 1]
                    + inputArray[i - 1][j] + inputArray[i][j + 1]) > 3) || (inputArray[i][j] == 1 && (inputArray[i - 1][j - 1] + inputArray[i - 1][j + 1] + inputArray[i][j - 1]
                    + inputArray[i - 1][j] + inputArray[i][j + 1]) < 2))
                {
                    copyOfInputArray[i][j] = 0;
                }
                else if ( (inputArray[i][j] == 0 && (inputArray[i - 1][j - 1] + inputArray[i - 1][j + 1] + inputArray[i][j - 1]
                    + inputArray[i - 1][j] + inputArray[i][j + 1]) == 3) )
                {
                    copyOfInputArray[i][j] = 1;
                }
            }
            int k = 0;
            int p = 0;
             //1
            if ((inputArray[k][p] == 1 && (inputArray[k][p + 1] + inputArray[k + 1][p] + inputArray[k + 1][p + 1]) > 3) || 
                (inputArray[k][p] == 1 && (inputArray[k][p + 1] + inputArray[k + p][p] + inputArray[k + 1][p + 1]) < 2))
            {
                copyOfInputArray[k][p] = 0;
            }
            else if ( (inputArray[k][p] == 0 && (inputArray[k][p + 1] + inputArray[k + 1][p] + inputArray[k + 1][p + 1]) == 3) )
            {
                copyOfInputArray[k][p] = 1;
            }
            //2
            int lastRightElem = inputArray[arrayLenght].Length - 1;
            if ((inputArray[k][lastRightElem] == 1 && (inputArray[k][lastRightElem - 1] + inputArray[k + 1][lastRightElem - 1] + inputArray[k + 1][lastRightElem]) > 3) ||
               (inputArray[k][p] == 1 && (inputArray[k][lastRightElem - 1] + inputArray[k + 1][lastRightElem - 1] + inputArray[k + 1][lastRightElem]) < 2))
            {
                copyOfInputArray[k][lastRightElem] = 0;
            }
            else if ( (inputArray[k][lastRightElem] == 0 && (inputArray[k][lastRightElem - 1] + inputArray[k + 1][lastRightElem - 1] + inputArray[k + 1][lastRightElem]) == 3) )
            {
                copyOfInputArray[k][lastRightElem] = 1;
            }
            //3
            int lastLeftElem = inputArray.Length - 1;
            if ((inputArray[lastLeftElem][p] == 1 && (inputArray[lastLeftElem - 1][p] + inputArray[lastLeftElem - 1][p + 1] + inputArray[lastLeftElem][p + 1]) > 3) ||
                (inputArray[lastLeftElem][p] == 1 && (inputArray[lastLeftElem - 1][p] + inputArray[k - 1][p + 1] + inputArray[k][p + 1]) < 2))
            {
                copyOfInputArray[lastLeftElem][p] = 0;
            }
            else if ((inputArray[lastLeftElem][p] == 0 && (inputArray[lastLeftElem - 1][p] + inputArray[lastLeftElem - 1][p + 1] + inputArray[lastLeftElem][p + 1]) == 3))
            {
                copyOfInputArray[lastLeftElem][p] = 1;
            }
            //4
            if ((inputArray[lastLeftElem][lastRightElem] == 1 && (inputArray[lastLeftElem - 1][lastRightElem - 1] + inputArray[lastLeftElem - 1][lastRightElem] + inputArray[k][lastRightElem - 1]) > 3) ||
              (inputArray[lastLeftElem][lastRightElem] == 1 && (inputArray[lastLeftElem - 1][lastRightElem - 1] + inputArray[lastLeftElem - 1][lastRightElem] + inputArray[lastLeftElem][lastRightElem - 1]) < 2))
            {
                copyOfInputArray[lastLeftElem][lastRightElem] = 0;
            }
            else if ((inputArray[lastLeftElem][lastRightElem] == 0 && (inputArray[lastLeftElem - 1][lastRightElem - 1] + inputArray[lastLeftElem - 1][lastRightElem] + inputArray[lastLeftElem][lastRightElem - 1]) == 3))
            {
                copyOfInputArray[lastLeftElem][lastRightElem] = 1;
            }

            return copyOfInputArray;
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int inputArrayLenght = inputArray.Length;
            int countOfSameElems = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    countOfSameElems += 1;
                }
            }
       
            return countOfSameElems;
        }
    }
}
