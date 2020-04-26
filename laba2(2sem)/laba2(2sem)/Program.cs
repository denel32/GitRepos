using System;
using System.Collections.Generic;

namespace laba2_2sem_
{
    class Program
    {
        static void Z1()
        {
            Console.WriteLine("Enter array size");
            Console.Write("Rows:");
            int n = Int32.Parse(Console.ReadLine());
            Console.Write("Cols:");
            int m = int.Parse(Console.ReadLine());
            int[,] array = new int[n, m];
            array = RandomFilling(array, ref n, ref m);
            Console.WriteLine("Random array:");
            Print(array, ref n, ref m);
            Search(array, ref n, ref m);
            Rest();
        }
        static void Z2()
        {
            Console.WriteLine("Enter square array size");
            int n = Int32.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            Console.WriteLine("Random array:");
            array = RandomFilling(array, ref n, ref n);
            Print(array, ref n, ref n);
            int max = int.MinValue;
            int i = 0;
            int j = 0;
            int y1 = -1;
            int x1 = -1;
            int y2 = -1;
            int x2 = -1;
            while (i < n)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    y1 = i;
                    x1 = j;
                }
                j++;
                i++;
            }
            Console.WriteLine("Max element of main diagonal is {0} with cords ({1};{2})", max, y1, x1);
            max = int.MinValue;
            i = 0;
            j = n - 1;
            while (i < n)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    y2 = i;
                    x2 = j;
                }
                i++;
                j--;
            }
            Console.WriteLine("Max element of side diagonal is {0} with cords ({1};{2})", max, y2, x2);
            array = Swap(array, y1, x1, y2, x2);
            Console.WriteLine("Changed array:");
            Print(array, ref n, ref n);
            Rest();
        }
        static void Z3()
        {
            Console.Write("Enter size of start list:");
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                list.Add(rand.Next(-99, 99));
            }
            Console.WriteLine("Random list:");
            foreach (int i in list)
            {
                Console.Write("{0,4}", i);
            }
            Console.WriteLine("\nAdd elements to the list");
            string str = Console.ReadLine();
            List<string> listadd = new List<string>(str.Split());
            Console.WriteLine("Increased list:");
            foreach (string i in listadd)
            {
                list.Add(Convert.ToInt32(i));
            }
            foreach (int i in list)
            {
                Console.Write("{0,6}", i);
            }
            Console.WriteLine();
            Rest();
        }
        static void Z4()
        {
            Console.WriteLine("Enter array size");
            Console.Write("Rows:");
            int n = Int32.Parse(Console.ReadLine());
            Console.Write("Cols:");
            int m = int.Parse(Console.ReadLine());
            int[][] array = new int[n][];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    array[i][j] = rand.Next(-99, 99);
                }
            }
            Console.WriteLine("Random array:");
            Stprint(array, n, m);
            Console.Write("Enter number of rows to add:");
            int K = int.Parse(Console.ReadLine());
            Console.Write("Starting at element:");
            int T = int.Parse(Console.ReadLine());
            int firstindex = n - 1;
            int lastindex = n + K - 1;
            Array.Resize(ref array, n + K);
            while (firstindex >= T)
            {
                array[lastindex] = array[firstindex];
                lastindex--;
                firstindex--;
            }
            int[] arr = new int[m];
            for (int j = 0; j < m; j++)
            {
                arr[j] = 101;
            }
            for (int p = 0; p < K; p++)
            {
                array[T] = arr;
                T++;
            }
            Console.WriteLine("Changed array:");
            Stprint(array, n + K, m);
            Rest();
        }
        static void Print(int[,] array, ref int n, ref int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,8}", array[i, j]);
                }
                Console.WriteLine();

            }
        }
        static int[,] RandomFilling(int[,] array, ref int n, ref int m)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rand.Next(-99, 99);
                }
            }
            return array;
        }
        static void Search(int[,] array, ref int n, ref int m)
        {
            bool[] h = new bool[n];
            int[] sum = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i] += array[i, j];
                    if (array[i, j] < 0)
                    {
                        h[i] = true;
                    }
                }
            }
            for (int i = 0; i < h.Length; i++)
            {
                if (h[i] == true)
                {
                    Console.WriteLine("Sum of elements of row №{0} with a negative number{1}", i + 1, sum[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            Man();
        }
        static void Rest()
        {
            Console.Write("Another task?(y/n):");
            char answer = Convert.ToChar(Console.ReadLine());
            if (answer == 'y' || answer == 'Y')
            {
                Console.Clear();
                Man();
            }
        }
        static void Man()
        {
        restart:
            Console.Write("Task №(1,2,3,4):");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    Console.Clear();
                    Z1();
                    break;
                case "2":
                    Console.Clear();
                    Z2();
                    break;
                case "3":
                    Console.Clear();
                    Z3();
                    break;
                case "4":
                    Console.Clear();
                    Z4();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong key");
                    goto restart;
            }
        }
        static int[,] Swap(int[,] array, int row1, int col1, int row2, int col2)
        {
            int temp = array[row1, col1];
            array[row1, col1] = array[row2, col2];
            array[row2, col2] = temp;
            return array;
        }
        static void Stprint(int[][] array, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,8}", array[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}

