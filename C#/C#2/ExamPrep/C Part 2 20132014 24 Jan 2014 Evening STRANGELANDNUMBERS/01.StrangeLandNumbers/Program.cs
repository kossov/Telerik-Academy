using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] alphabet = new string[] {
            "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT"
        };
        string input = Console.ReadLine();
        BigInteger result = 0;
        ulong number = 0;
        for (int i = 0; i < alphabet.Length; i++)
        {
            input = input.Replace(alphabet[i], i.ToString());
        }
        for (int i = 0; i < input.Length; i++)
        {
            result *= 7;
            result += input[i]-'0';
        }
        Console.WriteLine(result);
    }
}
