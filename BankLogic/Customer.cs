using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public long CustomerID { get; } //Socialnumber
        private List<Account> CustomerAccounts { get; set; } = new List<Account>();
        

        public Customer(string firstname, string lastname, long customerid)
        {
            FirstName = firstname;
            LastName = lastname;
            CustomerID = customerid;
        }


        public string GetName()
        {
            return FirstName + " " + LastName;
        }


        public long GetCustomerID()
        {
            return CustomerID;
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


        public void AddAccount() // CHANGE WHEN ACCOUNT CTOR DONE
        {
            CustomerAccounts.Add(new Account());
        }
    }
}
