using System;

#if VALUE_IS_DOUBLE
	using ValueType = System.Double;
#else
#if VALUE_IS_SHORT
	using ValueType = System.Int16;
#else
#if VALUE_IS_LONG
	using ValueType = System.Int64;
#else
using ValueType = System.Int32;
#endif
#endif
#endif

namespace Qsort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size");
            int n = Int32.Parse(Console.ReadLine());
            ValueType[] array = new ValueType[n];
            RandomFilling(array);
            Console.WriteLine("Random array:");
            Print(array);
            Sort(array);
            Console.WriteLine("\nSorted array:");
            Print(array);
            Console.ReadKey();
        }
        static void Print(ValueType[] array)
        {
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
        }
        static ValueType[] RandomFilling(ValueType[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            return array;
        }

        public static void Quicksort(ValueType[] numbers, int left, int right)
        {
            int i = left;
            int j = right;
            var pivot = numbers[(left + right) / 2];
            while (i <= j)
            {
                while (numbers[i] < pivot)
                    i++;
                while (numbers[j] > pivot)
                    j--;
                if (i <= j)
                {
                    var tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                Quicksort(numbers, left, j);
            if (i < right)
                Quicksort(numbers, i, right);
        }
        public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
        {
            Quicksort(data, 0, data.Length - 1);
            return data;
        }
    }
}
