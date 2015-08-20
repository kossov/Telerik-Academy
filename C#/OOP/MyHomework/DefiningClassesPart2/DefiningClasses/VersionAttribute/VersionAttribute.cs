namespace DefiningClasses
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Enum)]

    class VersionAttribute : Attribute
    {
        private int major;
        private int minor;

        public AttributeType myType { get; set; }
        public int Major
        {
            get
            {
                return this.major;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong Version value(major)!");
                }
            }
        }
        public int Minor
        {
            get
            {
                return this.minor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong Version value(minor)!");
                }
            }
        }

        public VersionAttribute(AttributeType type, int major, int minor)
        {
            this.myType = type;
            this.Major = major;
            this.Minor = minor;
        }


    }
}
