// Write a program that finds the maximal increasing sequence in an array.

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
            int temp = Convert.ToInt32(inputAsArray[i]);
            int tempCount = 1;
            for (int j = 0; j < inputAsArray.Length; j++)
            {
                if (temp+1 == Convert.ToInt32(inputAsArray[j]))
                {
                    tempCount++;
                    if (tempCount > count)
                    {
                        count = tempCount;
                        number = temp+1;
                    }
                    temp++;
                }
                else
                {
                    tempCount = 1;
                    temp = Convert.ToInt32(inputAsArray[i]);
                }
            }
        }
        for (int i = 0; i < count; i++)
        {
            if (i == count - 1)
                Console.Write("{0}\n", number+i+1-count);
            else
                Console.Write("{0}, ", number+i+1-count);
        }
    }
}
