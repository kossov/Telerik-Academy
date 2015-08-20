// Write an expression that calculates rectangle’s perimeter and area by given width and height.

using System;

class Program
{
    static void Main(string[] args)
    {
        double width, height;
        double perimeter, area;

        Console.WriteLine("Enter the dimensions for the rectangle's perimeter!");
        Console.Write("Enter Width: ");
        width = double.Parse(Console.ReadLine());
        Console.Write("Enter Height: ");
        height = double.Parse(Console.ReadLine());
        perimeter = 2 * (height + width);
        area = width * height;
        Console.WriteLine("The Perimeter of the rectangle is: {0}",perimeter);
        Console.WriteLine("The Area of the rectangle is: {0}",area);
    }
}

