// 05.12.13 BGCODER
using System;

class Program
{
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        long b =  long.Parse(Console.ReadLine());
        long c =  long.Parse(Console.ReadLine());
        long d = long.Parse(Console.ReadLine());

        decimal sum = (decimal)a / b + (decimal)c / d;
        if (sum >= 1)
        {
            Console.WriteLine(sum);

        }
        else
        {
            Console.WriteLine("{0:F22}",sum);
        }
        // a/b + c/d = (a*d + c*b) /b*d
        Console.WriteLine("{0}/{1}", (a * d + c * b), (b * d));
    }
}

