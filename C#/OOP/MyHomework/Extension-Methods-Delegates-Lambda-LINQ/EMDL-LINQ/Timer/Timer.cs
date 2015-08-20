namespace EMDL_LINQ
{
    using System;
    using System.Timers;
    using System.Threading;

    public delegate void timerDelegate();

    public class Timer
    {
        private int repeatance;
        private int time;
        private timerDelegate tDelegate;

        public int Time
        {
            get
            {
                return this.time;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong time value(Timer)");
                }
                this.time = value;
            }
        }
        public timerDelegate TimerDelegate
        {
            get
            {
                return this.tDelegate;
            }
            private set
            {
                this.tDelegate = value;
            }
        }
        public int Ticks
        {
            get
            {
                return this.repeatance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Zero ficks given");
                }
                this.repeatance = value;
            }
        }

        public Timer(int milliSeconds,int repeatance, timerDelegate inputDelegate)
        {
            this.Time = milliSeconds;
            this.TimerDelegate = inputDelegate;
            this.Ticks = repeatance;
        }

        public void Run()
        {
            while (this.Ticks > 0)
            {
                Thread.Sleep(this.Time);
                this.Ticks--;
                this.TimerDelegate();
            }
        }
    }
}
