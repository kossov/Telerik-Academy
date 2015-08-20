namespace BankAccounts.Customers
{
    using System;

    public class Company : Customer
    {
        public Company(string companyName) : base(companyName) { }

        public override string ToString()
        {
            return this.GetType().Name+"-"+this.CompanyName;
        }
    }
}
