
using BankLogic;
using System;
using System.Threading;

namespace BankUI
{
    public class CustomerMenu
    {
        public static Customer CurrentCustomer { get; private set;}


        public static void Start()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Enter Socialnumber [YYYYMMDD] [e] to exit: ");
                Console.Write("Enter: ");
                string customerID = Console.ReadLine().ToLower();
                if (customerID == "e") 
                {
                    quit = true;
                }
                else if (customerID.ValidateCustomerID())
                {
                    if (customerID.CustomerExists())
                    {
                        CurrentCustomer = Bank.GetCustomerByCustomerID(customerID);
                        quit = true;
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Following customer number does not exist");
                        Program.PushToContinue();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input enter [YYYYMMDD]");
                    Program.PushToContinue();
                }
            }
        }


        //Customer Menu
        private static void Menu()
        {
            //AccountMenu
            //Change name
            //Delete account
            //Exit
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                CustomerHeader();
                Console.WriteLine("1. Accounts\n2. Change Name\n3. Delete Customer\n4. Back");
                switch (Console.ReadLine())
                {
                    case "1": // Account Menu
                        AccountMenu.Start();
                        break;
                    case "2": // Change name
                        ChangeName();
                        break;
                    case "3": // Get Customer, get are you sure (Y/N) Return account fundings and interest then delete
                        if (DeleteCustomer()) quit = true;
                        break;
                    case "4": // Exit
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }


        //Delete Customer
        private static bool DeleteCustomer()
        {
            bool deleted = false;
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Are you sure you want to close your account?");
                Console.Write("[Y/N]: ");

                switch (Console.ReadLine().ToLower().Trim())
                {
                    case "y":
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write(".. ");
                            Thread.Sleep(400);
                        }
                        Console.WriteLine();
                        decimal total = 0;
                        decimal interest = 0;

                        foreach (var account in CurrentCustomer.GetCustomerAccounts())
                        {
                            total += account.GetAccountBalance() * account.GetInterest();
                            interest += (account.GetAccountBalance() * account.GetInterest()) - account.GetAccountBalance();
                            Console.WriteLine($"Deleted account [{account.GetAccountNumber()}]");
                        }
                        if (interest > 0)
                        {
                            Console.WriteLine($"Deleted Customer: {CurrentCustomer.GetName()}\nPayout: {total:C}\nInterest: {interest:C}");
                        }
                        else
                        {
                            Console.WriteLine($"Deleted Customer: {CurrentCustomer.GetName()}\nPayout: {total:C}");

                        }
                        Bank.RemoveCustomer(CurrentCustomer.GetCustomerID());

                        Console.WriteLine("Enter to continue");
                        Console.ReadLine();

                        quit = true;
                        deleted = true;
                        break;
                    case "n":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
            return deleted;
        }


        //Change name
        public static void ChangeName()
        {
            bool quit = false;
            bool dontChangeLast = false;

            string firstName = string.Empty;
            string lastName = string.Empty;
            while (!quit)
            {
                string temp = GetNewName("firstname");

                if (!string.IsNullOrWhiteSpace(temp))
                {
                    firstName = temp.UpperCase();
                    while (!dontChangeLast)
                    {
                        Console.WriteLine("Do you want to change your lastname to? [Y/N]");
                        string userInput = Console.ReadLine().ToLower();
                        switch (userInput)
                        {
                            case "y":
                                temp = GetNewName("lastname");
                                if (!string.IsNullOrWhiteSpace(temp))
                                {
                                    lastName = temp.UpperCase();
                                    dontChangeLast = true;
                                }
                                break;
                            case "n":
                                dontChangeLast = true;
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }
                    }
                }
                quit = true;
            }
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                CurrentCustomer.ChangeName(firstName, lastName);
            }
            else if (!string.IsNullOrWhiteSpace(firstName))
            {
                CurrentCustomer.ChangeName(firstName, CurrentCustomer.GetLastName());
            }
        }


        //Method that changes name uses to get name
        public static string GetNewName(string firstOrLast)
        {
            string name = string.Empty;
            bool quit = false;
            while (!quit)
            {

                Console.WriteLine($"Enter a new {firstOrLast} [e] to exit");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "e")
                {
                    quit = true;
                }
                else if (userInput.ValidateName())
                {
                    name = userInput;
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return name;
        }


        //Header
        public static void CustomerHeader()
        {

            string header = $"{CurrentCustomer.GetName()}";
            string lines = string.Empty;
            for (int i = 0; i < header.Length; i++)
            {
                lines += "-";
            }
            Console.WriteLine($"{header}\n{lines}");

        }
    }
}
