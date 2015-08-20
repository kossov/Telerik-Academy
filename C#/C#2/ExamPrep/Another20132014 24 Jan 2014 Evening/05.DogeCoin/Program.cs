using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _05.DogeCoin // 100/100
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nAndM = Console.ReadLine().Split(' ');
            int n = int.Parse(nAndM[0]);
            int m = int.Parse(nAndM[1]);
            int k = int.Parse(Console.ReadLine());
            int[,] coins = new int[n, m];
            for (int i = 0; i < k; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                coins[int.Parse(line[0]), int.Parse(line[1])]++;
            }
            int[,] matrix = new int[n, m];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == 0)
                    {
                        if (row == 0 && col == 0)
                        {
                            matrix[row, col] = coins[row, col];
                        }
                        else
                        {
                            matrix[row, col] = matrix[row, col - 1] + coins[row, col];
                        }
                    }
                    else if (col == 0)
                    {
                        if (row == 0 && col == 0)
                        {
                            matrix[row, col] = coins[row, col];
                        }
                        else
                        {
                            matrix[row, col] = matrix[row - 1, col] + coins[row, col];
                        }
                    }
                    else
                        if (matrix[row, col - 1] >= matrix[row - 1, col])
                        {
                            matrix[row, col] = matrix[row, col - 1] + coins[row, col];
                        }
                        else
                            matrix[row, col] = matrix[row - 1, col] + coins[row, col];
                    
                }
            }
            Console.WriteLine(matrix[n - 1, m - 1]);
        }
    }
}
