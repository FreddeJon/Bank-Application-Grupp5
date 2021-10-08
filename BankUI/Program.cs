using BankLogic;
using System;

namespace BankUI
{
    class Program
    {

        public static void Main(string[] args)
        {

            // Test
            string text = "19930107";
            if (text.ValidateCustomerID())
            {
                Console.WriteLine($"{text} validated");
            }
            else
            {
                Console.WriteLine($"{text} not valid");
            }
            Console.ReadLine();
            // Test
             
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            string name, lastname, personnr;

            /*
             * TODO
             * class AddCustomer, 
             * Regex validating name. Turn string.ToLower first letter to upper, only letters
             * validating customer id: must be YYYYMMDD cant already exists user with that id
             * 
             * 
             * class ShowCustomerMenu
             * Change name
             * Delete account
             * 
             * 
             * Class AccountMenu
             * create account validate?
             * delete account validate?
             * deposit to account Validate?
             * withdraw from account validate?
             * 
             * 
             * seperate class for validating?
             * Class Validate
             * methods
             * validate name
             * validate customerID
             * validate ...
             */

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Customer: "); // class AddCustomer
            Console.WriteLine("2. Show Customer");// class ShowCustomer
            Console.WriteLine("3. Show All Customers");
            Console.WriteLine("4. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please Enter your Name: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Please Enter your Last Name: ");
                    lastname = Console.ReadLine();

                    Console.WriteLine("Please Enter your Personnummer: ");
                    personnr = Console.ReadLine();

                    Bank.AddCustomer(name, lastname, personnr);
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Please Enter Personnummer to remove: ");
                    personnr = Console.ReadLine();

                    //Bank.RemoveCustomer(personnr); Funkade inte
                    Bank.RemoveCustomer(personnr);
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    return true;
                case "3":
                    Bank.GetCustomers(); 
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }


}
