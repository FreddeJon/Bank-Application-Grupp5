﻿
using BankLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BankUI
{
    class CustomerMenu
    {
        private static Customer CurrentCustomer { get; set; }


        public static void Start()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Enter CustomerID [e] to exit");
                string customerID = Console.ReadLine().ToLower();
                if (customerID == "e")    // || or    && and 
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
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input enter [YYYYMMDD]");
                }
            }
        }


        private static void Menu()
        {
            //AccountMenu
            //Change name
            //Delete account
            //Exit
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("1. Show Accounts\n2. Change Name\n3. Delete account\n4. Exit");
                switch (Console.ReadLine())
                {
                    case "1": // AccountMenu finns inte just nu
                        break;
                    case "2":
                        break;
                    case "3": // Get Customer, get are you sure (Y/N) Return account fundings and interest then delete
                        if (DeleteCustomer())
                        {
                            quit = true;
                        }
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
                        for(int i = 0; i < 3; i++)
                        {
                            Console.Write(".. ");
                            Thread.Sleep(400);
                        }

                        Console.WriteLine("Deleted enter to continue");
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
    }
}
