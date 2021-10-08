using BankLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Invalid input");
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
                    case "3":
                        break;
                    case "4": // Exit

                        break;
                    default:
                        break;
                }quit = true;
            }

        }

    }

}
