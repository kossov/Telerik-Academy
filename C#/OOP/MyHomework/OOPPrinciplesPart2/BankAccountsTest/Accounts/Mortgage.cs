namespace BankAccounts.Accounts
{
    using System;
    using BankAccounts.Customers;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate) { }

        public override double InterestAmount(int monthPeriod)
        {
            if (this.Customer is Individual)
            {
                if (monthPeriod <= 6)
                {
                    throw new ArgumentException("No interest rate!");
                }
                return this.InterestRate * (monthPeriod-6);
            }
            else
            {
                if (monthPeriod <= 12)
                {
                    return (this.InterestRate * monthPeriod) / 2;
                }
                return this.InterestRate * monthPeriod;
            }
        }
    }
}
