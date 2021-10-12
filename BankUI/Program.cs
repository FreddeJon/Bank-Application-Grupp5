using BankLogic;
using System;

namespace BankUI
{
    class Program
    {

        public static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            string name, lastname, personnr;
            bool quit = false;
            while (!quit)
            {
                Bank.LoadFromTextFile();
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
                        Bank.AddCustomer(name.UpperCase(), lastname.UpperCase(), personnr);
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        break;
                    case "2":
                        CustomerMenu.Start();
                        break;
                    case "3":
                        foreach (var cust in Bank.GetCustomers())
                        {
                            Console.WriteLine(cust.ToString());
                        }
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        break;
                }

                Bank.SaveToTextFile();
            }
            return false;

        }

        public static void PushToContinue()
        {
            Console.WriteLine("Push any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }


}
