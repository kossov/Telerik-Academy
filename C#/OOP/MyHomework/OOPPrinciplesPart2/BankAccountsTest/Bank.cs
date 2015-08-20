namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    public class Bank
    {
        private List<Account> bankAccounts;

        public List<Account> BankAccounts
        {
            get
            {
                return this.bankAccounts;
            }
        }

        public Bank()
        {
            this.bankAccounts = new List<Account>();
        }
        public Bank(Account account)
            : this()
        {
            this.bankAccounts.Add(account);

        }
        public Bank(IEnumerable<Account> accounts)
            : this()
        {
            this.bankAccounts.AddRange(accounts);
        }
        // malko si igrah as
        public void AddAccount(Account acc)
        {
            this.bankAccounts.Add(acc);
        }
        public void AddAccounts(IEnumerable<Account> accs)
        {
            this.bankAccounts.AddRange(accs);
        }
    }
}
