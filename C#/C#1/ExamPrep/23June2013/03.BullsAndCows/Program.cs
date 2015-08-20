using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string dot = ".";
        string backslash = "\\";
        string slash = "/";
        string hashtag = "#";
        for (int i = 0; i < n / 2; i++)
        {
            for (int k = 0; k < n/2 - i - 1; k++)
            {
                Console.Write(dot);
                
            }
            Console.Write(hashtag);
            for (int k = 0; k < i; k++)
            {
                Console.Write(dot);

            }
            for (int k = 0; k < i; k++)
            {
                Console.Write(dot);

            }
            Console.Write(hashtag);
            for (int k = 0; k < n / 2 - i - 1; k++)
            {
                Console.Write(dot);

            }
            Console.WriteLine();
        }
        for (int i = 0; i < n/4; i++)
        {
            for (int l = 0; l < i; l++)
            {
                Console.Write(dot);

            }
            Console.Write(hashtag);
            for (int k = 0; k < n / 2 - i - 1; k++)
            {
                Console.Write(dot);

            }
            for (int l = 0; l < n/2-i-1; l++)
            {
                Console.Write(dot);

            }
            Console.Write(hashtag);
            for (int l = 0; l < i; l++)
            {
                Console.Write(dot);

            }

            Console.WriteLine();
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        for (int i = 0; i < n / 2; i++)
        {
            for (int l = 0; l < i; l++)
            {
                Console.Write(dot);
            }
            for (int j = 0; j < (n / 2) - i; j++)
            {
                Console.Write(backslash);
            }
            for (int k = 0; k < (n / 2) - i; k++)
            {
                Console.Write(slash);
            }
            if (i == 0)
            {
                Console.WriteLine();
                continue;
            }
            else
            {
                for (int h = 0; h < i; h++)
                {
                    Console.Write(dot);
                }
                Console.WriteLine();
            }
        }
    }
}
