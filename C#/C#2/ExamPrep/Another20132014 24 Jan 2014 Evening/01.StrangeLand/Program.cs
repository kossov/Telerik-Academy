using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ConsoleApplication1 // 100/100
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger result = new BigInteger();
            string[] alphabet = new string[] { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
            string input = Console.ReadLine();
            for (int i = 0; i < alphabet.Length; i++)
            {
                input = input.Replace(alphabet[i], i.ToString());
            }
            for (int i = 0; i < input.Length; i++)
            {
                result *= 7;
                result += (input[i] - '0');
            }
            Console.WriteLine(result);
        }
    }
}
