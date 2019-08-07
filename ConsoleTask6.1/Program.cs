using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Разработать тип для работы с матрицами из целочисленных значений. 
 *  Реализовать методы, позволяющие выполнять операции сложения, вычитания и умножения матриц, 
 * предусмотрев возможность их выполнения, в противном случае должно генерироваться соответствующее исключение.
 * Примечание: в методе main разместить код создания и использования матриц, обрабатывая возникающие при этом исключения */

namespace ConsoleTask6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixOperation matrixOperation = new MatrixOperation();
            int[,] a = { { 2, 4 }, { 3, 9 }, { 7, 8 } };
            int[,] b = { { 7, 3 }, { 5, 1 }, { 9, 11 } };
            int[,] c = { { 7, 3, 4 }, { 5, 1, 9 } };

            Console.WriteLine("Add matrixes: ");
            PrintMatrix(matrixOperation.MatrixAdd(a, b));
            Console.WriteLine();
            Console.WriteLine("Substract matrixes: ");
            PrintMatrix(matrixOperation.MatrixSubstract(a, b));
            Console.WriteLine();
            Console.WriteLine("Multiply matrixes: ");
            PrintMatrix(matrixOperation.MatrixMultiply(c, a));
            Console.WriteLine();

            Console.WriteLine("Add matrixes. Incorrect input: ");
            try
            {
                matrixOperation.MatrixAdd(a, c);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("Substract matrixes. Incorrect input: ");
            try
            {
                matrixOperation.MatrixSubstract(a, c);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("Multiply matrixes. Incorrect input: ");
            try
            {
                matrixOperation.MatrixMultiply(a, b);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        public static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class MatrixOperation
    {
        public int[,] MatrixAdd(int[,] a, int[,] b)
        {
            int[,] res = new int[a.GetLength(0), a.GetLength(1)];
            if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        res[i, j] = a[i, j] + b[i, j];
                    }
                }
            }
            else
            {
                throw (new ArgumentException("Matrix size is not suitable for perform Add operation"));
            }
            return res;
        }

        public int[,] MatrixSubstract(int[,] a, int[,] b)
        {
            int[,] res = new int[a.GetLength(0), a.GetLength(1)];
            if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        res[i, j] = a[i, j] - b[i, j];
                    }
                }
            }
            else
            {
                throw (new ArgumentException("Matrix size is not suitable for perform Add operation"));
            }
            return res;
        }
        public int[,] MatrixMultiply(int[,] a, int[,] b)
        {
            int[,] res = new int[a.GetLength(0), b.GetLength(1)];
            if (a.GetLength(0) == b.GetLength(1) && a.GetLength(1) == b.GetLength(0))
            {
                for (int i = 0; i < res.GetLength(0); i++)
                {
                    for (int j = 0; j < res.GetLength(1); j++)
                    {
                        res[i, j] = vectorsMultiply(getRow(a, i), getColumn(b, j));
                    }
                }
            }
            else
            {
                throw (new ArgumentException("Matrix size is not suitable for perform Multiply operation"));
            }
            return res;
        }

        private int vectorsMultiply(int[] v1, int[] v2)
        {
            int res = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                res += v1[i] * v2[i];
            }
            return res;
        }

        private int[] getColumn(int[,] a, int column)
        {
            return Enumerable.Range(0, a.GetUpperBound(0) + 1)
                      .Select(i => a[i, column])
                      .ToArray();
        }

        private int[] getRow(int[,] a, int row)
        {
            return Enumerable.Range(0, a.GetUpperBound(1) + 1)
                      .Select(i => a[row, i])
                      .ToArray();
        }
    }
}