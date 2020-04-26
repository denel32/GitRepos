using System;

namespace Lab_3
{


    class Program
    {

        static void Main(string[] args)
        {
            int res = 0;
            for (int i = 1000; i <  10000; i++)
            {
                if (i % 12 == 0 || i % 8 == 0)
                {
                    res++;
                }
            }
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}



