/* Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
The first and the second sequence of bits may not overlap. */


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        uint num = uint.Parse(Console.ReadLine());
        Console.Write("Enter P: ");
        uint p = uint.Parse(Console.ReadLine());
        Console.Write("Enter Q: ");
        uint q = uint.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        uint k = uint.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("\nThe integer looks like:\n{0}\n", Convert.ToString(num, 2).PadLeft(32, '0'));
        for (int i=(int)p,t=(int)q,j=(int)k; ((i < 32) && (t <32) && k>0); i++, t++, k--)
        {
            if (((num >> i) & 1) != ((num >> t) & 1))
            {
                uint gosho = (uint)(1 << i); // used to display the use of ^(XOR) sign
                Console.WriteLine(Convert.ToString(gosho, 2).PadLeft(32, '0')); // used to display the use of ^(XOR) sign
                num = num ^ (uint)(1 << i);
                Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0')); // used to see ever step of the binary digit transformation
                uint gosho2 = (uint)(1 << t);  // used to display the use of ^(XOR) sign
                Console.WriteLine(Convert.ToString(gosho2, 2).PadLeft(32, '0')); // used to display the use of ^(XOR) sign
                num ^= (uint)(1 << t);
                Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0')); // used to see ever step of the binary digit transformation
            }

        }
        Console.WriteLine(num);
        Console.WriteLine("binary result: {0}", Convert.ToString(num, 2).PadLeft(32, '0'));
    }
}

