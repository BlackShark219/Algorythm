using System;

namespace A3Lab
{
    class Program
    {
        static double X1(double x2, double x3)
        {
            return (1.7 + 0.2 * x2 - 0.9 * x3) / -1.9;
        }
        static double X2(double x1, double x3)
        {
            return (1.8 - 2.3 * x1 + 0.3 * x3) / 2.8;
        }
        static double X3(double x1, double x2)
        {
            return (2.5 - 1.4 * x1 - 1.9 * x2) / 3.7;
        }
        static void Main(string[] args)
        {
            int i = 0;
            double x1 = 0, x2 = 0, x3 = 0;
            double nextx1, nextx2, nextx3;
            Console.WriteLine("№ \t\t x1 \t\t\tx2 \t\t\tx3 \t\t\tПогрешность");
            do
            {
                i++;
                nextx1 = x1;
                nextx2 = x2;
                nextx3 = x3;
                x1 = X1(nextx2, nextx3);
                x2 = X2(nextx1, nextx3);
                x3 = X3(nextx1, nextx2);
                Console.WriteLine($"{i}\t \t {x1:f5} \t \t{x2:f5} \t\t{x3:f5} \t\t{Math.Max(Math.Abs(nextx1 - x1), Math.Max(Math.Abs(nextx2 - x2), Math.Abs(nextx3 - x3)))}");
            } while (Math.Abs(nextx1 - x1) > 0.0001 || Math.Abs(nextx2 - x2) > 0.0001 || Math.Abs(nextx3 - x3) > 0.0001);
            Console.WriteLine("Система решена методом Якоби" + "\n" + "Oтвет:");
            Console.WriteLine($"x1: {x1}");
            Console.WriteLine($"x2: {x2}");
            Console.WriteLine($"x3: {x3}");
            Console.WriteLine($"Вектор невязки по первому уравнению: {1.7 + 1.9 * x1 + 0.2 * x2 - 0.9 * x3}");
            Console.WriteLine($"Вектор невязки по второму уравнению: {1.8 - 2.3 * x1 - 2.8 * x2 + 0.3 * x3}");
            Console.WriteLine($"Вектор невязки по третьему уравнению: {2.5 - 1.4 * x1 - 1.9 * x2 - 3.7 * x3}");
            x1 = 0; x2 = 0; x3 = 0;
            Console.WriteLine();
            i = 0;
            Console.WriteLine("№ \t\t x1 \t\t\tx2 \t\t\tx3 \t\t\tПогрешность");
            do
            {
                i++;
                nextx1 = x1;
                nextx2 = x2;
                nextx3 = x3;
                x1 = X1(x2, x3);
                x2 = X2(x1, x3);
                x3 = X3(x1, x2);
                Console.WriteLine($"{i}\t \t {x1:f5} \t \t{x2:f5} \t\t{x3:f5} \t\t{Math.Max(Math.Abs(nextx1 - x1), Math.Max(Math.Abs(nextx2 - x2), Math.Abs(nextx3 - x3)))}");
            } while (Math.Abs(nextx1 - x1) > 0.0001 && Math.Abs(nextx2 - x2) > 0.0001 && Math.Abs(nextx3 - x3) > 0.0001);
            Console.WriteLine("Система решена методом Зейделя" + "\n" + "Oтвет:");
            Console.WriteLine($"x1: {x1}");
            Console.WriteLine($"x2: {x2}");
            Console.WriteLine($"x3: {x3}");
            Console.WriteLine($"Вектор невязки по первому уравнению: {1.7 + 1.9 * x1 + 0.2 * x2 - 0.9 * x3}");
            Console.WriteLine($"Вектор невязки по второму уравнению: {1.8 - 2.3 * x1 - 2.8 * x2 + 0.3 * x3}");
            Console.WriteLine($"Вектор невязки по третьему уравнению: {2.5 - 1.4 * x1 - 1.9 * x2 - 3.7 * x3}");
            Console.ReadKey();
        }
    }
}