using System;
using static System.Math;

namespace laba1_1
{
    class Program
    {

        public static void AlgBis(double a, double b, double e)
        {
            Console.WriteLine("Bisection method from {0} to {1}", a, b);
            double x, f;
            int k = 0;
            Console.WriteLine("  {0,-7}{1,-14}{2,-14}{3,-14}{4,-14}{5,-14}{6,-14}", "k", "a", "x", "b", "|b-a|", "f(х)", "lg(|b-a|)"); Console.WriteLine();

            do
            {
                k += 1;
                x = (a + b) / 2.0;
                f = (Tan(2+(Pow(x,2))/(1+x)));
                Console.WriteLine("  {0,-7}{1,-14:G10}{2,-14:G10}{3,-14:G10}{4,-14:G7}{5,-14:G7}{6,-14:G8}", k, a, x, b, Abs(b - a), f, Log10(Abs(b - a))); Console.WriteLine();
                if (f == 0)
                {
                    Console.WriteLine("Знайдено корiнь:" + x);
                    break;
                }
                if ((Tan(2 + (Pow(a, 2)) / (1 + a))) * f > 0)
                { a = x; }
                else
                { b = x; }
            }
            while (Abs(f) >= e || Abs(a - b) >= e);
            Console.WriteLine($"Знайдено наближений корiнь: {x:F4} +- {Abs((b - a) / Pow(2, k)):E4}");
        }

        static void Main(string[] args)
        {

            AlgBis(1, 2.5, 0.0001); AlgBis(4, 5.5, 0.0001); AlgBis(7.4, 8.4, 0.0001);
            Console.WriteLine();
            AlgNew(1, 2.5, 0.0001);
            AlgNew(4, 5.5, 0.0001); AlgNew(7.4, 8.4, 0.0001);
            Console.ReadKey();
        }

        public static void AlgNew(double a, double b, double e)
        {
            Console.WriteLine("Newton method from {0} to {1}", a, b);
            double x, f;
            double xk = 0;
            double min = 0;
            int k = 0;

            do
            {
                k += 1;
                if (k == 1)
                {
                    if (Tan(2 + Pow(a, 2) / (1 + a) * ((2 + a) / (Pow(Cos(2 + Pow(a, 2) / (1 + a)), 2)) / Pow(1 + a, 2) - 2 * a * (2 + a) / (Pow(Cos(2 + Pow(a, 2)) / (1 + a), 2)) / Pow(1 + a, 3) + a / Pow(Cos(2 + Pow(a, 2) / (1 + a)), 2)) / Pow(1 + a, 2) + 1 / Pow(1 + a, 2) * 2 * a * 2 * a / (1 + a) - Pow(a, 2) / Pow(1 + a, 2) * (2 + a) * Tan(2 + Pow(a, 2) / (1 + a)) / Pow(Cos(2 + Pow(a, 2) / (1 + a)), 2)) > 0)
                    { x = a; }
                    else
                    { x = b; }
                    Console.WriteLine("  {0,-7}{1,-14}{2,-14}{3,-15}{4,-16}{5,-14}", "k", "x(k)", "x(k-1)", "|x(k)-x(k-1)|", "f(x)", "lg(|x(k)-x(k-1)|)"); Console.WriteLine();
                }
                else
                {
                    x = xk;
                }
                xk = x - (Tan(2 + Pow(x, 2) / (1 + x)) / x * (2 + x) / Pow(Cos(2 + Pow(x, 2) / (1 + x)), 2)) / Pow(1 + x, 2);
                f = (Tan(2 + (Pow(xk, 2)) / (1 + xk)));
                Console.WriteLine("  {0,-7}{1,-14:G8}{2,-14:G10}{3,-15:G8}{4,-16:G8}{5,-14:G8}", k, xk, x, Abs(xk - x), f, Log10(Abs(Abs(xk - x)))); Console.WriteLine();
                if (f == 0)
                {
                    Console.WriteLine("Знайдено корiнь:" + xk);
                    break;
                }
            }
            while (Abs(xk - x) >= e);
            double minfp = double.MaxValue;
            for (double fp; a <= b; a += 0.5)
            {
                fp = Abs(Tan(2 + (Pow(a, 2))));
                if (fp < minfp)
                {
                    minfp = fp;
                    min = a;
                }
            }
            Console.WriteLine($"Знайдено наближений корiнь: {x:F4} +- {Abs(f / min):E4}");
            Console.ReadKey();
        }
    }
}
