/* Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
Use Windows Calculator to find its hexadecimal representation.
Print the variable and ensure that the result is 254. */

using System;

class Program
{
    static void Main(string[] args)
    {
        int var = 254;
        string varHexa = Convert.ToString(var, 16);
        Console.WriteLine("Variable: {0}, In Hexadecimal format: {1}",var,varHexa.ToUpper());
    }
}

