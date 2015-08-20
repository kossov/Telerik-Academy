namespace Person
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Too short name!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong age value!");
                }
                this.age = value;
            }
        }

        public Person(string name)
        {
            this.Name = name;
        }
        public Person(string name, int age) : this(name)
        {
            this.Age = age;
        }

        public override string ToString()
        {
            if (this.Age == 0)
            {
                return this.Name + ", No Age info";
            }
            return this.Name + ", " + this.Age;
        }
    }
}
