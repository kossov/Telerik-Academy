using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = n, height = n, depth = n;

        Console.Write(new string(' ', n - 1));
        Console.Write(new string(':', n));
        Console.WriteLine();

        for (int j = 0; j < n - 2; j++)
        {
            Console.Write(new string(' ', n - 2 - j));
            Console.Write(':');
            Console.Write(new string('/', n - 2));
            Console.Write(':');
            Console.Write(new string('X', j));
            Console.Write(':');
            Console.WriteLine();
        }
        Console.Write(new string(':', n));
        Console.Write(new string('X',n-2));
        Console.Write(':');
        Console.WriteLine();
        for (int i = 0; i < n-2; i++)
        {
            Console.Write(':');
            Console.Write(new string(' ',n-2));
            Console.Write(':');
            Console.Write(new string('X',n-3-i));
            Console.Write(':');
            Console.WriteLine();
        }
        Console.Write(new string(':',n));
        Console.WriteLine();
    }
}
