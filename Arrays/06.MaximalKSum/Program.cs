/* Write a program that reads two integer numbers N and K and an array of N elements from the console.
Find in the array those K elements that have maximal sum. */

using System;

class Program
{
    static void Main(string[] args)//if I used Array.Sort its all about 1 for loop,that came to my mind later when I already made this program:((
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] input = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter [{0}] number: ",i+1);
            input[i] = int.Parse(Console.ReadLine());
        }
        int[] biggestNumbers = new int[k];
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            int temp = 0;
            foreach (int number in input)
            {
                if (i==0)
                {
                    if (temp < number)
                        temp = number;
                }
                else if (biggestNumbers[i-1]>number && number > temp)
                {
                    temp = number;
                }
            }
            biggestNumbers[i] = temp;
            sum += biggestNumbers[i];
        }
        Console.WriteLine("The biggest sum is {0} and is obtained by the numbers:",sum);
        for (int i = 0; i < k; i++)
        {
            Console.Write("{0} ",biggestNumbers[i]);
        }
        Console.WriteLine();
    }
}
