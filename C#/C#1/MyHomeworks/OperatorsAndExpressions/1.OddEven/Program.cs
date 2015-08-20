//Write an expression that checks if given integer is odd or even.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number:");
        uint convertToPositive;
        int num = int.Parse(Console.ReadLine());
        if (num < 0)
        {
            convertToPositive = (uint)num;
            string a = ((convertToPositive % 2 == 1) ? "value is negative odd" : "value is negative even");
            Console.WriteLine(a);
        }
        else
        {
            string b = ((num % 2 == 1) ? "value is odd" : "value is even");
            Console.WriteLine(b);
        }
    }
}

