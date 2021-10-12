using System.Collections.Generic;
using System.Linq;

namespace BankLogic
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CustomerID { get; } //Socialnumber


        private List<Account> CustomerAccounts { get; set; } = new List<Account>();

        
        public Customer(string firstname, string lastname, string customerid)
        {
            FirstName = firstname;
            LastName = lastname;
            CustomerID = customerid;
        }


        public string GetName()
        {
            return FirstName + " " + LastName;
        }


        public string GetCustomerID()
        {
            return CustomerID;
        }

        /// <summary>
        /// Returns Account if found else returns null
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public Account GetAccountByAccountNumber(long accountNumber) => CustomerAccounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber);


        public void RemoveAccount(long accountNumber)
        {
            var accountToDelete = GetAccountByAccountNumber(accountNumber);
            if (accountToDelete != null)
            {
                CustomerAccounts.Remove(accountToDelete);
            }
        }

        public List<Account> GetCustomerAccounts()
        {
            return CustomerAccounts;
        }


        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }


        public void AddAccount(AccountType accountType) // CHANGE WHEN ACCOUNT CTOR DONE
        {
            CustomerAccounts.Add(new Account(CustomerID, accountType));
        }
    }
}
