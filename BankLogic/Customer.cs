using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BankLogic
{
    public class Customer
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string CustomerID { get; }
        private List<Account> CustomerAccounts { get; set; } = new List<Account>();




        //Creates a new customer
        public Customer(string firstname, string lastname, string customerid)
        {
            FirstName = firstname;
            LastName = lastname;
            CustomerID = customerid;
        }




        //Gets the fullname and returns it
        public string GetName() => FirstName + " " + LastName;

        //Gets the firstname and returns it
        public string GetFirstName() => FirstName;

        //Gets the lastname and returns it
        public string GetLastName() => LastName;

        //Gets the CustomerID and returns it
        public string GetCustomerID() => CustomerID;

        //Gets the CustomerAccounts and returns it
        public List<Account> GetCustomerAccounts() => CustomerAccounts;

        //Gets a specific account with inputed accountNumber and returns it
        public Account GetAccountByAccountNumber(long accountNumber) => CustomerAccounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber);




        //Adds a new account to CustomerAccounts
        public void AddAccount(AccountType accountType) => CustomerAccounts.Add(new Account(CustomerID, accountType));

        //Removes an account from CustomerAccounts
        public void RemoveAccount(long accountNumber)
        {
            var accountToDelete = GetAccountByAccountNumber(accountNumber);
            if (accountToDelete != null)
            {
                CustomerAccounts.Remove(accountToDelete);
            }
        }

        //Changes the customers name
        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        //Overrided ToString()
        public override string ToString() => $"[{CustomerID}] {GetName()}";




        //Constructor used to add already existing account to CustomerAccounts
        public void AddAccount(Account account) => CustomerAccounts.Add(account);

        /// <summary>
        /// Reads from customer textfile and returns a list of Customer
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all customers and saves them to customer textfile
        /// </summary>
        public static void SaveCustomersToFile()
        {
            var customersToSave = new string[Bank.GetCustomers().Count];
            int i = 0;
            if (customersToSave.Length > 0)
            {
                foreach (var customer in Bank.GetCustomers())
                {
                    customersToSave[i] = $"{customer.GetFirstName()},{customer.GetLastName()},{customer.GetCustomerID()}";
                    i++;
                }
                File.WriteAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\Customer.csv", customersToSave);
            }
        }
    }
}
