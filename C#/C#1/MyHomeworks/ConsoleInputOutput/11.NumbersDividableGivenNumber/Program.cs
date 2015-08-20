/* Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0. */

using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        uint numOne = uint.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        uint numTwo = uint.Parse(Console.ReadLine());
        ushort pe=0;
        uint a = numTwo - numOne;
        for (int i = 0; i <= a; i++)
        {
            if (numOne++%5==0)
            {
                pe++;
            }
        }
        Console.WriteLine(pe);
    }
}

