namespace Schools
{
    using System;
    using System.Collections.Generic;

    public class Student : People
    {
        private string name;
        private int classNumber;

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Too short Student name");
                }
                this.name = value;
            }
        }
        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong student class number");
                }
                this.classNumber = value;
            }
        }

        public Student(string name, int classNumber)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
        }

        public override string ToString()
        {
            return this.ClassNumber + " " + this.Name;
        }
    }
}
