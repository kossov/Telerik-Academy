namespace BankAccounts.Accounts
{
    using System;
    using BankAccounts.Customers;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate) { }

        public override double InterestAmount(int monthPeriod)
        {
            if (this.Customer is Individual) // individual or not ??????
            {
                if (monthPeriod <= 3)
                {
                    throw new ArgumentException("No interest amount!");
                }
                return this.InterestRate * (monthPeriod - 3);
            }
            else
            {
                if (monthPeriod <= 2)
                {
                    throw new ArgumentException("No interest amount!");
                }
                return this.InterestRate * (monthPeriod - 2);
            }
        }
    }
}
