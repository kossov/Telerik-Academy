/* Using loops write a program that converts a binary integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality. */


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a Binary Integer: ");
        string input = Console.ReadLine();
        char[] inputAsArray = input.ToCharArray();
        double inputAsBinary = 0;
        for (int i = 0; i < inputAsArray.Length; i++)
        {
            inputAsBinary += (inputAsArray[inputAsArray.Length-1-i]-'0') * Math.Pow(2, i);
        }
        long doubleToLong = (long)inputAsBinary;
        Console.WriteLine(doubleToLong);
    }
}
