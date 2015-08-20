/* Write an expression that checks if given positive integer number n (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1). */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a positive integer number( 0 ; 100 ): ");
        int num = int.Parse(Console.ReadLine());
        bool result = true.Equals((num % 2 != 0) && (num % 3 != 0) && (num % 5 != 0) && (num % 7 != 0));
        if (num < 2)
            result = false;
        if (num == 2)
            result = true;
        if (num == 3)
            result = true;
        if (num == 5)
            result = true;
        if (num == 7)
            result = true;
        Console.WriteLine("The given integer is prime? {0}",result);
    }
}

