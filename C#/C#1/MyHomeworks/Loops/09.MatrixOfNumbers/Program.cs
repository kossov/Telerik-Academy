/* Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. Use two nested loops. */

using System;

class Program
{
    static void Main(string[] args)
    {
        int n;
        do
        {
            Console.Write("Enter N: ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1 || n > 20);
        int num = 0;
        for (int column = 0; column < n; column++)
        {
            for (int row = 1; row <= n; row++)
            {
                Console.Write("{0} ",(row+num));
            }
            num++;
            Console.WriteLine();
        }
    }
}
