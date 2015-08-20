using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> inputWords = new List<string>();
        for (int i = 0; i < n; i++)
        {
            inputWords.Add(Console.ReadLine());
        }
        Reordering(inputWords, n);
        int count = 0, tempCount = 0;
        for (int i = 0; i < inputWords.Count; i++)
        {
            for (int k = 0; k <= inputWords[i].Length; k++)
            {
                if (tempCount >= count)
                {
                    count = tempCount;
                    tempCount++;
                }
                else
                    tempCount++;
            }
            tempCount = 0;
        }
        Printing(inputWords, count);
    }
    static void Reordering(List<string> words, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string myWord = words[i];
            int newPosition = myWord.Length % (n + 1);
            words[i] = null;
            words.Insert(newPosition, myWord);
            words.Remove(null);
        }
    }
    static void Printing(List<string> words, int n)
    {
        StringBuilder shano = new StringBuilder();
        for (int k = 0; k < n; k++)
        {

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length <= k)
                    continue;
                shano.Append(words[i][k]);
            }

        }
        Console.WriteLine(shano.ToString());
    }
}