/* Write a program that enters 3 real numbers and prints them sorted in descending order.
Use nested if statements. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        double numOne = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double numTwo = double.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        double numThree = double.Parse(Console.ReadLine());
        if (numOne>numTwo && numOne>numThree) // numOne is bigger
        {
            Console.WriteLine("1."+numOne);
            if (numTwo>numThree)
            {
                Console.WriteLine("2."+numTwo);
                Console.WriteLine("3."+numThree);
            }
            else
            {
                Console.WriteLine("2."+numThree);
                Console.WriteLine("3."+numTwo);
            }
        }
        else if (numTwo>numOne && numTwo>numThree) // numTwo is bigger
        {
            Console.WriteLine("1."+numTwo);
            if (numOne>numThree)
            {
                Console.WriteLine("2."+numOne);
                Console.WriteLine("3."+numThree);
            }
            else
            {
                Console.WriteLine("2."+numThree);
                Console.WriteLine("3."+numOne);
            }
        }
        else // numThree is bigger
        {
            Console.WriteLine("1."+numThree);
            if (numOne>numTwo)
            {
                Console.WriteLine("2."+numOne);
                Console.WriteLine("3."+numTwo);
            }
            else
            {
                Console.WriteLine("2."+numTwo);
                Console.WriteLine("3."+numOne);
            }
        }

    }
}

