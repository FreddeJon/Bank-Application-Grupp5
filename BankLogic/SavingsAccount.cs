using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{

    /// <summary>
    /// Account Type
    /// </summary>
    public enum AccountType
    {
        Savings,
        Spending,
    }
    public class SavingsAccount
{
        public long AccountNumber { get; }
        public decimal Interest { get; private set; }
        public AccountType AccountType { get;}
        public long CustomerId { get;}
        public decimal AccountBalance { get; set; }



        /// <summary>
        /// CSV helper needs this ctor to automap a list<SavingsAccounts> from csv file
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="interest"></param>
        /// <param name="customerId"></param>
        /// <param name="accountNumber"></param>
        /// <param name="accountBalance"></param>
        public SavingsAccount(AccountType accountType, decimal interest, long customerId, int accountNumber, decimal accountBalance)
        {
            AccountType = accountType;
            Interest = interest;
            CustomerId = customerId;
            AccountBalance = accountBalance;
            AccountNumber = accountNumber;
        }



        //Ctor for new accounts
        public SavingsAccount(AccountType accountType, long customerSocialNumber)
        {
            AccountNumber = Bank.GetCurrentAccountNumber();
            AccountType = accountType;
            CustomerId = customerSocialNumber;
            AccountBalance = 0;
            if (accountType == AccountType.Savings)
            {
                Interest = 1.15m;
            }
            else
            {
                Interest = 1.05m;
            }
        }



        /// <summary>
        /// Returns interest
        /// </summary>
        /// <returns></returns>
        public decimal GetInterest()
        {
            return Interest;
        }



        /// <summary>
        /// Returns account balance
        /// </summary>
        /// <returns></returns>
        public decimal GetBalance()
        {
            return AccountBalance;
        }



        /// <summary>
        /// Deposits amount into account if amount > 0
        /// returns a true if success
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                AccountBalance += amount;
                Console.WriteLine($"Deposited {amount:C} new balance:{AccountBalance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Cant deposit negative numbers");
                return false;
            }
        }



        /// <summary>
        /// Withdraws amount from account if accounts has enough balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Withdraw(decimal amount)
        {
            bool validated = false;
            if (amount > 0 && AccountBalance - amount >= 0)
            {
                Console.WriteLine($"Withdrew {amount:C} from: {AccountNumber}");
                AccountBalance -= amount;
                validated = true;
            }
            else if (amount <= 0)
            {
                Console.WriteLine("You cant withdraw negative amounts");
            }
            else
            {
                Console.WriteLine($"[{AccountNumber}] Balance to low");
            }
            return validated;
        }



        public override string ToString()
        {
            return $"[{AccountNumber}]{AccountType}:Balance:{AccountBalance:C}";
        }



        /// <summary>
        /// Reads accounts from csv file and returns a list of accounts
        /// Needs to be in accounts class to automap accounts
        /// </summary>
        /// <returns></returns>
        public static List<SavingsAccount> ReadFromDB()
        {
            List<SavingsAccount> data = DataAccess.CSV.Read<SavingsAccount>(Bank.FilePathSavingsAccount);
            return data;
        }

    }
}
