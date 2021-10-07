using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{

    enum AccountType
    {
        SavingsAccount,
        SpendingAccount,
        //CreditAccount?
    }
    class Account
    {
        public long AccountNumber { get;}
        public long AccountID { get;}
        public AccountType AccountType { get;}
        public decimal AccountBalance { get; private set; }
        public decimal Interest { get;}

        /*
         * 
         * CTOR 1/2?
         * 
         * GetAccountNumber()
         * GetAccountID()
         * GetAccountType()
         * GetAccountBalance()
         * GetBalance()
         * 
         * Withdraw() Logic if not enough money // Special logic if accounttype Credit?
         * Deposit() Logic if not < 0  // Deposit on credit account?
         * 
         * 
         */

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
