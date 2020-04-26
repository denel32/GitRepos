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

namespace shablon
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
        static void Main(string[] args)
        {

            ValueType[] data;
            data = StringArrToValueArr(Console.ReadLine().Split());
            PrintArr(Sort(data));
            Console.ReadKey();
        }
        static void PrintArr(ValueType[] arr)
        {
            foreach (var elem in arr)
            {
                Console.Write("{0,-3}", elem);
            }
        }
        //public static ValueType[] Sort(ValueType[] data)//quick
        //{
        //    int l = 0;
        //    int r = data.Length - 1;
        //restart:
        //    int i = l;
        //    int j = r;
        //    int pivot = data[(l + r) / 2];
        //    while (i <= j)
        //    {
        //        while (data[i] < pivot)
        //            i++;
        //        while (data[j] > pivot)
        //            j--;
        //        if (i <= j)
        //        {
        //            ValueType temp = data[i];
        //            data[i] = data[j];
        //            data[j] = temp;
        //            i++;
        //            j--;
        //        }
        //    }
        //    if (l < j)
        //    {
        //        r = j;
        //        goto restart;
        //    }
        //    if (i < r)
        //    {
        //        l = i;
        //        goto restart;
        //    }
        //    return data;
        //}
        //public static ValueType[] Sort(ValueType[] data)//shaker
        //{
        //    bool swapped = true;
        //    int start = 0;
        //    int end = data.Length;
        //    while (swapped == true)
        //    {
        //        swapped = false;
        //        for (int i = start; i < end - 1; ++i)
        //        {
        //            if (data[i] > data[i + 1])
        //            {
        //                ValueType temp = data[i];
        //                data[i] = data[i + 1];
        //                data[i + 1] = temp;
        //                swapped = true;
        //            }
        //        }
        //        if (swapped == false)
        //            break;
        //        swapped = false;
        //        end = end - 1;
        //        for (int i = end - 1; i >= start; i--)
        //        {
        //            if (data[i] > data[i + 1])
        //            {
        //                ValueType temp = data[i];
        //                data[i] = data[i + 1];
        //                data[i + 1] = temp;
        //                swapped = true;
        //            }
        //        }
        //        start = start + 1;
        //    }
        //    return data;
        //}
        //public static ValueType[] Sort(ref ValueType[] data, int l, int r)
        //{
        //    int i = l;
        //    int j = r;
        //    int pivot = data[(l + r) / 2];
        //    while (i <= j)
        //    {
        //        while (data[i] < pivot)
        //            i++;
        //        while (data[j] > pivot)
        //            j--;
        //        if (i <= j)
        //        {
        //            ValueType temp = data[i];
        //            data[i] = data[j];
        //            data[j] = temp;
        //            i++;
        //            j--;
        //        }
        //    }
        //    if (l < j)
        //        Sort(ref data, l, j);
        //    if (i < r)
        //        Sort(ref data, i, r);


        //    return data;
        //}
        //static void Swap(ref ValueType[] data, int a, int b)
        //{
        //    ValueType temp = data[a];
        //    data[a] = data[b];
        //    data[b] = temp;

        //}
        //public static ValueType[] Sort(ValueType[] data)
        //{
        //    int left = 0;
        //    int right = data.Length - 1;

        //    while (left < right)
        //    {
        //        for (int i = left; i < right; i++)
        //        {
        //            if (data[i] > data[i + 1])
        //            {
        //                Swap(ref data, i, i + 1);
        //            }
        //        }
        //        right--;

        //        for (int i = right; i > left; i--)
        //        {
        //            if (data[i - 1] > data[i])
        //            {
        //                Swap(ref data, i - 1, i);
        //            }
        //        }
        //        left++;
        //    }
        //    return data;
        //}
        //public static ValueType[] Sort(ValueType[] data)
        //{
        //    for (int i = 1; i < data.Length; i++)
        //    {
        //        int t = data[i];
        //        int j = i - 1;
        //        for (; j >= 0 && data[j] > t; j--)
        //        {
        //            data[j + 1] = data[j];
        //        }
        //        data[j + 1] = t;
        //    }
        //    return data;
        //}
        //public static ValueType[] Sort(ValueType[] data)
        //{
        //    bool check = true;
        //    while (check)
        //    {
        //        check = false;
        //        for (int i = 0; i < data.Length - 1; i++)
        //        {
        //            if (data[i] > data[i + 1])
        //            {
        //                check = true;
        //                ValueType temp = data[i];
        //                data[i] = data[i + 1];
        //                data[i] = temp;
        //            }
        //        }
        //    }
        //    return data;
        //}
    }
}
