using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder extractedLetters = ExtractingLetters(input);
        MoveEachLetter(extractedLetters);
    }

    private static StringBuilder ExtractingLetters(string[] input)
    {
        StringBuilder result = new StringBuilder(input.Length);
        int count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int tempCount = input[i].Length;
            if (tempCount > count)
            {
                count = tempCount;
            }
        }

        for (int i = 0; i < count; i++)
        {
            foreach (string item in input)
            {
                if (item.Length > i)
                {
                    result.Append(item[item.Length - i - 1]);
                }
            }
        }
        return result;
    }
    private static void MoveEachLetter(StringBuilder letters)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            int itemNumber = 0;
            if (letters[i] >= 'A' && letters[i] <= 'Z')
            {
                itemNumber = letters[i] - 'A' + 1 + i;
            }
            if (letters[i] >= 'a' && letters[i] <= 'z')
            {
                itemNumber = letters[i] - 'a' + 1 + i;
            }
            int moveLetter = itemNumber;
            if (itemNumber > letters.Length - 1)
            {
                moveLetter %= (letters.Length);
            }
            char mySymbol = letters[i];
            letters.Remove(i, 1);
            letters.Insert(moveLetter, mySymbol);
        }
        Console.WriteLine(letters);
    }
}
