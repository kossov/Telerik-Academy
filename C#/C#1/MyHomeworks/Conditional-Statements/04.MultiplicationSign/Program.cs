/* Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
Use a sequence of if operators. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());
        if (a <= 0 || b <= 0 || c <= 0)
        {
            if (a == 0 || b == 0 || c == 0) // 0 + + || 0 - +   => 0
            {
                Console.WriteLine("0");
            }
            else if ((a > 0 && b > 0) || (a > 0 && c > 0) || (b > 0 && c > 0) || (a < 0 && b < 0 && c < 0)) // - + +  || - - -    => -
            {
                Console.WriteLine("-");
            }
            else
            {
                if ((a < 0 && b < 0) || (a < 0 && c < 0) || (b < 0 && c < 0)) // - - +   => +
                {
                    Console.WriteLine("+");
                }

            }
        }
        else // + + +   => +
        {
            Console.WriteLine("+");
        }
    }
}

