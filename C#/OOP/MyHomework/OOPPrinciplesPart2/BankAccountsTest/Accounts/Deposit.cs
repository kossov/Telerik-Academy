namespace BankAccounts.Accounts
{
    using System;
    using BankAccounts.Customers;

    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate) { }

        public void WithDrawMoney(decimal withDraw)
        {
            if ((this.Balance - withDraw) <= 0)
            {
                throw new ArgumentException("You cant WithDraw that much money because you dont have them!");
            }
            else
            {
                this.Balance -= withDraw;
            }
        }

        public override double InterestAmount(int monthPeriod)
        {
            if (this.Balance < 1000)
            {
                throw new ArgumentException("No interest amount!");
            }
            return this.InterestRate * monthPeriod;
        }
    }
}
