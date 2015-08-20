namespace Task2
{
    using System;

    public class Statistics
    {
        public void PrintStatistics(double[] statistics, int count)
        {
            double maxStatistic = double.MinValue;
            double minStatistic = double.MaxValue;
            double sumOfStatistics = 0;

            for (int i = 0; i < count; i++)
            {
                if (statistics[i] > maxStatistic)
                {
                    maxStatistic = statistics[i];
                }
                if (statistics[i] < minStatistic)
                {
                    minStatistic = statistics[i];
                }
                sumOfStatistics += statistics[i];
            }

            PrintMax(maxStatistic);
            PrintMin(minStatistic);
            PrintAvg(sumOfStatistics / count);
        }
    }
}