/* Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line, separated by a space. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if ((i+1)%3!=0&&(i+1)%7!=0)
            {
                Console.Write("{0} ",i+1);
            }

        }
    }
}

