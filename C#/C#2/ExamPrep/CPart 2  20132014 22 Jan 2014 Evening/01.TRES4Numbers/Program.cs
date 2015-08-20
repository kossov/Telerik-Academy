using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] alphabet = new string[] { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
        ulong input = ulong.Parse(Console.ReadLine());
        if (input == 0)
        {
            Console.WriteLine(alphabet[0]);
            return;
        }
        StringBuilder result = new StringBuilder();
        int myNumber = 0;
        while (input>0)
        {
            myNumber = (int)(input % (ulong)9);
            result.Insert(0,alphabet[myNumber]);
            input /= 9;
        }
        Console.WriteLine(result.ToString());
    }
}