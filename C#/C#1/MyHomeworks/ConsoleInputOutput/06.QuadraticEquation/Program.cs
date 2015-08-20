// Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter the third number c: ");
        double c = double.Parse(Console.ReadLine());
        double D = Math.Pow(b, 2) - 4 * a * c;
        if (D < 0)
        {
            Console.WriteLine("No real roots.");
        }
        else if (D == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("x1 = x2 = {0}", x);
        }
        else
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);

            Console.WriteLine("x1 = {0}\nx2 = {1}", x1, x2);
        }    
    }
}

