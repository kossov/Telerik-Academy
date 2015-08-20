namespace PhoneDevices
{
    using System;

    public class Call
    {
        private DateTime dateAndTime;
        private string dialedNumber;
        private int duration;

        public Call(DateTime dateAndTime, string dialedNum, int duration)
        {
            this.dateAndTime = dateAndTime;
            this.DialedNumber = dialedNum;
            this.CallDuration = duration;
        }

        public DateTime DateTime
        {
            get
            {
                if (this.dateAndTime == null)
                {
                    throw new ArgumentNullException("DateTime is not entered");
                }
                return this.dateAndTime;
            }
            set
            {
                this.dateAndTime = value;
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Number dialed is too short");
                }
                this.dialedNumber = value;
            }
        }

        public int CallDuration
        {
            get
            {
                if (duration <= 0)
                {
                    throw new ArgumentException("wrong duration");
                }
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}, Duration:{2}sec",this.DialedNumber,this.DateTime.ToString("dd/MM H:mm"),this.CallDuration);
        }
    }
}
