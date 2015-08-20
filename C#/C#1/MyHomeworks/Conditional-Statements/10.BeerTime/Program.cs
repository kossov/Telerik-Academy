/* A beer time is after 1:00 PM and before 3:00 AM.
Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times. */

using System;
class Program
{
    static void Main(string[] args)
    {
        System.Globalization.CultureInfo invariant = System.Globalization.CultureInfo.InvariantCulture;
        Console.Write("Enter hours:minutes AM/PM: ");
        string input = Console.ReadLine();
        DateTime toDateTime = DateTime.Parse(input);
        string beerTime = "01:00 PM";
        string toBeerTime = "03:00 AM";
        DateTime beer = DateTime.ParseExact(beerTime,"hh:mm tt",invariant);
        DateTime toBeer = DateTime.ParseExact(toBeerTime, "hh:mm tt", invariant);
        int test = DateTime.Compare(toDateTime, beer);
        int test2 = DateTime.Compare(toDateTime, toBeer);
        if (test>=0 || test2<0)
        {
            Console.WriteLine("IT IS BEER TIME!");
        }
        else
	{
            Console.WriteLine("IT IS NOT BEER TIME!");
	}
        //// var entered = DateTime.ParseExact(input, "hh:mm tt", invariant);

        //Console.WriteLine(toDateTime);
        ////int canWe = DateTime.Compare(understand, beerTime)
        ////if (understand>DateTime.)
        ////{
            
        ////}
    }
}

