/* We are given an integer number n, a bit value v (v=0 or 1) and a position p.
Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter index p: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter a bit value v: ");
        byte v = byte.Parse(Console.ReadLine());
        if (v == 0)
        {
            if ((n >> p) != 0)
            {
                int mask2 = 1 << p;
                int result2 = ~mask2 & n;
                Console.WriteLine(result2);
            }
        }
        else
        {
            int mask = (v << p);
            int result = mask | n;
            Console.WriteLine(result);
        }
    }
}

