/* Using loops write a program that converts a hexadecimal integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality. */


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter an Hexadecimal Number: ");
        string input = Console.ReadLine();
        long result = 0;
        int i = 1;
        int letterInNumber = 0;
        foreach (char item in input)
        {
            if (((item+2 - '0') >= 0 ) && ((item+2 - '9') <= 9)) /* added +2 because we need if input is A to correspond to 10 after it is being substracted to '9' but A=65 -'9'('9'= 57 in ASCII) = 8 not 10.. so this +2 fixes our gap between the numbers and letters in ASCII used for hexadecimal purposes */
            {
                result += (long)((item - '0') * Math.Pow(16, (input.Length-i)));
                i++;
            }
            else
            {
                switch (item)
                {
                    case 'A': letterInNumber = 10; break;
                    case 'B': letterInNumber = 11; break;
                    case 'C': letterInNumber = 12; break;
                    case 'D': letterInNumber = 13; break;
                    case 'E': letterInNumber = 14; break;
                    case 'F': letterInNumber = 15; break;
                }

                result += (long)(letterInNumber * Math.Pow(16, (input.Length - i)));
                i++;
            }
        }
        Console.WriteLine(result);
    }
}
