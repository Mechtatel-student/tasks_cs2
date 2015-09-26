using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    class Matrix
    {
       // int rows;
       // int columns;
        int[,] newMatrix;

        public Matrix(int r, int c)
        {
            
            int[,] NewMatrix=new int[r, c];
            Random newMatrixElement = new Random();

            for (int i = 0; i < r; i++)
            {

                for (int j = 0; j < c; j++)
                {
                    NewMatrix[i, j] = newMatrixElement.Next(0, 100);
                }
            }
        }

     /*   public Matrix NewMatrix
        {
            get { return newMatrix; }
        }
      * */


    }
}
