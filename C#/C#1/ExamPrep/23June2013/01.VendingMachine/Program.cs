using System;

class Program
{
    static void Main(string[] args)
    {
        // input // 0.05, 0.10, 0.20, 0.50, and 1.00 
        double n1 = double.Parse(Console.ReadLine());
        n1 *= 0.05;            
        double n2 = double.Parse(Console.ReadLine());
        n2 *= 0.10;
        double n3 = double.Parse(Console.ReadLine());
        n3 *= 0.20;
        double n4 = double.Parse(Console.ReadLine());
        n4 *= 0.50;
        double n5 = double.Parse(Console.ReadLine());
        n5 *= 1.00;
        double A = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
        double sum = n1+n2+n3+n4+n5;
        // logic
        double substract = A - P;
        if (A < P)
        {
            Console.WriteLine("More {0:F2}", (P - A));
        }
        else if ((A - P) <= sum)
        {
            Console.WriteLine("Yes {0:F2}", (sum - (A - P)));
        }
        else
        {
            Console.WriteLine("No {0:F2}", ((A - P) - sum));
        }
    }
}

