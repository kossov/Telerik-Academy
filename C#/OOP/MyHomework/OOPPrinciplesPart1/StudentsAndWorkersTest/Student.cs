namespace StudentsAndWorkers
{
    using System;
    using System.Linq;

    public class Student : Human
    {
        private string firstName;
        private string lastName;
        private Grade grade;

        public override string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Too short name");
                };
                this.firstName = value;
            }
        }
        public override string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Too short name");
                };
                this.lastName = value;
            }
        }
        public Grade Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if ((int)value < 2 || (int)value > 6)
                {
                    throw new ArgumentException("Wrong grade!");
                }
                this.grade = value;
            }
        }

        public Student(string firstName, string lastName) 
            : base(firstName, lastName) { }
        public Student(string firstName, string lastName, int grade) 
            : this(firstName,lastName)
        {
            this.Grade = (Grade)grade;
        }
        public Student(string firstName, string lastName, Grade grade)
            : this(firstName, lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} Grade: {2}", this.FirstName, this.LastName,this.Grade);
        }
    }
}
