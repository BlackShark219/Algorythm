using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg4test
{
    class Program
    {
        public static int FindNearest(double[] xV, double x)
        {
            int i = 0;
            int min = 0;
            for (i = 0; i < 6; i++)
            {
                if ((Math.Abs(xV[min] - x) + Math.Abs(xV[min + 1] - x) + Math.Abs(xV[min + 2] - x) + Math.Abs(xV[min + 3] - x) >
                   (Math.Abs(xV[i + 1] - x) + Math.Abs(xV[i + 2] - x) + Math.Abs(xV[i + 3] - x) + Math.Abs(xV[i + 4] - x))))
                    min = i + 1;
            }
            return min;
        }

        public static double Lagrange(double[] xV, double[] yV, double i, int k, int kk)
        {
            double lagr = 0; int j1 , j2;
            for (int k1=k; k1 < kk; k1++)
            {
                double basicsPol = 1;
                for (j1 = k; j1 < kk; j1++)
                {
                    if (j1 != k1)
                    {
                        basicsPol *= (i - xV[j1]) / (xV[k1] - xV[j1]);
                    }

                }
                lagr += basicsPol * yV[k1];

            }
            return lagr;
        }

        public static double Der1(double[] xV, double[] yV, double i, int k, int kk)
        {
            double fDer;
            if (i==0)
            { fDer = (Lagrange(xV, yV, i+0.01, k, kk) - Lagrange(xV, yV, i, k, kk)) /  0.01; }
            else if (i == xV[9])
            { fDer = (Lagrange(xV, yV, i, k, kk) - Lagrange(xV, yV, i - 0.01, k, kk)) /  0.01
; }
            else
            { fDer = (Lagrange(xV, yV, i + 0.01, k, kk) - Lagrange(xV, yV, i - 0.01, k, kk)) / (2 * 0.01); }

            return fDer;
        }

        public static double Der2(double[] xV, double[] yV, double i, int k, int kk)
        {
            double fDer;
            /*if (i == 0)
            { fDer = ((Lagrange(xV, yV, i + 0.01, k, kk) - Lagrange(xV, yV, i, k, kk)) - (2 * Lagrange(xV, yV, i, k, kk))) / (0.01 * 0.01); }
            else if (i == xV[9])
            {
                fDer = (Lagrange(xV, yV, i, k, kk) - Lagrange(xV, yV, i - 0.01, k, kk)) / 0.01
  ;
            }
            else*/
            { fDer = (Lagrange(xV, yV, i + 0.01, k, kk) + Lagrange(xV, yV, i - 0.01, k, kk) - (2 * Lagrange(xV, yV, i, k, kk))) / (0.01 * 0.01); }

            return fDer;
        }



        static void Main(string[] args)
        {
            double[] xV = new double[10] { -0.11, 0.11, 0.24, 0.36, 0.56, 0.66, 0.89, 1.1, 1.39, 1.6 };
            double[] yV = new double[10] { 0.7764, 1.2382, 1.5394, 1.8374, 2.4101, 2.6780, 3.4356, 4.2396, 5.5884, 6.7991 }; int k = 0;
            int near = 0;
            double lPart = 0, lGlobal = 0, fDer1=0, fDer2=0;

            for (double i = 0; i < 1.5; i += 0.01)
            {
                near = FindNearest(xV, i);

                lPart = Lagrange(xV, yV, i, near, near + 3);
                lGlobal = Lagrange(xV, yV, i, 0, 9);

                fDer1 = Der1(xV, yV, i, near, near+3);
                fDer2 = Der2(xV, yV, i, near, near + 3);
                Console.WriteLine($" k={k,-7} i={i,-10:F4} F={Form(i),-15:F4} lPart={lPart,-15:F4} lGlobal={lGlobal,-20:F4} " +
                    $"F'={Form1(i),-15:F3} fDer1={fDer1,-20:F4} Form2={Form2(i),-15:F4} Der2={fDer2,-20:F4}");
                k++;
            }
            k = 0;

            Console.ReadKey();
        }
            


        public static double Form(double i)
        {
            return Math.Pow(3, i) + Math.Sin(i);
        }

        public static double Form1(double i)
        {
            return Math.Pow(3, i)*Math.Log(3) + Math.Cos(i);
        }

        public static double Form2(double i)
        {
            return Math.Pow(3, i) * Math.Log(3)* Math.Log(3) - Math.Sin(i);
        }
    }

}
