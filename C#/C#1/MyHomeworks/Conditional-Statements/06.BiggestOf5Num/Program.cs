// Write a program that finds the biggest of five numbers by using only five if statements.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a(first): ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("Enter b(second): ");
        float b = float.Parse(Console.ReadLine());
        Console.Write("Enter c(third): ");
        float c = float.Parse(Console.ReadLine());
        Console.Write("Enter d(fourth): ");
        float d = float.Parse(Console.ReadLine());
        Console.Write("Enter e(fifth): ");
        float e = float.Parse(Console.ReadLine());
        if (a>b && a>c && a>d && a>e)
        {
            Console.WriteLine("A is biggest "+a);
        }
        else if (b > a && b > c && b > d && b > e)
        {
            Console.WriteLine("B is biggest "+b);
        }
        else if (c>b && c>a && c>d && c>e)
        {
            Console.WriteLine("C is biggest "+c);
        }
        else if (d>b && d>c && d>a && d>e)
        {
            Console.WriteLine("D is biggest "+d);
        }
        else
        {
            Console.WriteLine("E is biggest "+e);
        }
    }
}
