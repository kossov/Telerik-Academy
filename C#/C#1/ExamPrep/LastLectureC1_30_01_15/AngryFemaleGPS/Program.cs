using System;
// not finished

class Program
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        n = Math.Abs(n);
        int sumEven = 0;
        int sumOdd = 0;
        int digit = (int)(n % 10);
        n /= 10;
        while (n != 0)
        {
            if (digit % 2 == 0)
            {
                sumEven += digit;
            }
            else
            {
                sumOdd += digit;
            }

        }
        if (sumEven < sumOdd)
        {
            Console.WriteLine("left {0}",sumOdd);
        }
        else if (sumEven==sumOdd)
        {
            Console.WriteLine("straight");
        }
        else
        {
            Console.WriteLine("right {0}",sumEven);
        }
        Console.WriteLine(digit);


    }

}

