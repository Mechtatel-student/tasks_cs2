using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    public class Matrix
    {
        int[,] matrix;
        int matrixHigh;
        int MatrixHigh { get { return matrixHigh; } }
        int matrixWidth;
        int MatrixWidth { get { return matrixWidth; } }
        public Matrix(int matrixHigh, int matrixWidth)
        {
            this.matrixHigh = matrixHigh;
            this.matrixWidth = matrixWidth;
            matrix = new int[matrixHigh, matrixWidth];
        }
        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;
            this.matrixHigh = matrix.GetLength(0);
            this.matrixWidth = matrix.GetLength(1);
        }

        public int this[int index1, int index2]
        {
            get
            {
                return matrix[index1, index2];
            }
            set
            {
                matrix[index1, index2] = value;
            }
        }

        public static Matrix operator +(Matrix operand1, Matrix operand2)
        {
            int[,] sum = new int[operand1.matrixHigh, operand1.matrixWidth];
            for (int i = 0; i < operand1.matrixHigh; i++)
            {
                for (int j = 0; j < operand1.matrixWidth; j++)
                {
                    sum[i, j] = operand1[i, j] + operand2[i, j];
                }
            }
            return new Matrix(sum);
        }
        public static Matrix operator -(Matrix operand1, Matrix operand2)
        {
            int[,] residual = new int[operand1.matrixHigh, operand1.matrixWidth];
            for (int i = 0; i < operand1.matrixHigh; i++)
            {
                for (int j = 0; j < operand1.matrixWidth; j++)
                {
                    residual[i, j] = operand1[i, j] - operand2[i, j];
                }
            }
            return new Matrix(residual);
        }
        public static Matrix operator *(Matrix operand1, int operand2)
        {
            int[,] result = new int[operand1.matrixHigh, operand1.matrixWidth];
            for (int i = 0; i < operand1.matrixHigh; i++)
            {
                for (int j = 0; j < operand1.matrixWidth; j++)
                {
                    result[i, j] = operand1[i, j] * operand2;
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator /(Matrix operand1, int operand2)
        {
            int[,] result = new int[operand1.matrixHigh, operand1.matrixWidth];
            for (int i = 0; i < operand1.matrixHigh; i++)
            {
                for (int j = 0; j < operand1.matrixWidth; j++)
                {
                    result[i, j] = operand1[i, j] / operand2;
                }
            }
            return new Matrix(result);
        }

        public static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.MatrixHigh; i++)
            {
                for (int j = 0; j < matrix.matrixWidth; j++)
                {
                    Console.Write("{0}", matrix[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
        }

    }
}
