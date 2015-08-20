using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string[] punctuation = new string[] { " ", ",", ".", "(", ")", ";", "-", "!", "?" };
    static void Main(string[] args)
    {
        string searchWord = Console.ReadLine();
        int paragraphsNumber = int.Parse(Console.ReadLine());
        List<string> allParagraphs = new List<string>();
        List<int> count = new List<int>();
        for (int i = 0; i < paragraphsNumber; i++)
        {
            string[] line = Console.ReadLine().Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            int tempCount = 0;
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j].ToLower() == searchWord.ToLower())
                {
                    tempCount++;
                    line[j] = line[j].ToUpper();
                }
            }
            count.Add(tempCount);
            tempCount = 0;
            allParagraphs.Add(String.Join(" ", line));
        }
        List<string> result = new List<string>();
        while (result.Count < allParagraphs.Count)
        {
            int maxRelevent = 0;
            int maxIndex = 0;

            for (int i = 1; i < count.Count; i++)
            {
                if (maxRelevent < count[i])
                {
                    maxRelevent = count[i];
                    maxIndex = i;
                }
            }
            result.Add(allParagraphs[maxIndex]);
            count[maxIndex] = -1;
        }
        result.ForEach(Console.WriteLine);
    }
}