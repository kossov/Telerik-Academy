// Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int count = 1;
        List<int> arr = new List<int>();
        while (true)
        {
            Console.WriteLine("{0}{1}To stop entering elements enter 's'.", new string('!', count), new string(' ', count));
            Console.Write("Enter the [{0}] element: ", count);
            string input = Console.ReadLine();
            if (input == "s")
                break;
            arr.Add(Convert.ToInt32(input));
            count++;
        }
        Console.WriteLine();
        Console.Write("Enter the element that you want to find the index of: ");
        int findIndex = int.Parse(Console.ReadLine());
        arr.Sort();
        int index = arr.BinarySearch(findIndex);
        Console.WriteLine("The index of the element in this array is: {0}", index + 1);
    }
}
