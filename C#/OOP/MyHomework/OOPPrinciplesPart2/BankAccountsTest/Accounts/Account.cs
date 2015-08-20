namespace BankAccounts
{
    using System;
    using BankAccounts.Customers;
    using System.Collections;

    public abstract class Account
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }

        public Account(Customer customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public abstract double InterestAmount(int monthPeriod);
        public virtual void DepositMoney(decimal deposit)
        {
            this.Balance += deposit;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Holder: {1}, Balance: {2}",this.GetType().Name,this.Customer,this.Balance);
        }
    }
}
