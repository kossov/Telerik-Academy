﻿/* Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
Note: Some characters have a special purpose and will not be displayed as expected. You may skip them or display them differently.

Note: You may need to use for-loops (learn in Internet how). */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        for (int i = 0; i < 255; i++)
        {

            char asciiSymbols = Convert.ToChar(i);
            string test = asciiSymbols.ToString();
            Console.Write(test);
        }
    }
}

