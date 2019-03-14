using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_laba2
{
    class Matrix
    {
        /// <summary>
        /// Вывод матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public static void Output(double[,] A, int n,int m)
        {
            for(int i = 0; i < n; i++)
            {
                for(int j=0;j<m;j++)
                    Console.Write(A[i,j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        /// <summary>
        /// Вывод вектора
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        public static void Output(double[] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(A[i]);
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        /// <summary>
        /// умножение матриц
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        public static double[,] MulMatrix(double[,] A, double[,] B, int n, int m, int k)
        {
            double[,] C = new double[n, k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    for (int c = 0; c < m; c++)
                    {
                        C[i, j] += A[i, c] * B[c, j];
                    }
                }
            }
            Output(C, n, k);
            return C;
        }
        /// <summary>
        /// Умножение матрицы на вектор
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        public static double[] MulMatrix(double[,] A, double[] B, int n, int m)
        {
            double[] C = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int c = 0; c < m; c++)
                {
                    C[i] += A[i, c] * B[c];
                }
            }
            Output(C, n);
            return C;
        }/// <summary>
         /// Ошибка матриц
         /// </summary>
         /// <param name="A"></param>
         /// <param name="n"></param>
         /// <param name="b"></param>
        public static void Error(double[,] A, int n, double b)
        {
            double myB = average(A, n);
            Console.WriteLine(" B = " + b);
            Console.WriteLine("new B = " + myB);
            Console.WriteLine("inccuracy = " + Math.Abs(b - myB) / b);
            // Console.WriteLine("inccuracy = " + Math.Abs(b - myB) / myB);
            Console.WriteLine("------------------------------------------------------------------");
        }
        /// <summary>
        /// Ошибка вектора
        /// </summary>
        /// <param name="B"></param>
        /// <param name="B_1"></param>
        /// <param name="n"></param>
        public static void Error(double[] B, double[] B_1, int n)
        {
            double b = average(B, n);
            double new_b = average(B_1, n);
            double incur = Math.Abs(b - new_b) / b;
            Console.WriteLine("inccuracy = " + incur);
        }
        /// <summary>
        /// Среднее квадратичное вектора
        /// </summary>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double average(double[] B, int n)
        {
            double delta = 0;
            for (int i = 0; i < n; i++)
                delta += B[i] * B[i];
            return delta = Math.Sqrt(delta);
        }
        /// <summary>
        /// Среднее квадратичное матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double average(double[,] A, int n)
        {
            double delta = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    delta += A[i, j] * A[i, j];
            }

            delta = Math.Sqrt(delta);
            return delta;
        } /// <summary>
          /// Из квадратной матрицы А получаем прямоугольную путем добавления столбца В
          /// </summary>
          /// <param name="A"></param>
          /// <param name="B"></param>
          /// <param name="n"></param>
          /// <returns></returns>
        public static double[,] ExtendedMatrix(double[,] A, double[] B, int n)
        {
            double[,] newA = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (j == n) newA[i, j] = B[i];
                    else newA[i, j] = A[i, j];
                }
            }
            return newA;
        }
        /// <summary>
        /// Получение столбца В из расширенной матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static double[] GetBFromExtendedMatrix(double[,] A, int n, int m)
        {
            double[] B = new double[n];
            for (int i = 0; i < n; i++)
                B[i] = A[i, m - 1];
            return B;
        }
    }
}
