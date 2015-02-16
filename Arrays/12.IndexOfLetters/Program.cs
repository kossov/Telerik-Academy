/* Write a program that creates an array containing all letters from the alphabet (A-Z).
Read a word from the console and print the index of each of its letters in the array. */

using System;

class Program
{
    static void Main(string[] args)
    {
        char[] alphabetLetters = new char[26];
        for (int i = 0; i < 26; i++)
        {
            alphabetLetters[i] = (char)(65 + i);
        }
        Console.Write("Enter word: ");
        string input = Console.ReadLine();
        input = input.ToUpper();
        foreach (char symbol in input)
        {
            for (int i = 0; i < 26; i++)
            {
                if (symbol == alphabetLetters[i])
                    Console.WriteLine("Index of symbol[{0}]: {1}", symbol.ToString().ToLower(), alphabetLetters[i] - 'A' + 1);
            }
        }
    }
}