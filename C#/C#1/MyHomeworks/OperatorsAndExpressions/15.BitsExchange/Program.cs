//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        uint num = uint.Parse(Console.ReadLine());
        Console.WriteLine("\nThe integer looks like:\n{0}\n", Convert.ToString(num, 2).PadLeft(32, '0'));
        for (int i = 3, k = 24; i < 6; i++, k++)
        {
            if (((num>>i) & 1) != ((num>>k) & 1))
            {
                uint gosho = (uint)(1 << i); // used to display the use of ^(XOR) sign
                Console.WriteLine(Convert.ToString(gosho, 2).PadLeft(32, '0')); // used to display the use of ^(XOR) sign
                num = num ^ (uint)(1 << i);
                Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0')); // used to see ever step of the binary digit transformation
                uint gosho2 = (uint)(1 << k);  // used to display the use of ^(XOR) sign
                Console.WriteLine(Convert.ToString(gosho2, 2).PadLeft(32, '0')); // used to display the use of ^(XOR) sign
                num ^= (uint)(1 << k);
                Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0')); // used to see ever step of the binary digit transformation
            }

        }
        Console.WriteLine(num);
        Console.WriteLine("binary result: {0}",Convert.ToString(num,2).PadLeft(32,'0'));
    }
}

