// Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max]. 
// Note: The above output is just an example. Due to randomness, your program most probably will produce different results.

using System;

class Program
{
    static void Main(string[] args)
    {
        int n, min, max;
        Console.Write("Enter N: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter Min: ");
        min = int.Parse(Console.ReadLine());
        Console.Write("Enter Max: ");
        max = int.Parse(Console.ReadLine());
        Random numbers = new Random();
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ",numbers.Next(min, max));
        }
        Console.WriteLine();
    }
}
