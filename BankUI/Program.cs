using BankLogic;
using System;

namespace BankUI
{
    class Program
    {

        public static void Main(string[] args)
        {

            //// Test
            //string text = "19930107";
            //if (text.ValidateCustomerID())
            //{
            //    Console.WriteLine($"{text} validated");
            //}
            //else
            //{
            //    Console.WriteLine($"{text} not valid");
            //}
            //Console.ReadLine();
            //// Test
            Bank.AddCustomer("fredrik",  "jonson", "19930507");




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
            Console.WriteLine("2. Choose Customer");// class ShowCustomer
            Console.WriteLine("3. Show All Customers");
            Console.WriteLine("4. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    names:
                    Console.WriteLine("Please Enter your Name: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Please Enter your Last Name: ");
                    lastname = Console.ReadLine();
                    if (!name.ValidateName() || !lastname.ValidateName())
                    {
                        Console.WriteLine("Name or Last Name is not correct! try again");
                        goto names;
                    }

                    person:
                    Console.WriteLine("Please Enter your Personnummer: ");
                    personnr = Console.ReadLine();
                    if (!personnr.ValidateCustomerID())
                    {
                        Console.WriteLine("Not correct! YYYYMMDD try again");
                        goto person;
                    }
                    Bank.AddCustomer(name.uppercase(), lastname.uppercase(), personnr);
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    return true;
                case "2":
                    CustomerMenu.Start();
                    return true;
                case "3":
                    foreach (var item in Bank.GetCustomers())
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName);
                    }
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
