/* Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n, has value of 1. */
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter index p: ");
        int p = int.Parse(Console.ReadLine());
        bool result = Convert.ToBoolean((n >> p) & 1);
        Console.WriteLine("bit @ p == 1 -> {0}",result);
    }
}

