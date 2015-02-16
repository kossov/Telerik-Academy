// Write a program that finds the most frequent number in an array.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter numbers separated by comma: ");
        string text = Console.ReadLine();
        string[] textAsArray = text.Split(new string[] { ", " }, StringSplitOptions.None);
        int[] input = new int[textAsArray.Length];
        for (int i = 0; i < textAsArray.Length; i++)
        {
            input[i] = int.Parse(textAsArray[i]);
        }
        int mostFrequent = 1, theNumber = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int currentNumber = input[i], currentMostFrequent = 0;
            foreach (int number in input)
            {
                if (currentNumber == number)
                {
                    if (mostFrequent <= currentMostFrequent)
                    {
                        theNumber = currentNumber;
                        mostFrequent++;
                    }
                    currentMostFrequent++;
                }
            }
        }
        Console.WriteLine("Most frequent number: {0} -> {1} Times",theNumber,mostFrequent);
    }
}
