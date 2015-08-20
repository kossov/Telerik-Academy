﻿/* Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
The bits are counted from right to left, starting from bit #0.
The result of the expression should be either 1 or 0. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter value: ");
        uint value = uint.Parse(Console.ReadLine());
        byte result = (byte)((value >> 3) & 1); 
        Console.WriteLine("The value of the bit 3 is: {0}",result);

    }
}

