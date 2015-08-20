using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] text = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
        string[] textAsNumbers = new string[text.Length];
        int n = int.Parse(Console.ReadLine());
        string[] alphabet = new string[n];
        StringBuilder resultingNumbers = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            alphabet[i] = Console.ReadLine();
        }
        for (int i = 0; i < text.Length; i++)
        {
            textAsNumbers[i] = Convert.ToString(int.Parse(text[i]),2);
            textAsNumbers[i] = textAsNumbers[i].ToString().PadLeft(8, '0');
            resultingNumbers.Append(textAsNumbers[i].ToString());
        }
        string[] finalOnesSeparated = resultingNumbers.ToString().Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);
        int[] correspondingNumber = new int[n];
        char[] correspondingCharacter = new char[n];
        int count = 0;
        foreach (string item in alphabet)
        {
            correspondingCharacter[count] = Convert.ToChar(item.Substring(0, 1));
            correspondingNumber[count] = int.Parse(item.Substring(1));
            count++;
        }
        int onesCounter = 0;
        StringBuilder finalResult = new StringBuilder();
        foreach (string item in finalOnesSeparated)
        {
            onesCounter = item.Length;
            for (int i = 0; i < n; i++)
            {
                if (correspondingNumber[i] ==onesCounter)
                {
                    finalResult.Append(correspondingCharacter[i]);
                }
            }
        }
        Console.WriteLine(finalResult.ToString());
    }
}