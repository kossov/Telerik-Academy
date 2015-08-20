/* Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
Your program should work well for very big numbers, e.g. n=100000. */

using System;
using System.Numerics;
class Program
{
    static void Main(string[] args) 
    { // apparently BigInteger has length of 24999 digits! :O also the program can be made by .isZero provided by BigInteger type but I went for the oldschool kinda way :) If your input is 100,000 keep in mind that you might have to wait a while.. like 30-60s dont think you are in some kinda loop that lasts forever ;)
        Console.Write("Enter N!: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger factoriel =1;
        int count = 0;
        
        for (int i = 0; i < n; i++)
        {
            factoriel *= (i + 1);
        }
        for (int j = 0; j < 25000; j++)
        {
            if (factoriel % 10 == 0)
            {
                factoriel /= 10;
                count++;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(count);
    }
}
