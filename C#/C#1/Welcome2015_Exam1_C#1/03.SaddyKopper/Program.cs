using System;
using System.Numerics;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(1234 / 100);
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        BigInteger usedToFindEven = number;
        BigInteger usedToRemoveLastDigit = number;
        int counter = 0, countingEven = 0;
        BigInteger sum = 0;
        BigInteger theNumber = 0;
        usedToFindEven = usedToFindEven / 10;
        usedToRemoveLastDigit /= 10;
        BigInteger j = (BigInteger)(Math.Pow(10, usedToRemoveLastDigit.ToString().Length - 1));
        do
        {
            for (int i = 0; i < usedToRemoveLastDigit.ToString().Length; i++)
            {
                if (counter % 2 == 0)
                {
                    usedToFindEven /= j;
                    theNumber = usedToFindEven % 10;
                    sum += theNumber;
                    countingEven++;
                    j /= 100;
                }
                counter++;
                usedToFindEven = usedToRemoveLastDigit;
            }

            usedToRemoveLastDigit /= 10;
            j = (BigInteger)(Math.Pow(10, usedToRemoveLastDigit.ToString().Length - 1));
            usedToFindEven = usedToRemoveLastDigit;
            if (usedToRemoveLastDigit >= 10 && usedToRemoveLastDigit <= 99)
                counter = 1;
            counter = 0;
        } while (usedToRemoveLastDigit > 0);

    }
}