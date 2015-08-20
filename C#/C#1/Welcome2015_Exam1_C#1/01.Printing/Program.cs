using System;

class Program
{
    static void Main()
    {
        /* 1100 students with 5 sheets of paper each = total 5500 sheets of paper.
5500 sheets of paper means 11 reams.
11 reams with price of 4.80 each = 52.80
 */
        uint N = uint.Parse(Console.ReadLine());
        uint S = uint.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
        uint realm = 500;
        uint sheetsOfPaper = N * S;
        double countRealms = 0.0;
        //for (int i = 0; i < sheetsOfPaper; i++)
        //{
            countRealms = (double)sheetsOfPaper / (double)realm;
        //    if (countRealms > sheetsOfPaper * 500)
        //    {
        //        countRealms = countRealms - 500;
        //        break;
        //    }

        //}
        Console.WriteLine("{0:F2}",countRealms * P);


    }
}
