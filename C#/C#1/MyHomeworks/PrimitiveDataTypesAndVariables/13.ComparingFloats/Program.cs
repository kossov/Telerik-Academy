/* Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps. */

using System;

class Program
{
    static void Main(string[] args)
    {
        double numOne;
        double numTwo;
        double epsConstant = 0.000001;
        Console.Write("Enter the first number: ");
        numOne = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        numTwo = double.Parse(Console.ReadLine());
        Console.WriteLine("The difference is: {0}",Math.Abs(numOne - numTwo));
        if (Math.Abs(numOne - numTwo) < epsConstant)
        {
            bool equalWithPrecision = true;
            Console.WriteLine("The compare of the floating-point numbers is valid with precision 0.000001 ->{0}", equalWithPrecision);
        }
        else
        {
            bool equalWithPrecision = false;
            Console.WriteLine("The compare of the floating-point numbers is valid with precision 0.000001 ->{0}", equalWithPrecision);
        }
    }
}

