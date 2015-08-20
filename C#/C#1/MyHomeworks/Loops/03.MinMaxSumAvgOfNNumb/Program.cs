/* Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
The input starts by the number n (alone in a line) followed by n lines, each holding an integer number. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        uint n = uint.Parse(Console.ReadLine());
        int[] input = new int[n];
        int min = int.MaxValue;
        int max = int.MinValue;
        double avg = 0.0;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            Console.Write(": ");
            input[i] = int.Parse(Console.ReadLine());
            if (min > input[i])
            {
                min = input[i];
            }
            if (max < input[i])
            {
                max = input[i];
            }
            sum += input[i];
        }
        avg = sum / n;
        Console.WriteLine("The Minimal number is: "+min);
        Console.WriteLine("The Maximal number is: "+max);
        Console.WriteLine("The Sum of all numbers is: "+sum);
        Console.WriteLine("The Average of all numbers is: {0:F2}",avg);
    }
}

