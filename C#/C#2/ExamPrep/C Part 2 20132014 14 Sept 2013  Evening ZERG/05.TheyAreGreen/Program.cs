using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char[] input = new char[n];
        for (int i = 0; i < n; i++)
        {
            input[i] = Convert.ToChar(Console.ReadLine());
        }
        Array.Sort(input);
        ulong count = 0;
        bool isValid = true;
        int shano = 0;
        do
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    isValid = false;
                    shano = 1;
                    break;
                }
               
            }
            if (shano == 0)
                isValid = true;
            shano = 0;
            if (isValid)
                count++;
        } while (NextPermutation(input));
        Console.WriteLine(count);
    }
    private static bool NextPermutation(char[] array)
    {
        for (int index = array.Length - 2; index >= 0; index--)
        {
            if (array[index] < array[index + 1])
            {
                int swapWithIndex = array.Length - 1;
                while (array[index] >= array[swapWithIndex])
                {
                    swapWithIndex--;
                }

                // Swap i-th and j-th elements
                var tmp = array[index];
                array[index] = array[swapWithIndex];
                array[swapWithIndex] = tmp;

                Array.Reverse(array, index + 1, array.Length - index - 1);
                return true;
            }
        }

        // No more permutations
        return false;
    }
}