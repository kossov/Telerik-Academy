/* Write a program that, depending on the user’s choice, inputs an int, double or string variable.
If the variable is int or double, the program increases it by one.
If the variable is a string, the program appends * at the end.
Print the result at the console. Use switch statement. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        Console.Write("Please choose a type: ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Write("Please enter an integer: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}",num+1); break;
            case 2: 
                Console.Write("Please enter a double floating-point-number: ");
                double numDouble = double.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}",numDouble+1); break;
            case 3:
                Console.Write("Please enter a string: ");
                string aString = Console.ReadLine();
                Console.WriteLine("Result: "+aString+"*"); break;
            default: Console.WriteLine("Something went horribly wrong!");
                break;
        }
    }
}
