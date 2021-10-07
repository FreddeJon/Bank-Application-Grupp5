using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{

    public enum AccountType
    {
        SavingsAccount,
        SpendingAccount,
        //CreditAccount?
    }
    public class Account
    {
        public long AccountNumber { get; }
        public long AccountID { get; }
        public AccountType AccountType { get; }
        public decimal AccountBalance { get; private set; }
        public decimal Interest { get; }

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
        public Account(long accountNumber, long accountId, AccountType accountType )
        {
            AccountNumber = accountNumber;
            AccountID = accountId;
            AccountType = accountType;
            if (AccountType == AccountType.SavingsAccount)
            {
                Interest = 1.15M;
            }
            else
            {
                Interest = 1.05M;
            }
        }

        public long GetAccountNumber()
        {
            return AccountNumber;
        }
        public long GetAccountId()
        {
            return AccountID;
        }
        public AccountType accountType()
        {
            return AccountType;
        }
        public decimal GetAccountBalance()
        {
            return AccountBalance;
        }
        public decimal GetInterest()
        {
            return Interest;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
