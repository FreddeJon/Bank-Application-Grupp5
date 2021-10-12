using BankLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUI
{
    public class AccountMenu
    {

        private static Customer CurrentCustomer;
        public static void Start()
        {
            CurrentCustomer = CustomerMenu.CurrentCustomer;
            //While loop, switch
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("1. Deposit\n2. Withdraw\n3. Add Account\n4. Delete Account\n5. Back");
                switch (Console.ReadLine())
                {
                    case "1": // Deposit
                        if (CurrentCustomer.GetCustomerAccounts().Count > 0)
                        {
                            Deposit();
                        }
                        else
                        {
                            Console.WriteLine("You dont have any accounts");
                        }
                        break;
                    case "2": // Withdraw
                        if (CurrentCustomer.GetCustomerAccounts().Count > 0)
                        {
                            Withdraw();
                        }
                        else
                        {
                            Console.WriteLine("You dont have any accounts");
                        }

                        break;
                    case "3": // Add Account
                        AddAccount();
                        break;
                    case "4": // Delete Account
                        if (CurrentCustomer.GetCustomerAccounts().Count > 0)
                        {
                            DeleteAccount();
                        }
                        else
                        {
                            Console.WriteLine("You dont have any accounts");
                        }
                        break;
                    case "5": // Exit
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        private static Account SelectAccount()
        {
            bool quit = false;
            Account selectedAccount = null;
            while (!quit)
            {
                Console.WriteLine("Select by account number [e] to exit");
                Console.Write("Enter: ");

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "e")
                {
                    quit = true;
                }
                else if (long.TryParse(userInput, out long accountNumber))
                {
                    Account currentAccount = CurrentCustomer.GetAccountByAccountNumber(accountNumber);
                    if (currentAccount != null)
                    {
                        selectedAccount = currentAccount;
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("You dont have an account with that account number");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            return selectedAccount;
        }


        //Deposit
        private static void Deposit()
        {
            bool quit = false;
            var account = SelectAccount();

            if (account == null) quit = true;

            while (!quit)
            {
                Console.WriteLine("Enter amount to deposit [e] to end session");
                Console.Write("Enter: ");

                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "e")
                {
                    quit = true;
                }
                else if (decimal.TryParse(userInput, out decimal amount))
                {
                    if (account.Deposit(amount))
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("You can't add a negative amount");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }



        private static void Withdraw()
        {
            bool quit = false;
            var account = SelectAccount();

            if (account == null) quit = true;

            while (!quit)
            {
                Console.WriteLine("Enter amount to withdraw [e] to end session");
                Console.Write("Enter: ");

                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "e")
                {
                    quit = true;
                }
                else if (decimal.TryParse(userInput, out decimal amount))
                {
                    if (account.Withdraw(amount))
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("You dont have enough balance");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }


        private static void AddAccount()
        {
            bool quit;
            do
            {
                quit = true;
                Console.WriteLine("Which type of account do you want do open [e] to end");
                Console.Write("Saving/Spending: ");
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "e":
                        break;
                    case "saving":
                        CurrentCustomer.AddAccount(AccountType.SavingsAccount);
                        break;
                    case "spending":
                        CurrentCustomer.AddAccount(AccountType.SpendingAccount);
                        break;
                    default:
                        quit = false;
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (!quit);
        }

        private static void DeleteAccount()
        {
            bool quit = false;
            Account account = SelectAccount();

            if (account == null) quit = true;

            while (!quit)
            {
                var total = account.GetAccountBalance() * account.GetInterest();
                var interest = total - account.GetAccountBalance();
                Console.WriteLine($"Deleted account [{account.GetAccountNumber()}]\nPayout: {total:C}\nInterest: {interest:C}");
                CurrentCustomer.RemoveAccount(account.GetAccountNumber());
            }
        }
    }
}
