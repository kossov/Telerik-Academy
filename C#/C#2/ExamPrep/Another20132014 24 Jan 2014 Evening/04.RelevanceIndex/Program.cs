using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RelevanceIndex // 100/100
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitters = new string[] { ",", ".", "(", ")", ";", "-", "!", "?", " " };
            string searchWord = Console.ReadLine();
            int lengthOfArray = int.Parse(Console.ReadLine());
            int[] relevanceIndex = new int[lengthOfArray];
            string[] allLines = new string[lengthOfArray];
            for (int i = 0; i < lengthOfArray; i++)
            {
                string[] line = Console.ReadLine().Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j].ToLower()==searchWord.ToLower())
                    {
                        relevanceIndex[i]++;
                        line[j] = line[j].ToUpper();
                    }
                }
                allLines[i] = string.Join(" ",line);
            }
            
            for (int i = 0; i < allLines.Length; i++)
            {
                int maxRelevanceIndex = int.MinValue;
                int tempIndex = 0;
                for (int j = 0; j < relevanceIndex.Length; j++)
                {
                    if (maxRelevanceIndex < relevanceIndex[j])
                    {
                        maxRelevanceIndex = relevanceIndex[j];
                        tempIndex = j;
                    }
                }
                relevanceIndex[tempIndex] = -1;
                Console.WriteLine(allLines[tempIndex]);
            }

        }
    }
}
