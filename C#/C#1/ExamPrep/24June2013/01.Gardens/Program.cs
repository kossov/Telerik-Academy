using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Gardens
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = long.Parse(Console.ReadLine());
            long b = long.Parse(Console.ReadLine());
            long c = long.Parse(Console.ReadLine());
            long result = 0;
            if (b == 3)
            {
                result = a + c;
            }
            else if (b == 6)
            {
                result = a * c;
            }
            else if (b==9)
            {
                result = a % c;
            }
            if (result%3==0)
            {
                long resultAfterDevision = result / 3;
                Console.WriteLine(resultAfterDevision);
                Console.WriteLine(result);
            }
            else
            {
                long resultAfterDevision = result % 3;
                Console.WriteLine(resultAfterDevision);
                Console.WriteLine(result);
            }
        }
    }
}
