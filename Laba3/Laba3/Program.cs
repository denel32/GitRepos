using System;

namespace Laba3
{
    struct MyFrac
    {
        public long nom, denom, min, max, gcf;
        public MyFrac(long nom_, long denom_)
        {
            //minus
            {
                nom = nom_;
                if ((nom_ < 0 && denom_ < 0) || (nom_ > 0 && denom_ > 0))
                {
                    nom = Math.Abs(nom_);
                }
                denom = Math.Abs(denom_);
            }
            //sproshennya
            {
                if (Math.Abs(nom) > denom)
                {
                    min = Math.Abs(denom);
                    max = Math.Abs(nom);
                }
                else
                {
                    max = Math.Abs(denom);
                    min = Math.Abs(nom);
                }
                while (min != 0 && max != 0)
                {
                    long tmp = max - min;
                    if (tmp > min)
                    {
                        max = tmp;
                    }
                    else
                    {
                        max = min;
                        min = tmp;
                    }
                }
                if (max != 0)
                {
                    gcf = max;
                }
                else
                    gcf = min;

                nom /= gcf;
                denom /= gcf;
            }
        }
        public override string ToString()
        {
            if (Math.Abs(nom) == denom)
            {
                return nom.ToString();
            }
            if (nom == 0)
            {
                return "0";
            }
            return nom + "/" + denom;
        }
    }
    class Program
    {
        static string ToStringWithIntegerPart(MyFrac f)
        {
            if (Math.Abs(f.nom) < f.denom)
            {
                return f.ToString();
            }
            long intpart = Math.Abs(f.nom) / f.denom;
            if (f.nom < 0)
            {
                return "-(" + intpart + "+" + (Math.Abs(f.nom) - intpart * f.denom) + "/" + f.denom + ")";
            }
            else
                return "(" + intpart + "+" + (Math.Abs(f.nom) - intpart * f.denom) + "/" + f.denom + ")";
        }
        static double DoubleValue(MyFrac f)
        {
            return Convert.ToDouble(Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom));
        }
        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
        }
        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }
        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return Multiply(f1, new MyFrac(f2.denom, f2.nom));
        }
        static MyFrac GetRGR113LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 4 * 1 * 1 - 1);
            for (int i = 2; i <= n; i++)
            {
                res = Plus(res, new MyFrac(1, 4 * i * i - 1));
            }
            return res;
        }
        static MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac res = Minus(new MyFrac(1, 1), new MyFrac(1, 2 * 2));
            for (int i = 3; i <= n; i++)
            {
                res = Multiply(res, Minus(new MyFrac(i, i), new MyFrac(1, i * i)));
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть дрiб (a/b)");
            string str = Console.ReadLine();
            MyFrac str2 = new MyFrac(Convert.ToInt64(str.Split("/")[0]), Convert.ToInt64(str.Split("/")[1]));
            {//якщо повернений результат спростився до цілого числа
                bool check = false;
                for (int i = 0; i < str2.ToString().Length; i++)
                {
                    if (str2.ToString()[i] == '/')
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine("Спрощення дробу\n" + str2);
                    Console.WriteLine("ToStringWithIntegerPart\n" + ToStringWithIntegerPart(str2));
                    Console.WriteLine("DoubleValue\n" + DoubleValue(str2));
                }
                else
                {
                    Console.WriteLine("Спрощення дробу\n" + str2);
                    Console.WriteLine("ToStringWithIntegerPart\n" + str2);
                    Console.WriteLine("DoubleValue\n" + str2);
                }
            }
            Console.WriteLine("Введiть два дроби для додавання(a/b c/d)");
            str = Console.ReadLine();
            string st1 = str.Split()[0];
            string st2 = str.Split()[1];
            Console.WriteLine(st1 + "+" + st2 + "=" + Plus(new MyFrac(Convert.ToInt64(st1.Split("/")[0]), Convert.ToInt64(st1.Split("/")[1])), new MyFrac(Convert.ToInt64(st2.Split("/")[0]), Convert.ToInt64(st2.Split("/")[1]))));
            Console.WriteLine("Введiть два дроби для вiднiмання(a/b c/d)");
            Enter(ref str, ref st1, ref st2);
            Console.WriteLine(st1 + "-" + st2 + "=" + Minus(new MyFrac(Convert.ToInt64(st1.Split("/")[0]), Convert.ToInt64(st1.Split("/")[1])), new MyFrac(Convert.ToInt64(st2.Split("/")[0]), Convert.ToInt64(st2.Split("/")[1]))));
            Console.WriteLine("Введiть два дроби для множення(a/b c/d)");
            Enter(ref str, ref st1, ref st2);
            Console.WriteLine(st1 + "*" + st2 + "=" + Multiply(new MyFrac(Convert.ToInt64(st1.Split("/")[0]), Convert.ToInt64(st1.Split("/")[1])), new MyFrac(Convert.ToInt64(st2.Split("/")[0]), Convert.ToInt64(st2.Split("/")[1]))));
            Console.WriteLine("Введiть два дроби для дiлення(a/b c/d)");
            Enter(ref str, ref st1, ref st2);
            Console.WriteLine(st1 + "/" + st2 + "=" + Divide(new MyFrac(Convert.ToInt64(st1.Split("/")[0]), Convert.ToInt64(st1.Split("/")[1])), new MyFrac(Convert.ToInt64(st2.Split("/")[0]), Convert.ToInt64(st2.Split("/")[1]))));
            Console.WriteLine("Введiть n>0");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("GetRGR113LeftSum\n" + GetRGR113LeftSum(n));
            Console.WriteLine("n/(2n+1)=" + new MyFrac(n, 2 * n + 1));
            Console.WriteLine("Введiть n>1");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("GetRGR115LeftSum\n" + GetRGR115LeftSum(n));
            Console.WriteLine("(n+1)/2n=" + new MyFrac(n + 1, 2 * n));
        }
        static void Enter(ref string str, ref string st1, ref string st2)
        {
            str = Console.ReadLine();
            st1 = str.Split()[0];
            st2 = str.Split()[1];
        }
    }
}
