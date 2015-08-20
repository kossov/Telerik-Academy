namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        public ulong Value { get; set; }

        public BitArray64(ulong value)
        {
            this.Value = value;
        }

        public int this[int position]
        {
            get
            {
                if (position < 0 || position > 63)
                {
                    throw new ArgumentException("Wrong position! [0,63]");
                }
                return (int)((this.Value >> position) & 1);
            }
            set
            {
                if (position < 0 || position > 63)
                {
                    throw new ArgumentException("Wrong position! [0,63]");
                }
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Wrong Bit Value!");
                }
                if (((int)(this.Value >> position) & 1) != value)
                {
                    this.Value ^= (ulong)(1 << position);
                }
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            BitArray64 newBitArray = obj as BitArray64;
            if (newBitArray == null)
            {
                return false;
            }
            if (this.Value != newBitArray.Value)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 64; i++)
            {
                result.Insert(0,(int)((this.Value >> i) & 1));
            }
            return result.ToString();
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
