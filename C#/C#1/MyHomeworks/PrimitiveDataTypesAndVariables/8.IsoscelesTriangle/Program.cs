/* Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
   ©

  © ©

 ©   ©

© © © © */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        char gosho = '\u00A9';
        Console.WriteLine(@"
                           {0}
                          {0} {0}
                         {0}   {0}
                        {0} {0} {0} {0}",gosho);
    }
}

