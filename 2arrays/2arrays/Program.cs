using System;
namespace _2arrays
{
    class Program
    {
        static void Print(int[,] array, int n)
        {
            for (int ii = 0; ii < 2 * n + 1; ii++)
            {

                for (int jj = 0; jj < 2 * n + 1; jj++)
                {
                    Console.Write("{0,3}", array[jj, ii]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[2 * n + 1, 2 * n + 1];
            array[n, n] = 0;
            int y1 = n - 1;   // верхня границя
            int y2 = n;   // нижня границя
            int x1 = n - 1;   // ліва границя
            int x2 = n;   // права границя
            int count = 0;

            for (int j = 0; j < n; j++)
            {
                for (int y = y2; y > y1; y--)   // проход вгору від y2 до (y1+1)
                {
                    array[x2, y] = count;
                    count++;
                }
                y2++;

                for (int x = x2; x > x1; x--)   // проход вліво
                {
                    array[x, y1] = count;
                    count++;
                }
                x2++;

                for (int y = y1; y < y2; y++)   // проход вниз
                {
                    array[x1, y] = count;
                    count++;
                }
                y1--;

                for (int x = x1; x < x2; x++)   // проход вправо
                {
                    array[x, y2] = count;
                    count++;
                }
                x1--;

            }

            for (int y = y2; y > y1; y--)   // додатковий один проход вгору
            {
                array[x2, y] = count;
                count++;
            }

            Print(array, n);
            Console.ReadKey();
        }

    }
}
