/* Using loops write a program that converts an integer number to its binary representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a Number: ");
        long input = long.Parse(Console.ReadLine());
        string inputAsString = "";
        do
        {
            if (input % 2 != 0)
            {
                inputAsString = inputAsString + "1";
                input /= 2;
            }
            else if (input != 0 && input % 2 == 0)
            {
                inputAsString = inputAsString + "0";
                input /= 2;
            }
            else
            {
                break;
            }

        } while (true);
        char[] reverse = inputAsString.ToCharArray();
        Array.Reverse(reverse);
        Console.WriteLine(reverse);
    }
}
