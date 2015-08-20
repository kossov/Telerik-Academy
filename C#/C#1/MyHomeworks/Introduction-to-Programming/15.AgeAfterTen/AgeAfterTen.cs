// Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.

using System;

class Program
{
    static void Main(string[] args)
    {
        int myAge;
        Console.Write("Enter your age:");
        myAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Your current age is:"+myAge);
        Console.WriteLine("Your age after Ten years will be:{0}",myAge+10);

    }
}

