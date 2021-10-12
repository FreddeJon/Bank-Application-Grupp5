using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace BankLogic
{
    public class Customer
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string CustomerID { get; } //Socialnumber
        private List<Account> CustomerAccounts { get; set; } = new List<Account>();


        public Customer(string firstname, string lastname, string customerid)
        {
            FirstName = firstname;
            LastName = lastname;
            CustomerID = customerid;
        }


        public string GetName() => FirstName + " " + LastName;
        public string GetFirstName() => FirstName;
        public string GetLastName() => LastName;
        public string GetCustomerID() => CustomerID;
        public List<Account> GetCustomerAccounts() => CustomerAccounts;


        /// <summary>
        /// Returns Account if found else returns null
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public Account GetAccountByAccountNumber(long accountNumber) => CustomerAccounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber);

        public void AddAccount(AccountType accountType) => CustomerAccounts.Add(new Account(CustomerID, accountType));

        public void RemoveAccount(long accountNumber)
        {
            var accountToDelete = GetAccountByAccountNumber(accountNumber);
            if (accountToDelete != null)
            {
                CustomerAccounts.Remove(accountToDelete);
            }
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }


        public override string ToString() => $"{GetName()} {CustomerID}";

        public static List<Customer> ReadFromCustomerFile()
        {
            var read = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\Customer.csv");
            List<Customer> loadedCustomers = new();
            foreach (var line in read)
            {
                var stringList = line.Split(",");
                loadedCustomers.Add(new Customer(stringList[0], stringList[1], stringList[2]));
            }
            return loadedCustomers;
        }

    }
}
