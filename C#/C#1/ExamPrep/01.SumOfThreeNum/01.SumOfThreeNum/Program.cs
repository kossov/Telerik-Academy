// Write a program that reads 3 real numbers from the console and prints their sum.

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] gosho = new int[3];
        int sum=0;
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter the [{0}] number: ");
            gosho[i] = int.Parse(Console.ReadLine());
            sum += gosho[i];
        }
        Console.WriteLine("The sum of the three numbers is: {0}" ,sum);

    }
}
