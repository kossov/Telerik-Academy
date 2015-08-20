/* You are given n integers (given in a single line, separated by a space).
Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
Elements are counted from 1 to n, so the first element is odd, the second is even, etc. */

using System;

class Program
{
    static void Main(string[] args)
    {
        int productOdd = 1, productEven = 1;
        char[] thatsTheShitIDontLike = { ' ' };
        string input = Console.ReadLine();
        string[] inputString = input.Split(thatsTheShitIDontLike);
        int[] inNumbers = new int[inputString.Length];
        for (int i = 0; i < inputString.Length; i++)
        {
            inNumbers[i] = Convert.ToInt32(inputString[i]);
        }
        for (int i = 0, j = 1; i < inNumbers.Length; )
        {

            if (i <= inNumbers.Length-1)
            {
                productOdd *= inNumbers[i];
            }
            if (j <= inNumbers.Length-1)
            {
                productEven *= inNumbers[j];
            } 
            i = i + 2;
            j = j + 2;
        }
        Console.WriteLine("The Product {0}", int.Equals(productOdd, productEven) ? "IS Equal = "+productOdd : "IS NOT Equal\nOdd Product:"+productOdd+"\nEvenProduct:"+productEven);
    }
}

