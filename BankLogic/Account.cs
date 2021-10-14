using System;
using System.Collections.Generic;
using System.IO;

namespace BankLogic
{

    public enum AccountType
    {
        Saving,
        Spending,
    }
    public class Account
    {
        private long AccountNumber { get; }
        private string AccountID { get; }
        private AccountType AccountType { get; }
        private decimal AccountBalance { get; set; }
        private decimal Interest { get; }




        //Constructor
        public Account(string accountId, AccountType accountType)
        {
            AccountNumber = Bank.GetUniqueAccountNumber();
            AccountID = accountId;
            AccountType = accountType;
            if (AccountType == AccountType.Saving)
            {
                Interest = 1.05M;
            }
            else
            {
                Interest = 1.01M;
            }
        }




        // Deposit
        public bool Deposit(decimal amount)
        {
            bool validated = false;
            if (amount > 0)
            {
                AccountBalance += amount;
                Console.WriteLine($"Added {amount:C} to [{AccountNumber}]\nNew balance: {AccountBalance:C}");
                validated = true;
            }
            return validated;
        }

        // Withdraw
        public bool Withdraw(decimal amount)
        {
            bool validated = false;
            if (AccountBalance - amount >= 0)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdraw {amount:C}\n[{AccountNumber}]Balance: {AccountBalance:C}");
                validated = true;
            }
            return validated;
        }




        //Get the account number and return it
        public long GetAccountNumber() => AccountNumber;

        //Get the account ID and return it
        public string GetAccountId() => AccountID;

        //Get the account type and return it
        public AccountType GetAccountType() => AccountType;

        //Get the account Balance and return it
        public decimal GetAccountBalance() => AccountBalance;

        //Get the interest and return it
        public decimal GetInterest() => Interest;

        //Overrided ToString()
        public override string ToString() => $"[{AccountNumber}] {AccountType} \nBalance: {AccountBalance:C}";




        //Constructor to create an existing account from textfile
        private Account(long accountNumber, string accountID, AccountType accountType, decimal accountBalance, decimal interest)
        {
            AccountNumber = accountNumber;
            AccountID = accountID;
            AccountType = accountType;
            AccountBalance = accountBalance;
            Interest = interest;
        }

        /// <summary>
        /// Reads all accounts from account textfile and returns a list of customers
        /// </summary>
        /// <returns></returns>
        public static List<Account> ReadFromAccountFile()
        {
            // Läser in alla konton från textfil i en string array (rad 1 index 0) (rad 2 index 1) osv
            string[] read = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\accounts.csv");
            //Skapar en ny lista där alla konton hamnar som ska skickas tillbaka
            List<Account> loadedAccounts = new();

            //går igenom varje index i string array som lästes in från textfil
            foreach (var line in read)
            {
                // Kollar så att den inte är tom
                if (!string.IsNullOrWhiteSpace(line))
                {
                    //Splitar raden på ";" och skapar en ny string array som heter stringlist
                    string[] stringList = line.Split(";");

                    // accountNumber hamnar på stringList index 0
                    long accountNumber = long.Parse(stringList[0]);
                    // accountID hamnar på stringList index 1
                    string accountID = stringList[1];
                    // accountType hamnar på stringList index 2
                    AccountType accountType;
                    if (stringList[2].ToLower() == "saving")
                    {
                        accountType = AccountType.Saving;
                    }
                    else
                    {
                        accountType = AccountType.Spending;
                    }
                    // accountBalance hamnar på stringList index 3
                    decimal accountBalance = decimal.Parse(stringList[3]);
                    // interest hamnar på stringList index 4
                    decimal interest = decimal.Parse(stringList[4]);
                    // Lägger till ett nytt Account i loadedAccounts
                    loadedAccounts.Add(new Account(accountNumber, accountID, accountType, accountBalance, interest));
                }
            }
            //Skickar tillbaka loadedAccounts
            return loadedAccounts;
        }

        /// <summary>
        /// Gets all accounts from all customers and writes them to account textfile
        /// </summary>
        public static void SaveAccountsToFile()
        {
            // Skapar en lista där alla accounts ska hamna
            List<Account> allAccounts = new();
            
            //Går igenom alla customers
            foreach (var customer in Bank.GetCustomers())
            {
                //Går igeom alla accounts customern har
                foreach (var account in customer.GetCustomerAccounts())
                {
                    //Lägger till i allAccounts
                    allAccounts.Add(account);
                }
            }
            //Skapar en string Array med lenght av allAccounts
            string[] accountsToSave = new string[allAccounts.Count];
            int i = 0;
            //Går igenom varje index i allAccounts
            foreach (var account in allAccounts)
            {
                //Lägger till all konto info
                accountsToSave[i] = $"{account.AccountNumber};{account.AccountID};{account.AccountType};{account.AccountBalance};{account.Interest}";
                i++;
            }
            //Skriver alla index i accountsToSave till account textfil
            File.WriteAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\accounts.csv", accountsToSave);
        }
    }
}
