using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.SumOfDifferences // 70/100
{
    class Program
    {
        static BigInteger absoluteDifference;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 1; ; )
            {
                bool evenJump = FindingAbsoluteDifference(input[i], input[i-1]);
                if (evenJump)
                    i += 2;
                else
                    i += 1;
                if (i>=input.Length)
                    break;
            }
            Console.WriteLine(absoluteDifference);
        }

        private static bool FindingAbsoluteDifference(int a, int b)
        {
            int larger = Math.Max(a, b);
            int smaller = 0;
            if (larger == a)
            {
                smaller = b;
            }
            else
            {
                smaller = a;
            }
            int tempAbsDiff = larger - smaller;
            if (tempAbsDiff % 2 == 0)
            {
                return true;
            }
            else
            {
                absoluteDifference += tempAbsDiff;
                return false;
            }
            
        }

    }
}
