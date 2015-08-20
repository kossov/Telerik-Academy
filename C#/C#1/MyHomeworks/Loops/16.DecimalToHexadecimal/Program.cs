/* Using loops write a program that converts an integer number to its hexadecimal representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Decimal Number: ");
        long input = long.Parse(Console.ReadLine());
        string output = "";
        int counter = 1, n = 1;
        long difference = input, result;
        for (int i = 0; i < input.ToString().Length; i++)
        {
            if (difference > Math.Pow(16, counter))
            {
                counter++;
            }
            else
            {
                do
                {
                    counter--;
                    result = (long)(difference / Math.Pow(16, counter));
                    if (result > 9)
                    {
                        switch (result)
                        {
                            case 10: output = output + "A"; break;
                            case 11: output = output + "B"; break;
                            case 12: output = output + "C"; break;
                            case 13: output = output + "D"; break;
                            case 14: output = output + "E"; break;
                            case 15: output = output + "F"; break;
                        }
                    }
                    else
                    {
                        if (result == 0)
                            break;
                        output = output + result;

                    }
                    do
                    {
                        if (n * Math.Pow(16, counter) >= difference)
                        {
                            if (n * Math.Pow(16, counter) > difference)
                                n--;
                            difference = (long)(difference - n * Math.Pow(16, counter));
                            break;
                        }
                        else if (n * Math.Pow(16, counter) < difference)
                        {
                            n++;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    n = 0;
                } while (counter >= 0);
            }

        }
        Console.WriteLine(output);
    }
}

