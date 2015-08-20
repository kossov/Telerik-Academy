// Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).

using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter X: ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("Enter Y: ");
            float y = float.Parse(Console.ReadLine());

            // circle points
            int circleX = 0;
            int circleY = 0;
            int radius = 2;

            bool result=false;

            if ((Math.Pow((x - circleX), 2) + Math.Pow((y - circleY), 2) <= Math.Pow(radius,2))) // inside the circle
            {
                result = true;
                Console.WriteLine("The entered point [{0},{1}] is IN the circle -> {2}",x,y,result);
            }
            else
            {
                Console.WriteLine("The entered point [{0},{1}] is NOT IN the circle -> {2}",x,y,result);
            }

        }
    }

