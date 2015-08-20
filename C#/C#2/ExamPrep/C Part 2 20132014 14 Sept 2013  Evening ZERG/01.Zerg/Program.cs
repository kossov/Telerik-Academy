using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string[] alphabet = new string[] {
            "Rawr","Rrrr","Hsst","Ssst","Grrr","Rarr","Mrrr","Psst","Uaah","Uaha","Zzzz","Bauu","Djav","Myau","Gruh" };
    static void Main(string[] args)
    {
        
        string input = Console.ReadLine();
        string inputAs15 = ReturningIn15th(input);
        ulong result = 0;
        for (int i = 0; i < inputAs15.Length; i++)
        {
            result *= 15;
            if (inputAs15[i] >= '0' && inputAs15[i] <= '9')
                result += (ulong)(inputAs15[i] - '0');
            else
                result += (ulong)(inputAs15[i] + 10 - 'A');
        }
        Console.WriteLine(result);
    }
    static string ReturningIn15th(string input)
    {
                string result = string.Empty;
        for (int i = 0; i < input.Length; i += 4)
        {
            if (alphabet.Contains(input.Substring(i, 4)))
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j] == input.Substring(i, 4))
                    {
                        if (j <= 9)
                            result += j;
                        else
                            result += (char)('A' + (j - 10));
                    }
                }
            }
        }
        return result;
    }
}