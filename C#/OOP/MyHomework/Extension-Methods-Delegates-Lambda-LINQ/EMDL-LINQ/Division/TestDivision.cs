namespace EMDL_LINQ.Division
{
    using System;
    using System.Collections;
    using System.Linq;

    public class TestDivision
    {
        static void MainQ(string[] args)
        {
            /* Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ. */

            int[] myIntArray = { 21, 42, 7, 3, 1, 5, 2, 6 };
            var devisibleNumbersUsingLinq = DevisibleBy7And3_UsingLINQ(myIntArray);
            Console.WriteLine("~~Testing DevisibleBy7And3_UsingLINQ~~");
            foreach (var item in devisibleNumbersUsingLinq)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var devisibleNumbersUsingLambda = DevisibleBy7And3_UsingLAMBDA(myIntArray);
            Console.WriteLine("~~Testing DevisibleBy7And3_UsingLAMBDA~~");
            foreach (var item in devisibleNumbersUsingLambda)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable DevisibleBy7And3_UsingLINQ(int[] arr)
        {
            var result =
                from number in arr
                where (number % 7 == 0 && number % 3 == 0)
                select number;
            return result;
        }

        private static IEnumerable DevisibleBy7And3_UsingLAMBDA(int[] arr)
        {
            var result = arr
                .Where(num => num % 7 == 0 && num % 3 == 0);
            return result;
        }
    }
}
