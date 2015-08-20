using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder input = new StringBuilder();
        input.Append(Console.ReadLine());
        int lengthOfCypher = LengthOfCypher(input);
        if (lengthOfCypher > 0)
            input = input.Remove(input.Length - lengthOfCypher.ToString().Length, lengthOfCypher.ToString().Length);
        input = EncodedString(input);
        string cypherKey = input.ToString().Substring(input.Length - lengthOfCypher, lengthOfCypher);
        input.Remove(input.Length - lengthOfCypher, lengthOfCypher);
        Encrypt(input, cypherKey);
    }
    static StringBuilder EncodedString(StringBuilder input)
    {
        char letter;
        int timesToPlaceLetter = 0, count = 0, anotherCounterJ = 0;
        for (int i = 0; i < input.Length; i++)
        {
            anotherCounterJ = i;
            while (true)
            {
                if (input[anotherCounterJ] < '0' || input[anotherCounterJ] > '9')
                {
                    letter = input[anotherCounterJ];
                    break;
                }
                timesToPlaceLetter = timesToPlaceLetter * (int)Math.Pow(10, count) + (input[anotherCounterJ] - '0');
                count++;
                anotherCounterJ++;
            }
            if (input[i] >= '0' && input[i] <= '9')
            {
                input.Replace(timesToPlaceLetter.ToString(), letter.ToString(), i, timesToPlaceLetter.ToString().Length);
                for (int j = 0; j < timesToPlaceLetter - 2; j++)
                {
                    input.Insert(i, letter);
                }
                i = timesToPlaceLetter - 1 + i;
            }
            timesToPlaceLetter = 0;
        }
        return input;
    }
    static int LengthOfCypher(StringBuilder input)
    {
        int lengthOfCypher = 0, count = 0;
        for (int i = input.Length - 1; ; i--)
        {
            if (input[i] < '0' || input[i] > '9')
            {
                break;
            }
            if (input[i] >= '0' && input[i] <= '9')
                lengthOfCypher = lengthOfCypher + (input[i] - '0') * (int)Math.Pow(10, count);
            count++;
        }
        return lengthOfCypher;
    }
    static void Encrypt(StringBuilder message, string cypher)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0, j = 0; i < message.Length; i++, j++)
        {
            int number = 0, jumping = 0;
            if (message.Length >= cypher.Length)
            {
                if (j == cypher.Length)
                    j = 0;
                number = (message[i] - 'A') ^ (cypher[j] - 'A');
                number += 65;
            }
            if (message.Length < cypher.Length)
            {
                jumping = i;
                number = (message[i] - 'A') ^ (cypher[i] - 'A');
                do
                {
                    jumping += 3;
                    //if (jumping == cypher.Length)
                    //{
                    //    jumping = 0;
                    //    break;
                    //}
                    if (jumping>=cypher.Length)
                    {
                        break;
                    }
                    number ^= (cypher[jumping] - 'A');
                } while (jumping < cypher.Length-1);
                number += 65;
            }
            result.Append((char)number);
        }
        Console.WriteLine(result.ToString());
    }
}