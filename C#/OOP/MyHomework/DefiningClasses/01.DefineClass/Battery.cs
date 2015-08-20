namespace PhoneDevices
{
    using System;

    public class Battery
    {
        private BatteryType batteryType;
        private double hoursTalk;
        private double hoursIdle;
        private bool isTalkAndIdleSet = false;

        public Battery(BatteryType batteryType)
        {
            this.BatteryType = batteryType;
        }
        public Battery(BatteryType batteryType, double talk, double idle)
            : this(batteryType)
        {
            this.isTalkAndIdleSet = true;
            this.TalkHours = talk;
            this.IdleHours = idle;
        }
        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }

        public double IdleHours
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw new NullReferenceException();
                }
                this.hoursIdle = value;
            }
        }
        public double TalkHours
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw new NullReferenceException();
                }
                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            if (this.isTalkAndIdleSet)
            {
                return string.Format("{0}Battery{1}\nType: {2}\nTalk Hours:{3} Idle Hours:{4}", new string('~', 3), new string('~', 3), this.batteryType, this.TalkHours, this.IdleHours);
            }
            return string.Format("{0}Battery{1}\nType: {2}", new string('~', 3),new string('~', 3), this.batteryType);
        }
    }
}
