using System;
using System.Collections.Generic;

class Program
{

    static void Main(string[] args)
    {
        List<int> arrOne = new List<int>();
        List<int> arrTwo = new List<int>();
        string input = "";
        Console.WriteLine("{0}Entering values for the FIRST ARRAY{1}", new string('~', 15), new string('~', 15));
        Console.WriteLine();
        input = FirstArray(arrOne, input);
        Console.WriteLine();
        Console.WriteLine("{0}Entering values for the SECOND ARRAY{1}", new string('~', 15), new string('~', 15));
        input = SecondArray(arrTwo, input);
        Console.WriteLine();
        int range = ComparingTheElements(arrOne, arrTwo);
        if (arrOne.Count!=arrTwo.Count)
            Console.WriteLine("Only {0} {1} compared, because arrays were not equal", range, range == 1 ? "element is" : "elements were");
        Console.WriteLine();
    }

    private static int ComparingTheElements(List<int> arrOne, List<int> arrTwo)
    {
        int range = 0;
        if (arrOne.Count <= arrTwo.Count)
        {
            range = arrOne.Count;
        }
        else
        {
            range = arrTwo.Count;
        }
        for (int i = 0; i < range; i++)
        {
            if (arrOne[i] == arrTwo[i])
            {
                Console.WriteLine("Element {0} in Array One:{1} , in Array Two:{2}", i, arrOne[i], arrTwo[i]);
                Console.WriteLine("Both elements are equal!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Element {0} in Array One:{1} , in Array Two:{2}", i, arrOne[i], arrTwo[i]);
                Console.WriteLine("Both elements are NOT equal!");
                Console.WriteLine();
            }
        }
        return range;
    }

    private static string SecondArray(List<int> arrTwo, string input)
    {
        int count = 1;
        while (true)
        {
            Console.WriteLine("You have entered {0} elements, type the letter 'e' stop entering numbers", count - 1);
            input = Console.ReadLine();
            if (input == "e")
            {
                break;
            }
            int temp = int.Parse(input);
            arrTwo.Add(temp);
            count++;
        }
        return input;
    }

    private static string FirstArray(List<int> arrOne, string input)
    {
        int count = 1;

        while (true)
        {
            Console.WriteLine("You have entered {0} elements, type the letter 'e' to switch to the second array", count - 1);
            input = Console.ReadLine();
            if (input == "e")
            {
                break;
            }
            int temp = int.Parse(input);
            arrOne.Add(temp);
            count++;
        }
        return input;
    }
}
