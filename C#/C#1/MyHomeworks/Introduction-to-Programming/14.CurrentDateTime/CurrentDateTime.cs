// Create a console application that prints the current date and time. Find out how in Internet.
using System;

namespace CurrentDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myDateTime = DateTime.Now;
            Console.WriteLine(myDateTime);
        }
    }
}
