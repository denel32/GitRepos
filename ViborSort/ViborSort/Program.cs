using System;
using System.IO;

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

namespace SortTest
{
    class Program
    {
        static ValueType[] StringArrToValueArr(String[] data)
        {
            ValueType[] res = new ValueType[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i] = ValueType.Parse(data[i]);
            }
            return res;
        }

        static ValueType[] InputArrFromConsole()
        {
            Console.WriteLine("Вводьте елементи масива в один рядок, розділяючи одинарними пропусками. Кількість елементів вводити не треба.");
            return StringArrToValueArr(Console.ReadLine().Split());
        }

        static ValueType[] InputArrFromInputTxt()
        {
            StreamReader file = new StreamReader("input.txt");
            ValueType[] res = StringArrToValueArr(file.ReadLine().Split());
            file.Close();
            return res;
        }

        static void PrintArr(ValueType[] arr)
        {
            Console.WriteLine();
            foreach (var elem in arr)
            {
                Console.Write(" " + elem);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("(64){0} \n(16){1} \n(double){2}", Int64.MaxValue, Int16.MaxValue, Double.MaxValue);
            Console.WriteLine("Choose input type: 0 - from keyboard, any other - from \"input.txt\" file");
            String inputType = Console.ReadLine();
            ValueType[] data;
            if (inputType == "0")
            {
                data = InputArrFromConsole();
            }
            else
            {
                data = InputArrFromInputTxt();
            }
            ValueType[] arr = Sort(data);
            arr = Sort(arr);
            PrintArr(arr);
            Console.ReadKey();
        }
        static ValueType[] Sort(ValueType[] arr)//Сортування вибором.
        {
            ValueType min = ValueType.MaxValue;
            int res = -1;
            int o = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = o; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                        res = i;
                    }
                }
                Swap(ref arr, o, res);
                o++;
            }
            return arr;
        }
        static void Swap(ref ValueType[] arr, ValueType a, ValueType b)
        {
            ValueType temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
