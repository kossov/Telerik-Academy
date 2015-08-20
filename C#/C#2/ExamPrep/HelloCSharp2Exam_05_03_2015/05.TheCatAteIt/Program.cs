using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TheCatAteIt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder resultBuilder = new StringBuilder();
            List<int> resultList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int firstDigit = int.Parse(line[0]);
                int secondDigit = int.Parse(line[line.Length - 1]);
                for (int j = 2; j < line.Length - 1; j++)
                {
                    if (AddInfront(resultList, firstDigit, secondDigit))
                    {
                        if (line[j] == "before")
                        {
                            if (resultList.Contains(secondDigit))
                            { // 1 2 4
                                if (resultList.Contains(firstDigit))
                                {
                                    continue;
                                }
                                else
                                    resultList.Insert(0, firstDigit); // 1 2 5 4
                            }
                            else // 1 2
                            {
                                if (resultList.Contains(firstDigit))
                                {
                                    int firstDigitPosition = resultList.IndexOf(firstDigit); // 1 2 5
                                    resultList.Insert(firstDigitPosition, secondDigit);
                                }
                                else
                                {
                                    // resultList += string.Format("{0}{1}", firstDigit, secondDigit); // 1 2 5 4
                                    resultList.Insert(0, secondDigit);
                                    resultList.Insert(0, firstDigit);
                                }
                            }
                        }
                        else if (line[j] == "after")
                        {
                            if (resultList.Contains(secondDigit))
                            {
                                if (resultList.Contains(firstDigit))
                                {
                                    continue;
                                }
                                else
                                {
                                    int secondDigitPosition = resultList.IndexOf(secondDigit) + 1;
                                    resultList.Insert(secondDigitPosition, secondDigit);
                                }
                            }
                            else
                            {
                                if (resultList.Contains(firstDigit))
                                {
                                    int firstDigitPosition = resultList.IndexOf(firstDigit) + 1; // 1 2 5
                                    resultList.Insert(firstDigitPosition, secondDigit);
                                }
                                else
                                // result += string.Format("{0}{1}", secondDigit, firstDigit);
                                {
                                    resultList.Insert(0,firstDigit);
                                    resultList.Insert(0,secondDigit);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (line[j] == "before")
                        {
                            if (resultList.Contains(secondDigit))
                            { // 1 2 4
                                int secondDigitPosition = resultList.IndexOf(secondDigit);
                                if (resultList.Contains(firstDigit))
                                {
                                    continue;
                                }
                                else
                                    resultList.Insert(secondDigitPosition, firstDigit); // 1 2 5 4
                            }
                            else // 1 2
                            {
                                if (resultList.Contains(firstDigit))
                                {
                                    int firstDigitPosition = resultList.IndexOf(firstDigit) + 1; // 1 2 5
                                    resultList.Insert(firstDigitPosition, secondDigit);
                                }
                                else
                                // resultList += string.Format("{0}{1}", firstDigit, secondDigit); // 1 2 5 4
                                {
                                    resultList.Add(firstDigit);
                                    resultList.Add(secondDigit);
                                }
                            }
                        }
                        else if (line[j] == "after")
                        {
                            if (resultList.Contains(secondDigit))
                            {
                                if (resultList.Contains(firstDigit))
                                {
                                    continue;
                                }
                                else
                                {
                                    int secondDigitPosition = resultList.IndexOf(secondDigit) + 1;
                                    resultList.Insert(secondDigitPosition, firstDigit);
                                }
                            }
                            else
                            {
                                if (resultList.Contains(firstDigit))
                                {
                                    int firstDigitPosition = resultList.IndexOf(firstDigit) + 1; // 1 2 5
                                    resultList.Insert(firstDigitPosition, secondDigit);
                                }
                                else
                                // result += string.Format("{0}{1}", secondDigit, firstDigit);
                                {
                                    resultList.Add(secondDigit);
                                    resultList.Add(firstDigit);
                                }
                            }
                        }
                    }
                }
            }
            resultList.ForEach(Console.Write);
            Console.WriteLine();
        }
        static bool AddInfront(List<int> resultList, int firstDigit, int secondDigit)
        {

            for (int k = 0; k < resultList.Count; k++)
            {
                if (firstDigit > resultList[k])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
