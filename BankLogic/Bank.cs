using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace BankLogic
{
    public static class Bank
    {
        // List of all customers
        private static List<Customer> CustomerList { get; set; } = new List<Customer>();




        //Gets CustomerList and returns it
        public static List<Customer> GetCustomers() => CustomerList;

        //Gets a specific Customer by CustomerID and returns it
        public static Customer GetCustomerByCustomerID(string id) => CustomerList.FirstOrDefault(x => x.GetCustomerID() == id);

        //Creates a customer and adds it to customerList if customer not already existing
        public static bool AddCustomer(string fname, string lname, string id)
        {
            bool validated = false;
            if (!id.CustomerExists())
            {
                CustomerList.Add(new Customer(fname, lname, id));
                validated = true;
            }
            return validated;
        }

        //Removes a customer by CustomerID
        public static void RemoveCustomer(string id) => CustomerList.Remove(GetCustomerByCustomerID(id));




        // Gets an unique AccountNumber from textfile ands saves the next account number to use
        public static long GetUniqueAccountNumber()
        {
            string read = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\currentAccount.csv");

            _ = long.TryParse(read, out long currentAccount);

            if (currentAccount >= 1002)
            {
                File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\currentAccount.csv", (currentAccount + 1).ToString());
                return currentAccount;
            }
            else
            {
                File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\currentAccount.csv", "1002".ToString());
                return 1001;
            }
        }




        //Load both customer and accounts
        public static void LoadFromTextFile()
        {
            try
            {
                CustomerList = Customer.ReadFromCustomerFile();
                List<Account> accountList = Account.ReadFromAccountFile();

                // Går igenom varje customer
                foreach (var customer in CustomerList)
                {
                    //Hämtar alla konton där AccountID == CustomerID och lägger det i en lista
                    var matchingAccounts = accountList.Where(x => x.GetAccountId() == customer.GetCustomerID()).ToList();

                    //Går igenom listan och lägger till det i CustomerAccounts
                    foreach (var account in matchingAccounts)
                    {
                        customer.AddAccount(account);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error in Bank.LoadFromTextFile");
                Console.WriteLine(e);            
                Console.ReadLine();
            }

        }

        //Save both customer and accounts
        public static void SaveToTextFile()
        {
            try
            {
                Customer.SaveCustomersToFile();
                Account.SaveAccountsToFile();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Bank.SaveToTextFile");
                Console.WriteLine(e);
            }

        }
    }
}
