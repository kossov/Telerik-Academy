using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] message = new string[] { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
        string input = Console.ReadLine();
        long result = 0;
        for (int i = 0; i < message.Length; i++)
        {
            if (i == 10)
            {
                input = input.Replace(message[i], "A");
            }
            else if (i == 11)
            {
                input = input.Replace(message[i], "B");
            }
            else if (i == 12)
            {
                input = input.Replace(message[i], "C");
            }
            else
            {
                input = input.Replace(message[i], i.ToString());
            }
        }
        for (int i = input.Length - 1, count = 0; i >= 0; i--, count++)
        {
            int number = 0;
            if (input[i] == 'A')
                number = 10;
            else if (input[i] == 'B')
                number = 11;
            else if (input[i] == 'C')
                number = 12;
            else
            {
                number = Convert.ToInt32(input[i]-'0');
            }
            result += number*(long)Math.Pow(13, count);
        }
        Console.WriteLine(result);
    }
}