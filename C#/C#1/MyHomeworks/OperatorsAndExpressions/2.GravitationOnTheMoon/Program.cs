/* The gravitational field of the Moon is approximately 17% of that on the Earth.
Write a program that calculates the weight of a man on the moon by a given weight on the Earth. */

using System;

class Program
{
    static void Main(string[] args)
    {
        float moonGravity = 17/100f;
        float mansWeight;
        float weightOnMoon;
        Console.Write("Enter a man's weight[kg]: ");
        mansWeight = float.Parse(Console.ReadLine());
        weightOnMoon = mansWeight * moonGravity;
        Console.WriteLine("Your Weight on Moon is: {0} kg",weightOnMoon);
    }
}

