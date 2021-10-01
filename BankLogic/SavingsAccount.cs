﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public enum AccountType
    {
        Savings = 5,
        Spending = 2
    }
    public class SavingsAccount
    {

        public int AccountId { get; private set; }
        public double Interest { get; private set; }
        public readonly AccountType AccountType;
        private readonly long CustomerId;
        public decimal AccountBalance { get; set; }

        public SavingsAccount(AccountType type, long socialNumber)
        {
            AccountType = type;
            CustomerId = socialNumber;
            AccountId = Bank.GetCustomer(CustomerId).NumberOfAccounts;
            AccountBalance = 1000;
        }

        public void Deposit(decimal amount)
        {
            AccountBalance += amount;
            Console.WriteLine();
        }
        /// <summary>
        /// Whitdraw if the account has enough balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Withdraw(decimal amount)
        {
            bool validated = false;
            if (amount > 0 && AccountBalance - amount >= 0)
            {
                Console.WriteLine($"Withdrew {amount:C} from Account: {AccountId}");
                AccountBalance -= amount;
                validated = true;
            }
            else if (amount <= 0)
            {
                Console.WriteLine("You cant withdraw negative amounts");
            }
            else
            {
                Console.WriteLine($"{AccountId}: Balance to low");
            }
            return validated;
        }
        public override string ToString()
        {
            return $"[{AccountId}]:{AccountType}:Balance:{AccountBalance}";
        }
    }
}
