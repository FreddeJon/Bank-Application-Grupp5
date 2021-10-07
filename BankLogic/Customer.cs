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
        private List<Account> CustomerAccounts { get; set; }

         
        /*
         * CTOR 
         * 
         * GetName()
         * GetCustomerID()
         * GetCustomerAccounts()       
         * 
         * 
         * 
         * 
         * ChangeName();
         * 
         * AddAccount() // To CustomerAccounts link to account ctor
         * 
         * 
         */









    }
}
