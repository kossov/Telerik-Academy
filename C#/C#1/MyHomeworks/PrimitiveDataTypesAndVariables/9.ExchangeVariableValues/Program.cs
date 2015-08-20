/* Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
Print the variable values before and after the exchange. */

using System;

class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("Before exchange:\n a={0} b={1}",a,b);
        int c = a;
        a = b;
        b = c;
        Console.WriteLine("After exchange:\n a={0} b={1}",a,b);

    }
}

