using System;

namespace Shella
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size");
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Random array:");
            Print(RandomFilling(array));
            Console.WriteLine("\nSorted array:");
            Print(Sort(array));
            Console.ReadKey();
        }
        static void Print(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write("{0,4}", i);
            }
        }
        static int[] RandomFilling(int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            return array;
        }
        static int[] Sort(int[] array)
        {
            int d = array.Length / 2;
            for (; d > 1; d /= 2)
            {
                for (int i = 0; i + d < array.Length; i++)
                {
                    if (array[i] > array[i + d])
                    {
                        array = Swap(array, i, i + d);
                    }
                }
            }
            return Insert(array);
        }
        static int[] Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
            return array;
        }
        static int[] Insert(int[] array)
        {
            bool check = true;
            while (check)
            {
                check = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        check = true;
                        array = Swap(array, i, i + 1);
                    }
                }
            }
            return array;
        }
    }
}
