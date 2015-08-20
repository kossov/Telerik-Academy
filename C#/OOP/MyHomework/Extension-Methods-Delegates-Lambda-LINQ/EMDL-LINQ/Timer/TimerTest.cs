namespace EMDL_LINQ
{
    using System;

    public class TimerTest
    {
        static void MainS(string[] args)
        {
            Timer timer = new Timer(200, 10, delegate() { Console.WriteLine("mbay"); });
            timer.Run();
        }
    }
}
