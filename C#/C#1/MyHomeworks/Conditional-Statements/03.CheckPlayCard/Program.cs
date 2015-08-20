/* Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a card sign: ");
        string input = Console.ReadLine();
        if (string.Equals(input, "2") || string.Equals(input, "3") || string.Equals(input, "4") || string.Equals(input, "5") || string.Equals(input, "6") || string.Equals(input, "7") || string.Equals(input, "8") || string.Equals(input, "9") || string.Equals(input, "10") || string.Equals(input, "J") || string.Equals(input, "Q") || string.Equals(input, "K") || string.Equals(input, "A"))
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

