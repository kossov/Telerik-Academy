using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Program // not working :(
{
    static void Main(string[] args)
    {
        string[] numbersInCells = Console.ReadLine().Split(' ');
        long[] path = new long[numbersInCells.Length];
        for (int i = 0; i < numbersInCells.Length; i++)
        {
            path[i] = long.Parse(numbersInCells[i]);
        }
        BigInteger molly = new BigInteger();
        BigInteger dolly = new BigInteger();
        bool mollyWins = true;
        bool dollyWins = true;
        bool isDraw = false;
        int mollySteps = 0;
        for (int i = 0, dollySteps = path.Length-1; ;)
        {
            molly += path[mollySteps];
            i += (int)(path[mollySteps]);
            path[mollySteps] = 0;
            mollySteps = i % path.Length;

            dolly += path[dollySteps];
            int tempDollySteps = dollySteps;
           // dollySteps = path.Length-(int)(path[dollySteps]%path.Length);



            if (path[mollySteps] == 0 && path[dollySteps] != 0)
            {
                mollyWins = false;
                dolly += path[dollySteps];
                break;
            }
            if (path[dollySteps] == 0 && path[mollySteps] != 0)
            {
                molly = path[mollySteps];
                dollyWins = false;
                break;
            }
            if (path[dollySteps] == 0 && path[mollySteps] == 0)
            {
                isDraw = true;
                mollyWins = false;
                dollyWins = false;
                break;
            }
        }
        if (mollyWins == true)
        {

            Console.WriteLine("Molly");
            Console.WriteLine(molly.ToString() + ' ' + dolly.ToString());
        }
        if (dollyWins == true)
        {

            Console.WriteLine("Dolly");
            Console.WriteLine(molly.ToString() + ' ' + dolly.ToString());
        }
        if (isDraw==true)
        {
            Console.WriteLine("Draw");
            Console.WriteLine(molly.ToString() + ' ' + dolly.ToString());
        }
    }
}
