// Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter 5 numbers: ");
        string input = Console.ReadLine();
        int sum = 0;
        string[] numbers = input.Split(' ');
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += int.Parse(numbers[i]);
        }
        Console.WriteLine(sum);
    }
}
