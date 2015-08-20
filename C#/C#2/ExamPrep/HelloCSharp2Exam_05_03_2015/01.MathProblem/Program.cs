using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _01.MathProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
            uint sumInDecimal = 0;
            StringBuilder resultIn19thAsNumbers = new StringBuilder();
            StringBuilder resultIn19th = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                uint wordResult = 0;
                foreach (char symbol in input[i])
                {
                    wordResult *= 19;
                    wordResult += (uint)(symbol - 'a');
                }
                sumInDecimal += wordResult;
            }
            uint tempUse = sumInDecimal;
            while (tempUse > 0)
            {
                uint someTempValue = tempUse % 19;
                resultIn19thAsNumbers.Insert(0, (char)((tempUse % 19)+'a'));
                tempUse /= 19;
            }
            Console.WriteLine("{0} = {1}", resultIn19thAsNumbers, sumInDecimal);
        }
    }
}
