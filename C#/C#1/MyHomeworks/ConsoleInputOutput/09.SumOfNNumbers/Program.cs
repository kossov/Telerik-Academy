/* Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. Note: You may need to use a for-loop. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}Enter {1} more numbers{2}",new string('~',30),n,new string('~',30));
        double sum = 0;
        double input;
        for (int i = 0; i < n; i++)
        {
            Console.Write(":");
            input = double.Parse(Console.ReadLine());
            sum += input;
        }
        Console.WriteLine(new string(' ',40)+sum);
    }
}

