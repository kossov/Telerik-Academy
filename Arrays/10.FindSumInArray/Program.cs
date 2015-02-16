// Write a program that finds in given array of integers a sequence of given sum S (if present).

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter numbers separated by comma: ");
        string text = Console.ReadLine();
        Console.Write("Enter the sum: ");
        int sum = int.Parse(Console.ReadLine());
        string[] textAsArray = text.Split(new string[] { ", " }, StringSplitOptions.None);
        int[] input = new int[textAsArray.Length];
        for (int i = 0; i < textAsArray.Length; i++)
        {
            input[i] = int.Parse(textAsArray[i]);
        }
        int tempSum = 0;
        List<int> allNumbers = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            allNumbers.Add(input[i]);
            foreach (int number in input)
            {
                if (input[i] + number < sum)
                {
                    tempSum += input[i] + number;
                    allNumbers.Add(number);
                    if (tempSum > sum)
                    {
                        allNumbers.Clear();
                        allNumbers.Add(input[i]);
                        tempSum = 0;
                    }
                    else if (tempSum == sum)
                    {
                        Console.Write("The numbers that give sum {0} are:\n",sum);
                        allNumbers.ForEach(Console.WriteLine);
                        return;
                    }
                }
            }
            allNumbers.Clear();
        }
    }
}
