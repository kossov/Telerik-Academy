using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int counter = 0;
        long sum = 0;
        long test = 0;
        long tempNumber = 0;
        do
        {
            number /= 10;
            counter = 0;
            tempNumber = number;
            char[] numbers = new char[number.ToString().Length];
            int tempLenght = number.ToString().Length;
            for (int i = 0; i < number.ToString().Length; i++)
            {

                if (tempLenght % 2 == 0)
                {
                    if (counter % 2 == 0)
                    {
                        tempNumber /= 10;
                    }
                    else
                    {

                        test = tempNumber % 10;
                        sum += test;
                        tempNumber /= 10;
                    }
                    counter++;
                }
                //if (counter % 2 != 1)
                //{
                //    sum += test;
                //}

                    //tempNumber = tempNumber / 10;
                //counter++;
                else
                {
                    if (counter % 2 ==0)
                    {
                        test = tempNumber % 10;
                        sum += test;
                        tempNumber /= 10;
                    }
                    else
                    {
                        tempNumber /= 10;
                    }
                    counter++;
                }
            }

        } while (number > 0);

    }
}
