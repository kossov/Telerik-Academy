namespace BankAccounts
{
    using System;
    using BankAccounts.Accounts;
    using BankAccounts.Customers;

    public class BankAccountsTest
    {
        public static void Main(string[] args)
        {
            Account goshoAccount = new Deposit(new Individual("Gosho", "Goshev"), 2000, 15);
            Bank pireus = new Bank(goshoAccount);
            goshoAccount.DepositMoney(500);

            Account[] manyAccounts = new Account[]
            {
                new Deposit(new Company("Telerik"),5000,500),
                new Loan(new Individual("Ivan","Ivanov"),1001,1002)
            };
            pireus.AddAccounts(manyAccounts);

            foreach (Account item in pireus.BankAccounts)
            {
                Console.WriteLine(item+" Interest Amount: "+item.InterestAmount(1));
                // throws exception because for Loan there is not interest ammount for the first 2-3months
            }
        }
    }
}
