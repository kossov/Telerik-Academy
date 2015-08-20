/* A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
Write a program that reads the information about a company and its manager and prints it back on the console. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAdress = Console.ReadLine();
        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Fax number: ");
        ushort faxNumber = ushort.Parse(Console.ReadLine());
        Console.Write("Web site: ");
        string webSite = Console.ReadLine();
        Console.Write("Manager first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Manager age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("Manager phone: ");
        string phone = Console.ReadLine();
        Console.WriteLine(new string('-',30));
        Console.WriteLine("{0}\n\rAdress: {1}\n\rTel. {2}\n\rFax: {3}\n\rWeb site: {4}\n\rManager: {5} {6} (age: {7}, tel. {8})",companyName,companyAdress,phoneNumber,faxNumber,webSite,firstName,lastName,age,phone);
    }
}
