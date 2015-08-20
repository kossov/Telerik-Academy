/* In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter (1 < K < N < 100)");
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        long factorielN = 1, factorielK = 1, factorielNMinusK = 1;
        int nMinusK = n - k;
        if ((n > 0 && k > 0) && (n < 100 && k < 100) && (n > k))
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
            while (true)
            {
                if (nMinusK != 0)
                {
                    factorielNMinusK *= nMinusK;
                    nMinusK--;
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine(factorielN / (factorielK * factorielNMinusK)); // n! / (k! * (n-k)!)
        }
        else
        {
            Console.WriteLine("Wrong Input!");
        }
    }
}

