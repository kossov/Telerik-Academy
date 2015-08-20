using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int counter = 0, countingEven = 0;
        int sum = 0;
        foreach (char inputIntoCHar in input)
        {
            if (counter%2==0)
            {
                if ((inputIntoCHar-'0')>=0 && (inputIntoCHar-'0')<=9)
                {
                    sum += inputIntoCHar - '0';
                    countingEven++;
                }

            }
            counter++;
        }
        Console.WriteLine("{0} {1}",countingEven,sum);
    }
}
