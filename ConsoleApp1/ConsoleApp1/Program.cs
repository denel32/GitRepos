using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
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
            Search(array);
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
            for (int i = 1; i < array.Length; i++)
            {
                int l = 0;
                int r = i - 1;
                while (l < r)
                {
                    int m = (l + r) / 2;
                    if (array[m] < array[i])
                    {
                        l = m + 1;
                    }
                    else
                        r = m - 1;
                }
                int t = array[i];
                int j = i - 1;
                for (; j >= 0 && array[j] > t; j--)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = t;
            }
            return array;
        }
        static void Search(int[] array)
        {
            int n = 0;
            int sum = 0;
            foreach (int i in array)
            {
                if (i % 5 == 0)
                {
                    n++;
                    sum += i;
                }
            }
            Console.WriteLine("\nAmount of numbers divisible by 5 without remainder:{0}\n   Sum of numbers divisible by 5 without remainder:{1}", n, sum);
        }
    }
}
