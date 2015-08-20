using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();
        string cypherAndMessageEncrypted = Encrypt(message, cypher);
        Encode(cypherAndMessageEncrypted, cypher);
    }
    static string Encrypt(string message, string cypher)
    {
        StringBuilder result = new StringBuilder(message);
        for (int i = 0; i < Math.Max(message.Length, cypher.Length); i++)
        {
            int messageIndex = i % message.Length;
            int cypherIndex = i % cypher.Length;
            result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
        }
        return result.ToString();
    }
    static void Encode(string cypherMessage, string cypher)
    {
        StringBuilder result = new StringBuilder(cypherMessage.ToString() + cypher);
        int count = 1;
        for (int i = 1; i < result.Length; i++)
        {
            if (result[i] == result[i - 1])
            {
                count++;
            }
            else
            {
                if (count > 2)
                {
                    int resultLength = result.Length;
                    result.Remove(i - count, count - 1);
                    result.Insert(i - count, count);
                    i = i - count-2;
                    count = 0;
                }
                count = 1;
            }
        }
        result.Append(cypher.Length);
        Console.WriteLine(result);
    }
}