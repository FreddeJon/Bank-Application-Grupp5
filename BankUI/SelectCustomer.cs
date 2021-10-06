﻿using BankLogic;
using System;
using System.Linq;

namespace BankUI
{
    class Select
    {
        private static Customer CurrentCustomer { get; set; }
        public static void Customer()
        {
            bool quit = false;
            while (!quit)
            {
                while (true)
                {
                    Console.WriteLine("Select by social number [e] to go back to menu");
                    Console.WriteLine("----------------------------------------------");
                    Console.Write("Enter socialnumber: ");
                    string userInp = Console.ReadLine();
                    if (userInp.ToLower() == "e")
                    {
                        quit = true;
                        Console.Clear();
                        break;
                    }
                    else if (long.TryParse(userInp, out long socialNumber))
                    {
                        CurrentCustomer = Bank.GetCustomerBySocialNumber(socialNumber);
                        if (CurrentCustomer != null)
                        {
                            quit = true;
                            Console.Clear();
                            CustomerMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"No customer with socialnumber {socialNumber} found");
                            Program.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input (8 digits)");
                        Program.Clear();
                    }
                }
            }
        }

        private static void CustomerMenu()
        {
            bool quit = false;
            while (!quit)
            {
                PrintCustomerHeader();
                Console.WriteLine("1. Show accounts\n2. Change name\n3. Close account\n4. Back");
                _ = Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        AccountMenu();
                        break;
                    case 2:
                        break;
                    case 3: // ADD LOGIC TO PRINT OUT VALUE OF ALL ACCOUNTS
                        bool quit2 = false;
                        while (!quit2)
                        {
                            PrintCustomerHeader();
                            Console.WriteLine("Are you sure you want to close the account? Y/N");
                            Console.Write("Enter: ");
                            string usrInp = Console.ReadLine();
                            switch (usrInp.ToLower())
                            {
                                case "y":
                                    CurrentCustomer = Bank.GetCustomerBySocialNumber(CurrentCustomer.GetCustomerSocialNumber());
                                    decimal total = 0;
                                    decimal balance = 0;
                                    decimal interest = 0;

                                    Console.Clear();
                                    PrintCustomerHeader();
                                    foreach (var account in CurrentCustomer.GetAccounts())
                                    {
                                        total += account.GetBalance() * account.GetInterest();
                                        balance += account.GetBalance();
                                        interest += total - balance;
                                    }
                                    if (total > 0)
                                    {
                                        Console.WriteLine("Closed accounts");
                                        Console.WriteLine($"Payment\nTotal: {total:c}\nAmount in interest: {interest:C}");                                   
                                    }
                                    else
                                    {
                                        Console.WriteLine("Closed accounts");
                                    }
                                    Console.Write("Enter to continue");
                                    Console.ReadLine();
                                    Bank.RemoveCustomer(CurrentCustomer.GetCustomerSocialNumber());
                                    quit2 = true;
                                    quit = true;
                                    break;
                                case "n":
                                    quit2 = true;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.Clear();
            }
        }

        private static void AccountMenu()
        {
            bool quit = false;

            while (!quit)
            {
                PrintAccountHeader();
                Console.WriteLine("1. Deposit\n2. Withdraw\n3. Create new account\n4. Back");
                _ = Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1: // Deposit
                        if (CurrentCustomer.GetAccounts().Count > 0)
                        {
                            bool quitDepositMenu = false;
                            Console.Clear();
                            while (!quitDepositMenu)
                            {
                                PrintAccountHeader();
                                Console.WriteLine("Enter accountnumber to deposit to [e] to exit");

                                string usrInp = Console.ReadLine();
                                if (usrInp.ToLower() == "e")
                                {
                                    break;
                                }
                                else if (!long.TryParse(usrInp, out long accountNumber))
                                {
                                    Console.Clear();
                                    PrintAccountHeader();
                                    Console.WriteLine("Invalid input");
                                    Program.Clear();
                                }
                                else
                                {
                                    if (CurrentCustomer.GetAccounts().Where(x => x.AccountNumber == accountNumber).ToList().Count > 0)
                                    {
                                        var account = CurrentCustomer.GetAccountByAccountNumber(accountNumber);
                                        while (true)
                                        {
                                            Console.Clear();
                                            PrintAccountHeader();
                                            Console.WriteLine("Enter amount to deposit [e] to exit");
                                            string useInp = Console.ReadLine();
                                            if (useInp.ToLower() == "e")
                                            {
                                                quitDepositMenu = true;
                                                break;
                                            }
                                            else if (decimal.TryParse(useInp, out decimal amount))
                                            {
                                                if (account.Deposit(amount))
                                                {
                                                    quitDepositMenu = true;
                                                    Console.Write("Enter to continue");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input");
                                                Program.Clear();
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        PrintAccountHeader();
                                        Console.WriteLine("Following account does not exist");
                                        Program.Clear();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You dont have any accounts");
                            Program.Clear();
                        }
                        break;
                    case 2: // Withdraw
                        if (CurrentCustomer.GetAccounts().Count > 0)
                        {
                            bool quitWithdrawMenu = false;
                            Console.Clear();
                            while (!quitWithdrawMenu)
                            {
                                PrintAccountHeader();
                                Console.WriteLine("Enter account number to withdraw from [e] to exit");

                                string usrInp = Console.ReadLine();
                                if (usrInp.ToLower() == "e")
                                {
                                    break;
                                }
                                else if (!long.TryParse(usrInp, out long accountNumber))
                                {
                                    Console.Clear();
                                    PrintAccountHeader();
                                    Console.WriteLine("Invalid input");
                                    Program.Clear();
                                }
                                else
                                {
                                    var accounts = CurrentCustomer.GetAccounts().Where(x => x.AccountNumber == accountNumber).ToList();
                                    if (accounts.Count > 0)
                                    {
                                        var account = CurrentCustomer.GetAccountByAccountNumber(accountNumber);
                                        while (true)
                                        {
                                            Console.Clear();
                                            PrintAccountHeader();
                                            Console.WriteLine("Enter amount to withdraw [e] to exit");
                                            string useInp = Console.ReadLine();
                                            if (useInp.ToLower() == "e")
                                            {
                                                quitWithdrawMenu = true;
                                                break;
                                            }
                                            else if (decimal.TryParse(useInp, out decimal amount))
                                            {
                                                if (account.Withdraw(amount))
                                                {
                                                    quitWithdrawMenu = true;
                                                    Console.Write("Enter to continue");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input");
                                                Program.Clear();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        PrintAccountHeader();
                                        Console.WriteLine("Following account does not exist");
                                        Program.Clear();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You dont have any accounts");
                            Program.Clear();
                        }
                        break;
                    case 3: // Create
                        if (CurrentCustomer.NumberOfAccounts < 5)
                        {
                            bool quitCreateAccount = false;
                            while (!quitCreateAccount)
                            {
                                Console.Clear();
                                PrintAccountHeader();
                                Console.WriteLine("[Saving/Spending] [e] to exit");
                                string userInp = Console.ReadLine();
                                switch (userInp.ToLower())
                                {
                                    case "e":
                                        quitCreateAccount = true;
                                        break;
                                    case "saving":
                                        CurrentCustomer.CreateAccount(AccountType.Savings);
                                        quitCreateAccount = true;
                                        break;
                                    case "spending":
                                        CurrentCustomer.CreateAccount(AccountType.Spending);
                                        quitCreateAccount = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input");
                                        Program.Clear();
                                        break;
                                }
                            }
                            Bank.SaveToDB();
                        }
                        else
                        {
                            Console.WriteLine("You have to many accounts");
                        }
                        Program.Clear();
                        break;
                    case 4: // EXIT
                        quit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Program.Clear();
                        break;
                }
            }


        }
        private static void PrintCustomerHeader()
        {
            string header = CurrentCustomer.GetCustomerName() + ":" + CurrentCustomer.GetCustomerSocialNumber();
            string lines = string.Empty;
            foreach (var letter in header)
            {
                lines += "-";
            }
            Console.WriteLine(header + "\n" + lines);
        }
        private static void PrintAccountHeader()
        {
            string header = CurrentCustomer.GetCustomerName() + ":" + CurrentCustomer.GetCustomerSocialNumber();
            string lines = string.Empty;
            foreach (var letter in header)
            {
                lines += "-";
            }
            Console.WriteLine(header + "\n" + lines);
            if (CurrentCustomer.GetAccounts().Count > 0)
            {
                foreach (var account in CurrentCustomer.GetAccounts())
                {
                    Console.WriteLine(account.ToString());
                }
            }
            else
            {
                Console.WriteLine("You have no accounts, do you wish to create one?");
            }
            Console.WriteLine(lines);
        }
    }
}
