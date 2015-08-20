
namespace PhoneDevices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GSM
    {
        public static readonly GSM iPhone4S = new GSM("Apple", "iPhone 4S", new Display(DisplayType.OLED, "3,5", "16M"), new Battery(BatteryType.LiIon, 14.0, 200.0));

        private Display displ;
        private Battery batt;
        private string manufacturer = null;
        private string model = null;
        private List<Call> history = new List<Call>();

        public GSM(string manufacturer, string model)
        {
            this.Manifacturer = manufacturer;
            this.Model = model;
        }
        public GSM(string manu, string mod, Display display, Battery battery)
            : this(manu, mod)
        {
            this.displ = display;
            this.batt = battery;
        }

        public string Manifacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (this.manufacturer == null)
                {
                    if (value.Length < 3)
                    {
                        throw new ArgumentException("Too short Manufacturer name!");
                    }
                    this.manufacturer = value;
                }
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (this.model == null)
                {
                    if (value.Length < 3)
                    {
                        throw new ArgumentException("Too short Model name!");
                    }
                    this.model = value;
                }
            }
        }

        public Display Display
        {
            get
            {
                //if (this.displ == null) removed this just so the program runs, not trowing exception
                //{
                //    throw new ArgumentNullException("no display info");
                //}
                return this.displ;
            }
            set
            {
                this.displ = value;
            }
        }

        public Battery Battery
        {
            get
            {
                //if (this.batt == null) removed this just so the program runs, not trowing exception
                //{
                //    throw new ArgumentNullException("no battery info");
                //}
                return this.batt;
            }
            set
            {
                this.batt = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return new List<Call>(this.history);
            }
        }

        public void AddCall(Call call)
        {
            this.history.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.history.Remove(call);
        }

        public void ClearHistory()
        {
            this.history.Clear();
        }

        public double HistoryPrice(double pricePerMin)
        {
            double sumAll = this.history.Select(x => x.CallDuration).Sum();
            return pricePerMin * (sumAll / 60);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\n{2}\n{3}", this.Manifacturer, this.Model, this.Battery == null ? "No battery info" : this.Battery.ToString(), this.Display == null ? "No display info" : this.Display.ToString());
        }
    }
}
