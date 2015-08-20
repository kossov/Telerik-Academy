using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._9gagNumbers
{
    class Program
    {
        static string CheckingForMatch(string input)
        {
            string result = string.Empty;
            switch (input)
            {
                case "-!": result = "0"; break;
                case "**": result = "1"; break;
                case "!!!": result = "2"; break;
                case "&&": result = "3"; break;
                case "&-": result = "4"; break;
                case "!-": result = "5"; break;
                case "*!!!": result = "6"; break;
                case "&*!": result = "7"; break;
                case "!!**!-": result = "8"; break;
                default: return "NO";
            }
            return result;
        }
        static void Main(string[] args)
        {
            string[] alphabet = new string[] { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
            string input = Console.ReadLine();
            StringBuilder resultingString = new StringBuilder(input);
            string letters = string.Empty;
            string final9thResult = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                letters += input[i];
                string returningMatch = CheckingForMatch(letters);
                if (returningMatch=="NO")
                {
                    continue;
                }
                else
                {
                    final9thResult += returningMatch;
                    letters = string.Empty;
                }
            }
            ulong result = 0;
            for (int i = 0; i < final9thResult.Length; i++)
            {
                result *= 9;
                result += (ulong)(final9thResult[i] - '0');
            }
            Console.WriteLine(result);
        }
    }
}
