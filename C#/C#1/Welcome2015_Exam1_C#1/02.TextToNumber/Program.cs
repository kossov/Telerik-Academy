using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        int M = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        BigInteger result = 0;
        foreach (char symbol in input)
        {
            if (symbol=='@')
            {
                break;
            }
            else if ((symbol-'0'>=0) && (symbol-'9'<=9) && (symbol>=48 && symbol<=57))
            {
                result *= symbol-'0';
            }
            else if (symbol-'A'>=0 && symbol-'Z'<=25 && symbol<=90 && symbol>=65) // A = 65 a = 97 ; Z = 90 z = 122
            {
                result += symbol-'A';
            }
            else if (symbol-'a'>=0 && symbol-'z'<=25 && symbol>=97 && symbol<=122)
            {
                result += symbol - 'a';
            }
            else
            {
                result %= M;
            }

        }
        Console.WriteLine(result);
    }
}

