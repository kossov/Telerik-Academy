/* Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time. */

using System;

class Program
{
    static void Main(string[] args)
    {
        bool check = true; // the default boolean value is = False
        int num;
        Console.Write("Enter an integer: ");
        num = int.Parse(Console.ReadLine());
            if ((num % 7 == 0) && (num % 5 == 0 ))
            {
                Console.WriteLine("The entered value is dividable by 7 and 5 at the same time! -> {0}",check);
            }
            else
            {
                check = false;
                Console.WriteLine("The entered value is NOT devidiable by 7 and 5 at the same time! -> {0}",check);
            }
    }
}
