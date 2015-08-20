/* In combinatorics, the Catalan numbers are calculated by the following formula: (2n)!/(n+1)!*n!
Write a program to calculate the nth Catalan number by given n (0 ≤ n ≤ 100). */

using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        BigInteger n = 0;
        n = InputN(n); // made by targeting all the things u want to include in the method > Right click > Refactor > Extract Method, if you want you can learn more about Methods.. but they save a lot of space ;) I just tried my first method here :P Also to get inside the method while you debug Press F11 while you are on the method line ;))
        BigInteger a = 2 * n, b = n + 1, twoTimesN = 1, nPlusOne = 1;
        BigInteger nFactoriel = 1;
        while (true)
        {
            if (a != 0)
            {
                twoTimesN *= a;
                a--;
            }
            else if (b != 0)
            {
                nPlusOne *= b;
                b--;
            }
            else if (n != 0)
            {
                nFactoriel *= n;
                n--;
            }
            else
            {
                break;
            }
        }
        BigInteger gosho = nPlusOne * nFactoriel;
        Console.WriteLine(twoTimesN / gosho);
    }
    private static BigInteger InputN(BigInteger n)
    {
        int correctInput = 0;
        do
        {
            Console.WriteLine("Please enter (0 <= N =< 100)");
            Console.Write("Enter N: ");
            bool parse = BigInteger.TryParse(Console.ReadLine(), out n);
            if (parse != false)
            {
                correctInput = 1;
            }
            else
            {
                correctInput = 0;
            }
        } while (correctInput == 1 && n > 100);
        return n;
    }
}
