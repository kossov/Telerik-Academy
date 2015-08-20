namespace RangeExceptions
{
    using System;

    public class RangeExceptionsTest
    {
        public static void Main(string[] args)
        {
            try
            {
                throw new InvalidRangeException<int>("Invalid input!", 1, 100);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n\n");

            try
            {
                throw new InvalidRangeException<DateTime>("Invalid date!", new DateTime(1980, 1, 1), new DateTime(2013,12,31));
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
