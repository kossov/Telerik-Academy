namespace RangeExceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRangeException(string message, T start, T end, Exception e)
            : base(string.Format("{0}\nThe Range must be [{1},{2}]", message, start, end), e)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null) { }

        public InvalidRangeException(T start, T end)
            : this("No message", start, end, null) { }

        public T Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.end = value;
            }
        }
        public T End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }
    }
}
