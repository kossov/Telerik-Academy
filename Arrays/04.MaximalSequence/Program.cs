// Write a program that finds the maximal sequence of equal elements in an array.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter input numbers separeted by comma: ");
        string input = Console.ReadLine();
        string[] inputAsArray = input.Split(new string[] { ", " }, StringSplitOptions.None);
        int count = 0;
        int number = 0;
        for (int i = 0; i < inputAsArray.Length; i++)
        {
            string temp = inputAsArray[i];
            int tempNumber = 0, tempCount = 0;
            for (int j = 0; j < inputAsArray.Length; j++)
            {
                if (temp == inputAsArray[j])
                {
                    tempCount++;
                    tempNumber = Convert.ToInt32(inputAsArray[j]);
                    if (tempCount > count)
                    {
                        count = tempCount;
                        number = tempNumber;
                    }
                }
                else
                {
                    tempCount = 0;
                    tempNumber = 0;
                }
            }
        }
        for (int i = 0; i < count; i++)
        {
            if (i==count-1)
                Console.Write("{0}",number);
            else
            Console.Write("{0}, ",number);
        }
    }
}