/* A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names. */

using System;

class Program
{
    static void Main(string[] args)
    {
        string newLine = Environment.NewLine;
        string firstName = "Goshe";
        string middleName = "To";
        string lastName = "Uee";
        short onMoney = 25;
        long aiBan = 213231132131313;
        short e = 1337;
        Console.WriteLine(firstName + middleName + lastName + newLine + onMoney + newLine + aiBan + newLine + e);
    }
}

