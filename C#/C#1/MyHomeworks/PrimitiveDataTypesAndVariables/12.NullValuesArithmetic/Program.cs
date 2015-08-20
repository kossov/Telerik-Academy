/* Create a program that assigns null values to an integer and to a double variable.
Try to print these variables at the console.
Try to add some number or the null literal to these variables and print the result. */

using System;

class Program
{
    static void Main(string[] args)
    {
        int? varOne = null;
        double? varTwo = null;
        Console.WriteLine("[{0}] , [{1}]",varOne,varTwo);
        varOne = 5;
        varTwo = 5.5;
        Console.WriteLine("[{0}] , [{1}]", varOne, varTwo);
    }
}

