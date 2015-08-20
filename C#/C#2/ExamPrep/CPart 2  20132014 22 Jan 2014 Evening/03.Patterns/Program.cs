using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static bool[,] pattern = new bool[,] {
            {true,true,true,false,false},
            {false,false,true,false,false},
            {false,false,true,true,true}
        };


    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = EnteringMatrix(n);
        int sum = 0, tempSum = 0, diagonal = FindingDiagonal(matrix);
        List<int> gotPatternNumbers = new List<int>();
        bool patternExists = true, finalPatternExists = false;
        for (int row = 0; row < n; row++)
        {
            if (row + pattern.GetLength(0) > matrix.GetLength(0))
                break;
            for (int col = 0; col < n; col++)
            {
                if (col + pattern.GetLength(1) > matrix.GetLength(1))
                    break;
                for (int patternRow = 0; patternRow < pattern.GetLength(0); patternRow++)
                {
                    for (int patternCol = 0; patternCol < pattern.GetLength(1); patternCol++)
                    {
                        if (pattern[patternRow, patternCol] == false)
                            continue;
                        else
                        {
                            gotPatternNumbers.Add(matrix[row + patternRow, col + patternCol]);
                        }
                    }
                }
                for (int k = 1; k < gotPatternNumbers.Count; k++)
                {
                    if (gotPatternNumbers[k] - 1 != gotPatternNumbers[k - 1])
                    {
                        patternExists = false;
                        tempSum = 0;
                        gotPatternNumbers.Clear();
                        break;
                    }
                    patternExists = true;
                    tempSum += gotPatternNumbers[k];
                }
                if (patternExists == true)
                {
                    finalPatternExists = true;
                    tempSum += gotPatternNumbers[0];
                }
                if (tempSum > sum)
                {
                    sum = tempSum;
                }
                tempSum = 0;
            }
        }
        if (finalPatternExists == true)
        {
            Console.WriteLine("YES " + sum);
        }
        else
        {
            Console.WriteLine("NO " + diagonal);
        }
    }
    static int FindingDiagonal(int[,] matrix)
    {
        int diagonal = 0;
        for (int index = 0; index < matrix.GetLength(0); index++)
            diagonal += matrix[index, index];
        return diagonal;
    }
    static int[,] EnteringMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        for (int row = 0; row < n; row++)
        {
            string line = Console.ReadLine();
            string[] lineAsArray = line.Split(' ');
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = int.Parse(lineAsArray[col]);
            }
        }
        return matrix;
    }
}