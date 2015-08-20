using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.BishopPath
{
    class Program // the filling of the chessboard is copied from my homework
    {
        static void Main(string[] args)
        {
            // if slow refactor rAndC
            int[] rAndC = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            ulong[,] matrix = new ulong[rAndC[0], rAndC[1]];
            BigInteger bishop = new BigInteger();
            FillInTheMatrix(matrix);
            int numberOfDirections = int.Parse(Console.ReadLine());
            int lastRow = matrix.GetLength(0) - 1, lastCol = 0;
            for (int i = 0; i < numberOfDirections; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                if (line[0] == "RU" || line[0] == "UR")
                {
                    int count = 0;
                    while (lastRow >= 0 && lastCol < matrix.GetLength(1) && lastCol >= 0 && count < int.Parse(line[1]) && lastRow < matrix.GetLength(0))
                    {
                        bishop += matrix[lastRow, lastCol];
                        matrix[lastRow, lastCol] = 0;
                        lastRow--;
                        lastCol++;
                        count++;
                    }
                    lastCol--;
                    lastRow++;
                }
                if (line[0] == "LU" || line[0] == "UL")
                {
                    int count = 0;
                    while (lastRow >= 0 && lastCol < matrix.GetLength(1) && lastCol >= 0 && count < int.Parse(line[1]) && lastRow < matrix.GetLength(0))
                    {
                        bishop += matrix[lastRow, lastCol];
                        matrix[lastRow, lastCol] = 0;
                        lastRow--;
                        lastCol--;
                        count++;
                    }
                    lastCol++;
                    lastRow++;
                }
                if (line[0] == "DL" || line[0] == "LD")
                {
                    int count = 0;
                    while (lastRow >= 0 && lastCol < matrix.GetLength(1) && lastCol >= 0 && count < int.Parse(line[1]) && lastRow < matrix.GetLength(0))
                    {
                        bishop += matrix[lastRow, lastCol];
                        matrix[lastRow, lastCol] = 0;
                        lastRow++;
                        lastCol--;
                        count++;
                    }
                    lastCol++;
                    lastRow--;
                }
                if (line[0] == "DR" || line[0] == "RD")
                {
                    int count = 0;
                    while (lastRow >= 0 && lastCol < matrix.GetLength(1) && lastCol >= 0 && count < int.Parse(line[1]) && lastRow < matrix.GetLength(0))
                    {
                        bishop += matrix[lastRow, lastCol];
                        matrix[lastRow, lastCol] = 0;
                        lastRow++;
                        lastCol++;
                        count++;
                    }
                    lastCol--;
                    lastRow--;
                }
            }
            Console.WriteLine(bishop);
        }

        private static void FillInTheMatrix(ulong[,] matrix)
        {
            int counter = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                int j = counter;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (ulong)j;
                    j += 3;
                }
                counter += 3;
            }
        }
    }
}
