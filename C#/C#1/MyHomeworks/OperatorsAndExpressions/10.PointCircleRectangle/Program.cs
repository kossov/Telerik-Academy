// Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter X: ");
            float pointX = float.Parse(Console.ReadLine());
            Console.Write("Enter Y: ");
            float pointY = float.Parse(Console.ReadLine());
            // circle points
            int circleX = 1;
            int circleY = 1;
            float radius = 1.5f;

            bool resultCircle = false;

            if ((Math.Pow((pointX - circleX), 2) + Math.Pow((pointY - circleY), 2) <= Math.Pow(radius, 2))) // inside or on the circle
            {
                resultCircle = true;
                Console.WriteLine("The entered point [{0},{1}] is IN the circle.", pointX, pointY);
            }
            else
            {
                Console.WriteLine("The entered point [{0},{1}] is NOT IN the circle.", pointX, pointY);
            }
            // rectangle
            bool resultRectangle = true;
            if (((pointX >= -1) && (pointX <= 5)) && ((pointY <= 1) && (pointY >= -1)))
            {
                resultRectangle = false;
                Console.WriteLine("The entered point [{0},{1}] is IN the rectangle.", pointX, pointY);
            }
            else
            {
                Console.WriteLine("The entered point [{0},{1}] is NOT IN the rectangle.", pointX, pointY);
            }
            bool finalResult = resultRectangle & resultCircle;
            Console.WriteLine("inside K & outside of R -> {0}",finalResult);
        }
    }

