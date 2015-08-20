/* Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
Use only one loop */

using System;

class Program
{
    static void Main(string[] args)
    {
        long k = 0, n = 0;
        Console.WriteLine("Please enter (1 < K < N < 100)");
        Console.Write("Enter N: ");
        n = long.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        k = long.Parse(Console.ReadLine());
        long factorielN = 1, factorielK = 1;
        if ((k > 0 && n > 0) && (k < 100 && n < 100) && (k < n))
        {
            while (true)
            {
                if (n != 0)
                {
                    factorielN *= n;
                    n--;
                }
                else if (k != 0)
                {
                    factorielK *= k;
                    k--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(factorielN / factorielK);
        }
        else
        {
            Console.WriteLine("Wrong Input!");
        }
    }
}
