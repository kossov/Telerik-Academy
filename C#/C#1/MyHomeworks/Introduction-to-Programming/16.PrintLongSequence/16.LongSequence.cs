//Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
//You might need to learn how to use loops in C# (search in Internet).

using System;

    class Program
    {
        static void Main(string[] args)
        {
            int sequence=2;
            for (int i = 0; i <= 1002; i++)
            {
                if (sequence%2==0)
                {
                    Console.Write(sequence+", ");
                }
                else
                Console.Write("-{0}, ",sequence);
                sequence++;
            }
        }
    }