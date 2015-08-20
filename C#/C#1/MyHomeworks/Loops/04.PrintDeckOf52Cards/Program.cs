/* Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
The card faces should start from 2 to A.
Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement. */

using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = new System.Text.ASCIIEncoding();
        char spades = '\u2660';
        char hearts = '\u2665';
        char diamonds = '\u2666';
        char clubs = '\u2663';
        int j = 0;
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0}{1}, {0}{2}, {0}{3}, {0}{4}", i + 1, spades, hearts, diamonds, clubs);
            if (i == 9)
            {
                for (; j < 4; j++)
                {
                    switch (j)
                    {
                        case 0: Console.WriteLine("J{0}, J{1}, J{2}, J{3}", spades, hearts, diamonds, clubs); break;
                        case 1: Console.WriteLine("Q{0}, Q{1}, Q{2}, Q{3}", spades, hearts, diamonds, clubs); break;
                        case 2: Console.WriteLine("K{0}, K{1}, K{2}, K{3}", spades, hearts, diamonds, clubs); break;
                        case 3: Console.WriteLine("A{0}, A{1}, A{2}, A{3}", spades, hearts, diamonds, clubs); break;
                        default:
                            break;
                    }
                }

            }

        }
    }
}

