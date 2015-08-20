namespace StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private string firstName;
        private string lastName;
        private double weekSalary;
        private double workHoursPerDay;

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
        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong week salary!");
                }
                this.weekSalary = value;
            }
        }
        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong work hours per day!");
                }
                this.workHoursPerDay = value;
            }
        }

        public Worker(string firstName, string lastName) : base(firstName, lastName) { }
        public Worker(string firstName, string lastName, double salary,double workHoursPD) : base(firstName, lastName)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHoursPD;
        }

        public double MoneyPerHour()
        {
            return this.WeekSalary / (5 * this.WorkHoursPerDay);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} WeekSalary: {2} | WorkHoursPerDay: {3}",this.FirstName,this.LastName,this.WeekSalary,this.WorkHoursPerDay);
        }
    }
}
