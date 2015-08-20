// Write a program that reads 3 real numbers from the console and prints their sum.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a: ");
        double numOne = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double numTwo = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double numThree = double.Parse(Console.ReadLine());
        Console.WriteLine(numOne+numTwo+numThree);
    }
}
