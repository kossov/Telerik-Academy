namespace PhoneDevices
{
    using System;

    public class Display
    {
        private DisplayType displayType;
        private string inches;
        private string numberOfColors;
        private bool isInchesAndColorsSet = false;

        public Display(DisplayType displayType)
        {
            this.displayType = displayType;
        }
        public Display(DisplayType displayType, string size, string numberOfColors)
            : this(displayType)
        {
            this.isInchesAndColorsSet = true;
            this.DisplaySize = size;
            this.NumberOfColors = numberOfColors;
        }

        public string DisplaySize
        {
            get
            {
                if (this.inches == string.Empty)
                {
                    throw new ArgumentNullException();
                }
                return this.inches;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException();
                }
                this.inches = value;
            }
        }
        public string NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            if (this.isInchesAndColorsSet)
            {
                return string.Format("{0}Display{1}\nType:{2}\nSize:{3} Number Of Colors:{4}", new string('~', 3), new string('~', 3), this.displayType, this.DisplaySize, this.NumberOfColors);
            }
            return string.Format("{0}Display{1}\nType:{2}", new string('~', 3), new string('~', 3), this.displayType);
        }

    }
}
