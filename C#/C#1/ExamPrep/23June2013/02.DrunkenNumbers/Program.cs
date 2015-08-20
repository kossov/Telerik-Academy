using System;

class Program
{
    static void Main(string[] args)
    {
        // input
        int n;
        string testStringForNumberLength;
        int numberLength;
        n = int.Parse(Console.ReadLine());
        long[] drunkenNumber = new long[n];
        string cutM, cutV;
        int cutWhenEven = 0;
        char[] intoCharM = new char[(n / 2)+1];
        char[] intoCharV = new char[(n / 2)+1];
        int sumM = 0, sumV = 0;
        for (int i = 0; i < n; i++)
        {
            drunkenNumber[i] = long.Parse(Console.ReadLine());
            drunkenNumber[i] = Math.Abs(drunkenNumber[i]);
            if (drunkenNumber[i]==0)
            {
                break;
            }
            testStringForNumberLength = drunkenNumber[i].ToString();
            if (testStringForNumberLength.Length%2!=0)
            {
                numberLength = (testStringForNumberLength.Length / 2) + 1;
                cutM = testStringForNumberLength.ToString().Remove(numberLength);
                cutV = testStringForNumberLength.ToString().Remove(0, numberLength - 1);
                intoCharM = cutM.ToCharArray();
                intoCharV = cutV.ToCharArray();
                for (int j = 0; j < intoCharM.Length; j++)
                {
                    sumM += intoCharM[j] - '0';
                    sumV += intoCharV[j] - '0';
                } 
            }
            else
            {
                cutWhenEven = testStringForNumberLength.Length / 2;
                cutM = testStringForNumberLength.ToString().Remove(cutWhenEven);
                cutV = testStringForNumberLength.ToString().Remove(0, cutWhenEven);
                intoCharM = cutM.ToCharArray();
                intoCharV = cutV.ToCharArray();
                for (int k = 0; k < intoCharM.Length; k++)
                {
                    sumM += intoCharM[k] - '0';
                    sumV += intoCharV[k] - '0';
                } 
            }

        }

        // output MorV_(M - V ex. How much more beers)
        if (sumM>sumV)
        {
            Console.WriteLine("M "+(sumM-sumV));
        }
        else if (sumV>sumM)
        {
            Console.WriteLine("V "+(sumV-sumM));
        }
        else
        {
            Console.WriteLine("No "+(sumV+sumM));
        }

    }
}

