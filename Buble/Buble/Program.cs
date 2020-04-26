using System;

namespace Buble
{
    class Program
    {
        static void Main(string[] args)//пузырь
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
        public static int[] Sort(int[] data) // DON'T CHANGE this line!!!
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                bool isChanged = false;
                for (int j = 0; j < data.Length - 1 - i; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        isChanged = true;
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
                if (isChanged == false)
                    break;
            }
            return data;
        }
    }
}
