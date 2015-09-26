using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.MatrixExample
{
    interface ICalculator<T>
    {
        T Add(T op1, T op2);
        T Substract(T op1, T op2);
        // etc....
    }

    class IntCalculator : ICalculator<int>
    {

        public int Add(int op1, int op2)
        {
            return op1 + op2;
        }

        public int Substract(int op1, int op2)
        {
            return op1 - op2;
        }
    }

    class Matrix<T, TCalc> where TCalc : ICalculator<T>, new()
    {
        private T[,] data;
        private readonly static ICalculator<T> calculator = new TCalc();

        public Matrix(int height, int width)
        {
            data = new T[height, width];
        }

        private void CheckIndex(int row, int col)
        {
            if (row >= data.GetLength(0) || col >= data.GetLength(1))
            {
                throw new IndexOutOfRangeException("Matrix index problem");
            }
        }

        public T this[int row, int col]
        {
            get
            {
                CheckIndex(row, col);
                return data[row, col];
            }
            set
            {
                CheckIndex(row, col);
                data[row, col] = value;
            }
        }

        public static Matrix<T, TCalc> operator +(Matrix<T, TCalc> op1, Matrix<T, TCalc> op2)
        { 
            int width1 = op1.data.GetLength(1);
            int width2 = op2.data.GetLength(1);
            int height1 = op1.data.GetLength(0);
            int height2 = op2.data.GetLength(0);
            if(width1 != width2 || height1 != height2)
            {
                throw new ApplicationException("Matrixes can not be added");
            }
            Matrix<T, TCalc> ret = new Matrix<T, TCalc>(height1, width1);
            for (int row = 0; row < height1; row++)
            {
                for (int col = 0; col < width1; col++)
                {
                    ret[row, col] = calculator.Add(op1[row, col], op2[row, col]);
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine(string.Format("Height: {0}\nWidth: {1}", data.GetLength(0), data.GetLength(1)));
            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    ret.AppendFormat("\t{0}", data[row, col]);
                }
                ret.AppendLine();
            }
            return ret.ToString();
        }
    }

    class MatrixExample
    {
        public static void Do()
        {
            Matrix<int, IntCalculator> myMatrix1 = new Matrix<int, IntCalculator>(3, 4);
            Matrix<int, IntCalculator> myMatrix2 = new Matrix<int, IntCalculator>(3, 4);
            myMatrix1[1, 1] = 5;
            myMatrix2[1, 1] = 5;
            Matrix<int, IntCalculator> myMatrix3 = myMatrix1 + myMatrix2;
            Console.WriteLine(myMatrix1);
            Console.WriteLine(myMatrix2);
            Console.WriteLine(myMatrix3);
            Console.ReadKey(true);
        }
    }
}
