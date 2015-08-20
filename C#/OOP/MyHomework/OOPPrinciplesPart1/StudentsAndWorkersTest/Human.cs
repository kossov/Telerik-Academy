namespace StudentsAndWorkers
{
    using System;

    public abstract class Human
    {
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return "I AM HUMAN";
        }
    }
}
