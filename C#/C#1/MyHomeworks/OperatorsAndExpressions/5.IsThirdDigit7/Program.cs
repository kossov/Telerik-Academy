// Write an expression that checks for given integer if its third digit from right-to-left is 7.

using System;

class Program
{
    static void Main(string[] args)
    {
        int num;
        Console.Write("Enter an integer: ");
        num = int.Parse(Console.ReadLine());
        if ((num % 100 == 0) || (num % 10 == 0)) // check for more than 3 digit number
        {
            if ((num / 100) % 10 == 7 || (num / 100) % 10 == -7) // we need this OR(||) for the negative input values
            {
                Console.WriteLine("The third digit from right to left IS 7!");
            }
            else
            {
                Console.WriteLine("The third digit from right to left is NOT 7!");
            }
        }
        else
            Console.WriteLine("You have entered less than 3 digit number");
    }
}
