using System;

namespace lab5
{
    class Program
    {
        static double Function(double x, double a)
        {
            return Math.Exp(x * a) * (1 + x * x) * Math.Sin(x) / (x + 2);
        }
        static double Simpson(double a, double h = 0.001)
        {
            double I = 0;
            for (double x = 0; x < 1; x += h)
            {
                I += Function(x, a) + 4 * Function((x + x + h) / 2, a) + Function(x + h, a);
            }
            I *= h / 6;
            return I;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Iнтеграл обчислено з параметром а = 0.019");
            Console.WriteLine("I(a) = " + Simpson(0.019));
            Console.WriteLine("Iнтеграл обчислено з параметром а = 0.127");
            Console.WriteLine("I(a) = " + Simpson(0.127));
            Console.WriteLine("Iнтеграл обчислено з параметром а = 0.346");
            Console.WriteLine("I(a) = " + Simpson(0.346));
            Console.WriteLine("Iнтеграл обчислено з параметром а =0.417");
            Console.WriteLine("I(a) = " + Simpson(0.417));
            Console.WriteLine("Iнтеграл обчислено з параметром а = 0.527");
            Console.WriteLine("I(a) = " + Simpson(0.527));
            Console.WriteLine("Iнтеграл обчислено з параметром а = 0.696");
            Console.WriteLine("I(a) = " + Simpson(0.696));

            Console.Read();
        }
    }
}