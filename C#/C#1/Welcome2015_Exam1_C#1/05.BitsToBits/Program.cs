using System;
using System.IO;
using System.Numerics;
class Program
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("..\\..\\sample-input.txt");
        Console.SetIn(reader);
        int n = int.Parse(Console.ReadLine());
        #region useless PositionVariables
        //int mostRightZeroPosition = -1;
        //int mostLeftZeroPosition = -1;
        //int mostRightOnePosition = -1;
        //int mostLeftOnePoisition = -1;
        #endregion
        int countZeroes = 0, countOnes = 0;
        int ones = 0, zeroes = 0;
        int tempCountZeroes = 0, tempCountOnes = 0;
        int[] input = new int[n];
        //string allOnesAndZeroes ="";
        BigInteger combined = 0;
        for (int i = 0; i < n; i++)
        {
            input[i] = int.Parse(Console.ReadLine());
            if (i!=0)
            {
                combined = input[i - 1] << 30 | input[i];
            }

            //int mask = ~(0 << 0);
            //int nAndMask = input & mask;
            //allOnesAndZeroes = ("{0}{1}",allOnesAndZeroes,Convert.ToString(nAndMask, 2)));
        }
        for (int i = 0; i < n; i++)
        {


            for (int j = 0; j < 30; j++)
            {
                BigInteger mask = 1 << j;
                BigInteger nAndMask = combined & mask;
                BigInteger bit = nAndMask >> j;
                if (bit == 1)
                {
                    tempCountOnes++;
                    if (countOnes < tempCountOnes)
                    {
                        countOnes = tempCountOnes;
                    }
                    tempCountZeroes = 0;

                    #region useless poisition Ones
                    //if (mostLeftOnePoisition == -1)
                    //{
                    //    mostLeftOnePoisition = j;
                    //}
                    //else
                    //{
                    //    mostRightOnePosition = j;
                    //}
                    #endregion
                }
                else
                {
                    tempCountZeroes++;
                    if (countZeroes < tempCountZeroes)
                    {
                        countZeroes = tempCountZeroes;
                    }
                    tempCountOnes = 0;

                    #region useless poisition Zeroes
                    //if (mostLeftZeroPosition == -1)
                    //{
                    //    mostLeftZeroPosition = j;
                    //}
                    //else
                    //{
                    //    mostRightZeroPosition = j;
                    //}
                    #endregion
                }
            }
            if (ones < countOnes)
            {
                ones = countOnes;
            }
            if (zeroes < countZeroes)
            {
                zeroes = countZeroes;
            }
            tempCountZeroes = 0;
            tempCountOnes = 0;
            countOnes = 0; countZeroes = 0;

        }
        Console.WriteLine(zeroes);
        Console.WriteLine(ones);
    }
}
