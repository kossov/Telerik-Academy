/*Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
Use only one loop. Print the result with 5 digits after the decimal point. */

using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int factoriel = 1;
        double result = 0;
        for (int i = 0; i < n; i++)
        {
            factoriel *= (i + 1);
            result += factoriel / Math.Pow(x, (i+1));
        }
        Console.WriteLine("{0:F5}",result+1);
    }
}

