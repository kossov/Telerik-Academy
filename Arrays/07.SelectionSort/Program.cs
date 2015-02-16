/* Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc. */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the length of the array: ");
        int n = int.Parse(Console.ReadLine());
        List<int> switchArray = new List<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter {0} element: ", i + 1);
            switchArray.Add(int.Parse(Console.ReadLine()));
        }
        int tempMinValue = switchArray[0];
        int[] arr = new int[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - count; j++)
            {
                if (tempMinValue > switchArray[j])
                {
                    tempMinValue = switchArray[j];
                }
            }
            arr[i] = tempMinValue;
            switchArray.Remove(tempMinValue);
            count++;
            if (n == count) /* added because throws exception due to tempMinValue = switchArray[0] -> at the end there are 0 elements so [0] */
                break;                                                                                                       /* does not exist */
            tempMinValue = switchArray[0];
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
