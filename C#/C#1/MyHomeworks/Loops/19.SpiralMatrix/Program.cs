/* Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below. */
using System;

class Program
{
    static void Main(string[] args)
    {
        int n;
        string direction = "right";
        int row = 0, col = 0;
        do
        {
            Console.Write("Enter N[1;20]: ");
            n = int.Parse(Console.ReadLine());
        } while (n < 0 || n > 20);
        int maxMatrix = n * n;
        int[,] myMatrix = new int[n, n];
        for (int i = 1; i <= maxMatrix; i++)
        {
            if (direction == "right" && (col > (n - 1) || myMatrix[row, col] != 0))
            {
                direction = "down";
                row++;
                col--;
            }
            if (direction == "down" && (row > (n - 1) || myMatrix[row, col] != 0))
            {
                direction = "left";
                col--;
                row--;
            }
            if (direction == "left" && (col < 0 || myMatrix[row, col] != 0))
            {
                direction = "up";
                row--;
                col++;
            }
            if (direction == "up" && row < 0 || myMatrix[row, col] != 0)
            {
                direction = "right";
                col++;
                row++;
            }
            myMatrix[row, col] = i;
            if (direction=="right")
            {
                col++;
            }
            if (direction=="down")
            {
                row++;
            }
            if (direction=="left")
            {
                col--;
            }
            if (direction=="up")
            {
                row--;
            }
        }
        for (int rows = 0; rows < n; rows++)
        {
            for (int columns = 0; columns < n; columns++)
            {
                Console.Write("{0,3}",myMatrix[rows,columns]);
            }
            Console.WriteLine();
        }
    }
}
