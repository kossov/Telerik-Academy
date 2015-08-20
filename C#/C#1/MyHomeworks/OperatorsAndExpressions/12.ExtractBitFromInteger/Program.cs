// Write an expression that extracts from given integer n the value of given bit at index p.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter index p: ");
        int p = int.Parse(Console.ReadLine());
        byte result = (byte)((n >> p) & 1);
        Console.WriteLine("The value of {0} at #{1} is: {2}",n,p,result);
    }
}

