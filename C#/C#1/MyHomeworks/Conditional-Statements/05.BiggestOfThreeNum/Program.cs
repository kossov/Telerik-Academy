// Write a program that finds the biggest of three numbers.

using System;

class Program
{
    static void Main(string[] args)
    {
        double[] input = new double[3];
        double result = double.MinValue;
        for (int i = 0; i < 3; i++)
        {
        Console.Write("Enter [{0}] number: ",i+1);
        input[i] = double.Parse(Console.ReadLine());
        if (result<input[i])
        {
            result = input[i];
        }
        }
        Console.WriteLine(result);
    }
}
