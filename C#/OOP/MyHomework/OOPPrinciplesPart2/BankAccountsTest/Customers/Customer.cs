namespace BankAccounts.Customers
{
    using System;

    public abstract class Customer
    {
        private string firstName;
        private string lastName;
        private string companyName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Too short customer name!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Too short customer name!");
                }
                this.lastName = value;
            }
        }
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Too short company name!");
                }
                this.companyName = value;
            }
        }

        public Customer(string companyName)
        {
            this.CompanyName = companyName;
        }
        public Customer(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
