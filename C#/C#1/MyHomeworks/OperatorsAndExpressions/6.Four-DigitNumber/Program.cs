﻿/* Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
    Prints on the console the number in reversed order: dcba (in our example 1102).
        Puts the last digit in the first position: dabc (in our example 1201).
            Exchanges the second and the third digits: acbd (in our example 2101). 
   The number has always exactly 4 digits and cannot start with 0. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a four-digit number! Please");
        int num = int.Parse(Console.ReadLine());
        string result;
        result = Convert.ToString(num);
      
    
    }
}

