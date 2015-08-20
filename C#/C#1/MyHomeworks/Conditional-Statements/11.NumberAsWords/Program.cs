// Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("enter a number: ");
        int input = int.Parse(Console.ReadLine());
        int units = input % 10;
        int decimals = (input % 100) / 10;
        int decimalsSpecialTens = input % 100;
        int hundreds = input / 100;
        Console.WriteLine("{0} {1} {2} || SpecialTens = {3}", hundreds, decimals, units, decimalsSpecialTens); // Just a bit to explain my logic
        if (hundreds <= 0)
        {
            if (decimalsSpecialTens >= 10 && decimalsSpecialTens <= 19 || decimals == 1)
            {
                switch (decimalsSpecialTens)
                {
                    case 10: Console.WriteLine("Ten"); break;
                    case 11: Console.WriteLine("Eleven"); break;
                    case 12: Console.WriteLine("Twelve"); break;
                    case 13: Console.WriteLine("Thirteen"); break;
                    case 14: Console.WriteLine("Fourteen"); break;
                    case 15: Console.WriteLine("Fifteen"); break;
                    case 16: Console.WriteLine("Sixteen"); break;
                    case 17: Console.WriteLine("Seventeen"); break;
                    case 18: Console.WriteLine("Eighteen"); break;
                    case 19: Console.WriteLine("Nineteen"); break;
                    default:
                        break;
                }

            }
            else
            {

                switch (decimals)
                {
                    case 2: Console.WriteLine("Twenty"); break;
                    case 3: Console.WriteLine("Thirty"); break;
                    case 4: Console.WriteLine("Fourty"); break;
                    case 5: Console.WriteLine("Fifty"); break;
                    case 6: Console.WriteLine("Sixty"); break;
                    case 7: Console.WriteLine("Seventy"); break;
                    case 8: Console.WriteLine("Eighty"); break;
                    case 9: Console.WriteLine("Ninety"); break;
                    default:
                        break;
                }
                switch (units)
                {
                    case 0: Console.WriteLine("Zero"); break;
                    case 1: Console.WriteLine("One"); break;
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;
                    default: Console.WriteLine("Invalid Input! Not a digit!");
                        break;

                }
            }
        }
        else
        {
            switch (hundreds)
            {
                case 1: Console.WriteLine("One Hundred"); break;
                case 2: Console.WriteLine("Two Hundred"); break;
                case 3: Console.WriteLine("Three Hundred"); break;
                case 4: Console.WriteLine("Four Hundred"); break;
                case 5: Console.WriteLine("Five Hundred"); break;
                case 6: Console.WriteLine("Six Hundred"); break;
                case 7: Console.WriteLine("Seven Hundred"); break;
                case 8: Console.WriteLine("Eight Hundred"); break;
                case 9: Console.WriteLine("Nine Hundred"); break;
                default:
                    break;
            }
            if (decimalsSpecialTens >= 10 && decimalsSpecialTens <= 19 || decimals == 1)
            {
                switch (decimalsSpecialTens)
                {
                    case 10: Console.WriteLine("Ten"); break;
                    case 11: Console.WriteLine("Eleven"); break;
                    case 12: Console.WriteLine("Twelve"); break;
                    case 13: Console.WriteLine("Thirteen"); break;
                    case 14: Console.WriteLine("Fourteen"); break;
                    case 15: Console.WriteLine("Fifteen"); break;
                    case 16: Console.WriteLine("Sixteen"); break;
                    case 17: Console.WriteLine("Seventeen"); break;
                    case 18: Console.WriteLine("Eighteen"); break;
                    case 19: Console.WriteLine("Nineteen"); break;
                    default:
                        break;
                }

            }
            else
            {
                switch (decimals)
                {
                    case 2: Console.WriteLine("Twenty"); break;
                    case 3: Console.WriteLine("Thirty"); break;
                    case 4: Console.WriteLine("Fourty"); break;
                    case 5: Console.WriteLine("Fifty"); break;
                    case 6: Console.WriteLine("Sixty"); break;
                    case 7: Console.WriteLine("Seventy"); break;
                    case 8: Console.WriteLine("Eighty"); break;
                    case 9: Console.WriteLine("Ninety"); break;
                    default:
                        break;
                }
                switch (units)
                {
                    case 1: Console.WriteLine("One"); break;
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;
                    default:
                        break;

                }
            }
        }
    }
}

