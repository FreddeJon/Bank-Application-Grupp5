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
                Interest = 1.15M;
            }
            else
            {
                Interest = 1.05M;
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





        public override string ToString()
        {
            return $"[{AccountNumber}]:{AccountType}:{AccountBalance:C}";
        }



        private Account(long accountNumber, string accountID, AccountType accountType, decimal accountBalance, decimal interest)
        {
            AccountNumber = accountNumber;
            AccountID = accountID;
            AccountType = accountType;
            AccountBalance = accountBalance;
            Interest = interest;
        }

        public static List<Account> ReadFromAccountFile()
        {
            var read = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\accounts.csv");
            List<Account> loadedAccounts = new();

            foreach (var line in read)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        var stringList = line.Split(";");
                        long accountNumber = long.Parse(stringList[0]);
                        string accountID = stringList[1];
                        AccountType accountType;
                        if (stringList[2].ToLower() == "savings")
                        {
                            accountType = AccountType.Saving;
                        }
                        else
                        {
                            accountType = AccountType.Spending;
                        }
                        decimal accountBalance = decimal.Parse(stringList[3]);
                        decimal interest = decimal.Parse(stringList[4]);

                        loadedAccounts.Add(new Account(accountNumber, accountID, accountType, accountBalance, interest));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadLine();
                    }

                }
            }
            return loadedAccounts;
        }


        public static void SaveAccountsToFile()
        {
            List<Account> allAccounts = new();
            foreach (var customer in Bank.GetCustomers())
            {
                foreach (var account in customer.GetCustomerAccounts())
                {
                    allAccounts.Add(account);
                }
            }

            var accountsToSave = new string[allAccounts.Count];
            int i = 0;
            foreach (var account in allAccounts)
            {
                accountsToSave[i] = $"{account.AccountNumber};{account.AccountID};{account.AccountType};{account.AccountBalance};{account.Interest}";
                i++;
            }

            File.WriteAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\accounts.csv", accountsToSave);

        }
    }
}
