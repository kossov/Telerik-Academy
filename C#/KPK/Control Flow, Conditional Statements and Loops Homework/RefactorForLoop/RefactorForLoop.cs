namespace RefactorForLoop
{
    using System;

    internal class RefactorForLoop
    {
        internal static void Main(string[] args)
        {
            /*
                int i=0;
                for (i = 0; i < 100;)
                {
                    if (i % 10 == 0)
                    {
                        Console.WriteLine(array[i]);
                        if ( array[i] == expectedValue )
                        {
                            i = 666;
                        }
                        i++;
                    }
                    else
                    {
                    Console.WriteLine(array[i]);
                    i++;
                    }
                }
                // More code here
                if (i == 666)
                {
                    Console.WriteLine("Value Found");
                }
            */
        }

        internal static void Loop(int[] numbers, int expectedValue)
        {
            bool isFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentValue = numbers[i];

                if (i % 10 == 0 && currentValue == expectedValue)
                {
                    isFound = true;
                    break;
                }

                Console.WriteLine(currentValue);
            }

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
