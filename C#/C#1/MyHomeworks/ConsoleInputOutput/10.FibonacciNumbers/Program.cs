/* Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
Note: You may need to learn how to use loops. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n+2];
        numbers[0] = 0;
        numbers[1] = 1;
        for (int i = 2; i < n+2; i++)
        {
            numbers[i] = numbers[i - 1] + numbers[i - 2];
            Console.Write("{0}, ",numbers[i-2]);
        }
    }
}
