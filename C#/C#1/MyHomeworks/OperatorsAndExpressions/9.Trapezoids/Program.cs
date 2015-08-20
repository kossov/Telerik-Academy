// Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the trapezoid's side A: ");
        float sideA = float.Parse(Console.ReadLine());
        Console.Write("Enter the trapezoid's side B: ");
        float sideB = float.Parse(Console.ReadLine());
        Console.Write("Enter the trapezoid's Height: ");
        float height = float.Parse(Console.ReadLine());
        float result = height * (sideA + sideB) / 2;
        Console.WriteLine("The trapezoid's area is: {0}",result);
    }
}

