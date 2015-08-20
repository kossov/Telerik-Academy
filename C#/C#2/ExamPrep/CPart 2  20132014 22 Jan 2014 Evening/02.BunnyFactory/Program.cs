using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        List<int> inputNumbers = InputNumbers(input);
        StringBuilder afterSumAndProduct = new StringBuilder();
        BigInteger sum = 0, product = 1;
        int s = 0;
        for (int i = 0; i < inputNumbers.Count; i++)
        {
            for (int j = 0; j <= i; j++)
                s += inputNumbers[j];
            s = s + i;
            if (s >= inputNumbers.Count)
                break;
            for (int j = i + 1; j <= s; j++)
            {
                sum += inputNumbers[j];
                product *= inputNumbers[j];
            }
            afterSumAndProduct.Append(sum);
            afterSumAndProduct.Append(product);
            for (int j = s + 1; j < inputNumbers.Count; j++)
            {
                afterSumAndProduct.Append(inputNumbers[j]);
            }
            afterSumAndProduct.Replace("0", "");
            afterSumAndProduct.Replace("1", "");
            inputNumbers.Clear();
            for (int k = 0; k < afterSumAndProduct.Length; k++)
                inputNumbers.Add(afterSumAndProduct[k] - '0');
            afterSumAndProduct.Clear();
            sum = 0;
            product = 1;
            s = 0;
        }
        Console.WriteLine(string.Join(" ", inputNumbers));
    }
    static List<int> InputNumbers(string input)
    {
        List<int> inputNumbers = new List<int>();
        while (true)
        {
            input = Console.ReadLine();
            if (input == "END")
                break;
            inputNumbers.Add(int.Parse(input));
        }
        return inputNumbers;
    }
}
