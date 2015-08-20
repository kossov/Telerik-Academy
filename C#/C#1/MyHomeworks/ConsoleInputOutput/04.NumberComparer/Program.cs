/* Write a program that gets two numbers from the console and prints the greater of them.
Try to implement this without if statements. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("enter first number: ");
        int numOne = int.Parse(Console.ReadLine());
        Console.Write("enter second number: ");
        int numTwo = int.Parse(Console.ReadLine());
        Console.WriteLine("Greater is: {0}",numOne>numTwo ? numOne : numTwo);
    }
}
