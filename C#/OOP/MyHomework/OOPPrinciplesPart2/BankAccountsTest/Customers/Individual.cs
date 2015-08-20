namespace BankAccounts.Customers
{
    using System;

    public class Individual : Customer
    {
        public Individual(string firstName, string lastName) : base(firstName, lastName) { }

        public override string ToString()
        {
            return string.Format("{0}-{1} {2}",this.GetType().Name,this.FirstName,this.LastName);
        }
    }
}
