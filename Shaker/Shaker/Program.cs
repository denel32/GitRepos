using System;

namespace Shaker
{
    class Program
    {
        static void Main(string[] args)//шейкер
        {
            Console.WriteLine("Enter array size");
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];
            array = RandomFilling(array);
            Console.WriteLine("Random array:");
            Print(array);
            array = Sort(array);
            Console.WriteLine("\nSorted array:");
            Print(array);
            Console.ReadKey();
        }
        static void Print(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
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
            int l = 0;
            int r = array.Length - 1;
            while (l <= r)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                int maxnum = -1;
                int minnum = -1;
                for (int i = l; i <= r; i++)//maxsearch
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                        maxnum = i;
                    }
                }
                Swap(ref array, r, maxnum);
                for (int i = l; i <= r; i++)//minsearch
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                        minnum = i;
                    }
                }
                Swap(ref array, minnum, l);
                l++;
                r--;
            }
            return array;
        }
        static void Swap(ref int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;

        }
    }
}
