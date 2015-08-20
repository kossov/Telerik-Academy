/* Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
Use the Euclidean algorithm (find it in Internet). */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter A: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter B: ");
        int b = int.Parse(Console.ReadLine());
        while (a != 0 && b != 0)
        {
            if ((a > b && b>0) || (a<b && a<0))
                a %= b;
            else
                b %= a;
        }

        if (a == 0)
            Console.WriteLine(b);
        else
            Console.WriteLine(a);
    }
}

