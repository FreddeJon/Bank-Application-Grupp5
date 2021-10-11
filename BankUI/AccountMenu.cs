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
        public static void Start()
        {

            //While loop, switch
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("1. Deposit\n2. Withdraw\n3. Add Account\n4. Delete Account\n5. Back");
                switch (Console.ReadLine())
                {
                    case "1": // Deposit
                        Deposit();
                        break;
                    case "2": // Withdraw
                        Withdraw();
                        break;
                    case "3": // Add Account
                        AddAccount();
                        break;
                    case "4": // Delete Account
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
                    Account currentAccount = CustomerMenu.CurrentCustomer.GetAccountByAccountNumber(accountNumber);
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
            Account account = SelectAccount();
            bool quit = false;
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
            Account account = SelectAccount();
            bool quit = false;
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
                        CustomerMenu.CurrentCustomer.AddAccount(AccountType.SavingsAccount);
                        break;
                    case "spending":
                        CustomerMenu.CurrentCustomer.AddAccount(AccountType.SpendingAccount);
                        break;
                    default:
                        quit = false;
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (!quit);
        }
    }
}
