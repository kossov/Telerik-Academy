using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.TwoGirlsOnePath // 70/100
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long[] arrayCells = new long[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arrayCells[i] = long.Parse(input[i]);
            }
            int mollySteps = 0;
            int dollySteps = arrayCells.Length - 1;
            BigInteger mollyResult = 0;
            BigInteger dollyResult = 0;
            while (true)
            {

                mollyResult += arrayCells[mollySteps];
                int tempMollySteps = mollySteps;
                mollySteps = (int)((mollySteps + arrayCells[mollySteps]) % arrayCells.Length);
                arrayCells[tempMollySteps] = 0;

                dollyResult += arrayCells[dollySteps];
                int tempDollySteps = dollySteps;
                dollySteps = (int)((dollySteps - arrayCells[dollySteps]) % arrayCells.Length);
                if (dollySteps < 0)
                {
                    dollySteps += arrayCells.Length;
                }
                arrayCells[tempDollySteps] = 0;

                if (mollySteps == dollySteps)
                {
                    mollyResult += arrayCells[mollySteps] / 2;
                    mollySteps = (int)((mollySteps + arrayCells[mollySteps]) % arrayCells.Length);
                    dollyResult += arrayCells[dollySteps] / 2;
                    dollySteps = (int)((dollySteps - arrayCells[mollySteps]) % arrayCells.Length);
                    if (dollySteps < 0)
                    {
                        dollySteps += arrayCells.Length;
                    }
                    arrayCells[mollySteps] = arrayCells[mollySteps] % 2;
                }
                if (arrayCells[mollySteps] == 0 && arrayCells[dollySteps] == 0)
                {
                    Console.WriteLine("Draw");
                    Console.WriteLine("{0} {1}", mollyResult, dollyResult);
                    return;
                }
                if (arrayCells[mollySteps] == 0)
                {
                    Console.WriteLine("Dolly");
                    dollyResult += arrayCells[dollySteps];
                    Console.WriteLine("{0} {1}", mollyResult, dollyResult);
                    return;
                }
                if (arrayCells[dollySteps] == 0)
                {
                    Console.WriteLine("Molly");
                    mollyResult += arrayCells[mollySteps];
                    Console.WriteLine("{0} {1}", mollyResult, dollyResult);
                    return;
                }
            }
        }
    }
}
