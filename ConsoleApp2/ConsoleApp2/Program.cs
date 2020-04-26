using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3 };
            
            
            array= Mtd(array);
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();

        }
        static int[] Mtd(int[] h)
        {
            Console.WriteLine();
            for (int i = 0; i < h.Length; i++)
            {
                h[i] *=3;
                Console.Write("{0} ", h[i]);
            }
            return h;

        }
    }
}
