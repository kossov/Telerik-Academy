// Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter r: ");
        double radius = double.Parse(Console.ReadLine());
        double area = Math.PI * radius * radius;
        double perimeter = 2 * Math.PI * radius;
        Console.WriteLine("perimeter: {0:0.00}\narea: {1:F2}",perimeter,area);
    }
}

