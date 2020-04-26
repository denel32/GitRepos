using System;

namespace C_m_n_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C из m по n");
            Console.Write("m:");
            double m = double.Parse(Console.ReadLine());
            Console.Write("n:");
            double n = double.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n) / (Factorial(m) * Factorial(n - m)));
            Console.ReadKey();
        }
        static double Factorial(double num)
        {
            double res = 1;
            for (int i = 2; i <= num; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
