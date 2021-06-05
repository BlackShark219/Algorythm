using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02Algorythm
{
    class Program
    {
        static double F1(double x)
        {
            return 0.5 - Math.Cos(x - 2);
        }
        static double F2(double y)
        {
            return Math.Sin(y + 2) - 1.5;
        }
        static double Fxy1(double x, double y)
        {
            return y + Math.Cos(x - 2) - 0.5;
        }
        static double Fxy2(double x, double y)
        {
            return Math.Sin(y + 2) - x - 1.5;
        }

        static void Main(string[] args)
        {

            AlgWrite(0, 0);
            Console.ReadKey();

        }

        static void AlgWrite(double x, double y)
        {
            double xk, yk, k = 1, max;
            do
            {
                xk = x;
                yk = y;
                x = F2(y);
                y = F1(x);

                if (Math.Abs(xk - x) > Math.Abs(yk - y)) { max = Math.Abs(xk - x); } else { max = Math.Abs(yk - y); }

                Console.WriteLine($"k={k} x={x,-10:F5} xk={xk,-10:F5} y={y,-10:F5} F2(y)={F2(y),-10:F5} F1={F1(x),-10:F5} max(|xk-x|)={max,-10:F5}");
                k++;
            } while (max > 0.0001 | max < -0.0001);
            Console.WriteLine($"y + cos(x - 2) - 0.5 = {Fxy1(x, y)}");
            Console.WriteLine($"sin(y + 2) - x - 1.5 = {Fxy2(x, y)}");
        }

        static void Checking(double x)
        {
            Console.WriteLine((0.5 - Math.Cos(x - 2)));
        }
    }
}