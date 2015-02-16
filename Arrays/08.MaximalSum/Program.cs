/* Write a program that finds the sequence of maximal sum in given array. */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string[] textAsArray = text.Split(new string[] { ", " }, StringSplitOptions.None);
        int[] input = new int[textAsArray.Length];
        for (int i = 0; i < textAsArray.Length; i++)
        {
            input[i] = int.Parse(textAsArray[i]);
        }
        int tempSum = 0, finalSum = 0, start = 0, end = 0;
        for (int i = 0; i < textAsArray.Length; i++)
        {
            tempSum += input[i];
            if (tempSum < 0)
            {
                tempSum = 0;
                start = i;
            }
            if (tempSum > finalSum)
            {
                finalSum = tempSum;
                end = i;
            }
        }
        for (int i = start; i <= end; i++)
        {
            Console.Write(i == end ? "{0}" : "{0}, ", input[i]);
        }
    }
}
