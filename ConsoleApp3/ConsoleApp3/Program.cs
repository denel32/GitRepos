using System;
using System.Collections.Generic;


namespace ConsoleApp3
{
    class Program
    {
        //static void Main(string[] args)//https://ideone.com/VDtCdg   //Z1
        //{           
        //    int n = int.Parse(Console.ReadLine());//Розміри масиву n*m           
        //    int m = int.Parse(Console.ReadLine());
        //    int[,] array = new int[n, m];
        //    array = RandomFilling(array, ref n, ref m);//Створює рандомний масив та виводить його
        //    Print(array, ref n, ref m);
        //    Search(array, ref n, ref m);//Метод пошуку
        //}
        //static void Print(int[,] array, ref int n, ref int m)//Виводить усі елементи двовимірного масива
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            Console.Write("{0,8}", array[i, j]);
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //static int[,] RandomFilling(int[,] array, ref int n, ref int m)
        //{
        //    Random rand = new Random();
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            array[i, j] = rand.Next(-99, 99);
        //        }
        //    }
        //    return array;
        //}
        //static void Search(int[,] array, ref int n, ref int m)
        //{
        //    bool[] h = new bool[n];//Допоміжні масиви. h-визначае наявніть хочу б 1 від'ємного елемента в кожному рядку.            
        //    int[] sum = new int[n];//Sum-сума элементів кожного рядка, неважливо є там відємний елемент чи ні.
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            sum[i] += array[i, j];
        //            if (array[i, j] < 0)
        //            {
        //                h[i] = true;
        //            }
        //        }
        //    }
        //    for (int i = 0; i < h.Length; i++)//Перебирає всі єлементи булевого масиву. Якщо заходить елемент true, то виводить його індекс так елемент з масиву sum[i]
        //    {
        //        if (h[i])
        //        {
        //            Console.WriteLine("{0} {1}", i + 1, sum[i]);//Sum of elements of row №{0} with a negative number{1}
        //        }
        //    }
        //}


        //static void Main(string[] args)https://ideone.com/HUGfn5  //Z2
        //{
        //    int n = Int32.Parse(Console.ReadLine());//Enter square array size
        //    int[,] array = new int[n, n];
        //    array = RandomFilling(array, ref n, ref n);
        //    Print(array, ref n, ref n);//Random array
        //    int max = int.MinValue;
        //    int i = 0;//i,j -кординати початку перебору 
        //    int j = 0;
        //    int y1 = -1;//y1,x1 - кординати максимума головної діагоналі, y2,x2-побічної
        //    int x1 = -1;
        //    int y2 = -1;
        //    int x2 = -1;
        //    while (i < n)
        //    {
        //        if (array[i, j] > max)
        //        {
        //            max = array[i, j];
        //            y1 = i;
        //            x1 = j;
        //        }
        //        j++;
        //        i++;
        //    }
        //    Console.WriteLine("{0} ({1} {2})", max, y1, x1);// Max element of main diagonal is {0} with cords({1};{2})
        //    max = int.MinValue;
        //    i = 0;
        //    j = n - 1;
        //    while (i < n)
        //    {
        //        if (array[i, j] > max)
        //        {
        //            max = array[i, j];
        //            y2 = i;
        //            x2 = j;
        //        }
        //        i++;
        //        j--;
        //    }
        //    Console.WriteLine("{0} ({1};{2})", max, y2, x2);//Max element of side diagonal is {0} with cords ({1};{2})
        //    array = Swap(array, y1, x1, y2, x2);
        //    Print(array, ref n, ref n);//Changed array
        //}
        static void Main(string[] args)// https://ideone.com/JdWH8B             //Z3
        {
            Console.WriteLine("Enter start list");
            string str1 = Console.ReadLine();//Enter start list
            List<string> list = new List<string>(str1.Split());
            Console.WriteLine("Add elements to the list");
            string str2 = Console.ReadLine();//Add elements to the list
            List<string> listadd = new List<string>(str2.Split());
            foreach (string i in listadd)
            {
                list.Add(i);
            }
            Console.WriteLine("Increased list");
            foreach (string i in list)//Increased list
            {
                Console.Write("{0,-4}", i);
            }
        }
        //static int[,] Swap(int[,] array, int row1, int col1, int row2, int col2)
        //{
        //    int temp = array[row1, col1];
        //    array[row1, col1] = array[row2, col2];
        //    array[row2, col2] = temp;
        //    return array;
        //}
        //static void Print(int[,] array, ref int n, ref int m)//Виводить усі елементи двовимірного масива
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            Console.Write("{0,8}", array[i, j]);
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //static int[,] RandomFilling(int[,] array, ref int n, ref int m)
        //{
        //    Random rand = new Random();
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            array[i, j] = rand.Next(-99, 99);
        //        }
        //    }
        //    return array;
        //}
        //static void Main(string[] args) ///Z4 https://ideone.com/J37q8i
        //{
        //    int n = Int32.Parse(Console.ReadLine());//Enter array size n*m
        //    int m = int.Parse(Console.ReadLine());
        //    int[][] array = new int[n][];
        //    Random rand = new Random();
        //    for (int i = 0; i < n; i++)
        //    {
        //        array[i] = new int[m];
        //        for (int j = 0; j < m; j++)
        //        {
        //            array[i][j] = rand.Next(-99, 99);
        //        }
        //    }
        //    Stprint(array, n, m);//Random array          
        //    int K = int.Parse(Console.ReadLine());//Enter number of rows to add
        //    int T = int.Parse(Console.ReadLine());//Starting at element
        //    int firstindex = n - 1;
        //    int lastindex = n + K - 1;
        //    Array.Resize(ref array, n + K);
        //    while (firstindex >= T)//Копіює ті елементи номери яких зміняться після додавання нових рядків
        //    {
        //        array[lastindex] = array[firstindex];
        //        lastindex--;
        //        firstindex--;
        //    }
        //    int[] arr = new int[m];
        //    for (int j = 0; j < m; j++)
        //    {
        //        arr[j] = 101;//Для зручності все нові елементи будуть =101. У рандомному масививі елементи не перевищують 99 за модулем.
        //    }
        //    for (int p = 0; p < K; p++)//Записує у масив K нових рядків починаючи з номера T
        //    {
        //        array[T] = arr;
        //        T++;
        //    }
        //    Stprint(array, n + K, m);//Changed array
        //}
        //static void Stprint(int[][] array, int n, int m)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            Console.Write("{0,8}", array[i][j]);
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
