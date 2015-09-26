using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class SquarredMatrix
    {
        static Random rnd = new Random();
        double[,] matrix = null;
        public SquarredMatrix(int sizeOfMatrix)
        {
            matrix = new double[sizeOfMatrix, sizeOfMatrix];

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 100);
                }
            }
        }

        public SquarredMatrix (double[,] matrixInArray)
        {
            matrix  = matrixInArray;
        }

        public SquarredMatrix()
        {
            matrix = new double[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
        }

        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public static double[,] MatrixToArray(SquarredMatrix inputMatrix)
        {
            double[,] result = new double[inputMatrix.SizeOfMatrix, inputMatrix.SizeOfMatrix];
            result = (double[,])inputMatrix.matrix.Clone();
            return result;
        }

        public int SizeOfMatrix
        {
            get { return (int)(Math.Sqrt(matrix.Length)); }
        }

        public static SquarredMatrix operator+ (SquarredMatrix operand1, SquarredMatrix operand2)
        {
            SquarredMatrix result = new SquarredMatrix(operand1.SizeOfMatrix);

            for (int i = 0; i < operand1.SizeOfMatrix; i++)
            {
                for (int j = 0; j < operand2.SizeOfMatrix; j++)
                {
                    result[i, j] = operand1[i, j] + operand2[i, j];
                }
            }
            return result;
        }

        public static SquarredMatrix operator- (SquarredMatrix operand1, SquarredMatrix operand2)
        {
            SquarredMatrix result = new SquarredMatrix(operand1.SizeOfMatrix);

            for (int i = 0; i < operand1.SizeOfMatrix; i++)
            {
                for (int j = 0; j < operand2.SizeOfMatrix; j++)
                {
                    result[i, j] = operand1[i, j] - operand2[i, j];
                }
            }
            return result;
        }

        public static SquarredMatrix MultiplyWithIdentityMatrix(SquarredMatrix inputMatrix)
        {
            SquarredMatrix result = new SquarredMatrix(inputMatrix.SizeOfMatrix);
            //copy inputMatrix to result
            return result;
        }

        public static void PrintMatrix(SquarredMatrix operand)
        {
            for (int i = 0; i < operand.SizeOfMatrix; i++)
            {
                for (int j = 0; j < operand.SizeOfMatrix; j++)
                {
                    Console.Write(operand[i,j] + " ");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("------------------------------");
        }

    }

    class Matrix<T>
    {
        static Random rnd = new Random();
        private T[,] internalData = null;
        public Matrix(int width, int height)
        {
            internalData = new T[width, height];
        }

       
    

    }
}
