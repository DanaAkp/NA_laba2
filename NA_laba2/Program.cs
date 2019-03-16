using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            //double[,] A1 = new double[n, n] { { 2, 1, 0, 0, 0 }, { 3, 7, 3, 0, 0 }, { 0, 2, 6, 3, 0 }, { 0, 0, 1, 2, 1 }, { 0, 0, 0, 1, 2 } };
            //double[] d = new double[n] { 3, 13, 11, 4, 3 };
            double[,] A1 = new double[n, n] { { -0.871, -0.44, 0, 0, 0 }, { -0.823, 0.718, -0.016, 0, 0 }, { 0, 0.684, 1.885, 0.01, 0 }, { 0, 0, 1.778, -0.172, 0.6 }, { 0, 0, 0, -0.099, 0.416 } };
            double[] d = new double[n] { 0.628, 1.257, 1.885, 2.513, 3.142 };
            double[,] A = Matrix.ExtendedMatrix(A1, d, n);

            Matrix.Output(A1, n,n);
            Console.WriteLine("---------------------------------------------");
            double[] a = new double[n];
            double[] b = new double[n];
            double[] c = new double[n];

            for(int i = 0; i < n; i++)
            {
                if (i == 0) a[i] = 0;
                else a[i] = A[i, i - 1];

                if (i == n - 1) c[i] = 0;
                else c[i] = A[i, i + 1];

                b[i] = A[i, i];
            }
            //  Matrix.Output(A1, n, n);

            //Console.WriteLine("Vector a ");
            //Matrix.Output(a, n);
            //Console.WriteLine("Vector b");
            //Matrix.Output(b, n);
            //Console.WriteLine("Vector c ");
            //Matrix.Output(c, n);

            double[] alfa = new double[n];
            double[] beta = new double[n];
            alfa[0] = -(c[0] / b[0]);
            beta[0] = d[0] / b[0];

            for(int i = 1; i < n; i++)
            {
                alfa[i] = -(c[i] / (a[i] * alfa[i - 1] + b[i]));
                beta[i] = (d[i] - a[i] * beta[i - 1]) / (a[i] * alfa[i - 1] + b[i]);
            }
            Console.WriteLine("alfa");
            Matrix.Output(alfa, n);
            Console.WriteLine("beta");
            Matrix.Output(beta, n);

            double[] x = new double[n];
            x[n - 1] = (d[n - 1] - a[n - 1] * beta[n - 2]) / (a[n - 1] * alfa[n - 2] + b[n - 1]);
            for(int i = n - 2; i >= 0; i--)
            {
                x[i] = alfa[i] * x[i + 1] + beta[i];
            }
            Console.WriteLine("Vector X");
            Matrix.Output(x, n);

            Console.WriteLine("Error");
            Matrix.Error(d, Matrix.MulMatrix(A1, x, n, n), n);

            Console.ReadLine();
        }
    }
}
