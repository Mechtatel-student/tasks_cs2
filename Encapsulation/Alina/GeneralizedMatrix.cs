using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class GeneralizedMatrix<T>
    {
        T[,] matrix;
        int matrixHigh;
        int MatrixHigh { get { return matrixHigh; } }
        int matrixWidth;
        int MatrixWidth { get { return matrixWidth; } }
        public GeneralizedMatrix(int matrixHigh, int matrixWidth)
        {
            this.matrixHigh = matrixHigh;
            this.matrixWidth = matrixWidth;
            matrix = new T[matrixHigh, matrixWidth];
        }
        public GeneralizedMatrix(T[,] matrix)
        {
            this.matrix = matrix;
        }
        public T this[int row, int col]
        {
            get
            {
                return matrix[row, col];
            }
            set
            {
                matrix[row, col] = value;
            }
        }
    }
}
