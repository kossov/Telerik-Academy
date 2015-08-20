/* Create a console application that calculates and prints the square root of the number 12345.
Find in Internet “how to calculate square root in C#”. */

using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            double result;
            result = Math.Sqrt(12345);
            Console.WriteLine("{0}",result);
        }
    }
}
