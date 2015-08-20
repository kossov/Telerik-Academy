using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] nAndMAsString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        ulong n = ulong.Parse(nAndMAsString[0]);
        ulong m = ulong.Parse(nAndMAsString[1]);
        BigInteger[,] matrix = new BigInteger[n, m];
        matrix[0, 0] = 1;
        string[] fxAndFyAsString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        BigInteger fx = BigInteger.Parse(fxAndFyAsString[0]);
        BigInteger fy = BigInteger.Parse(fxAndFyAsString[1]);
        int dogeEnemiesK = int.Parse(Console.ReadLine());
        BigInteger[] dogeEnemiesX = new BigInteger[dogeEnemiesK];
        BigInteger[] dogeEnemiesY = new BigInteger[dogeEnemiesK];
        for (int i = 0; i < dogeEnemiesK; i++)
        {
            string[] dogeEnemiesXY = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            dogeEnemiesX[i] = BigInteger.Parse(dogeEnemiesXY[0]);
            dogeEnemiesY[i] = BigInteger.Parse(dogeEnemiesXY[1]);
            matrix[(int)dogeEnemiesX[i], (int)dogeEnemiesY[i]] = -1;
        }
        FillingXAndYWithOnes(matrix);
        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == -1)
                {
                    matrix[row, col] = 0;
                    continue;
                }
                matrix[row, col] = matrix[row - 1, col] + matrix[row, col - 1];
            }
        }
        if (fx == 0 && fy == 0)
        {
            Console.WriteLine("0");
        }
        else
            Console.WriteLine(matrix[(int)fx, (int)fy]);
    }
    static void FillingXAndYWithOnes(BigInteger[,] matrix)
    {
        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            matrix[row, 0] = matrix[row - 1, 0];
        }
        for (int col = 1; col < matrix.GetLength(1); col++)
        {
            matrix[0, col] = matrix[0, col - 1];
        }
    }

}