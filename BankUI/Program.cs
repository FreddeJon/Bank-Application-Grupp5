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
            Bank.AddCustomer("fredrik".FirstToUpper(),  "jonson".FirstToUpper(), "19930507");




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
             */

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Customer: "); 
            Console.WriteLine("2. Show Customer");
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
                    CustomerMenu.Start();
                    return true;
                case "3":
                    foreach (var cust in Bank.GetCustomers())
                    {
                        Console.WriteLine(cust.ToString());
                    }
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
