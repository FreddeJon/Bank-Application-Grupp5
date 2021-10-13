using BankLogic;
using System;

namespace BankUI
{
    class Program
    {
        public static void Main()
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
                Console.WriteLine("Main Menu");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Customer Menu");
                Console.WriteLine("3. Print All Customers");
                Console.WriteLine("4. Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                    names:
                        Console.WriteLine("Please Enter your Firstname: ");
                        name = Console.ReadLine();

                        Console.WriteLine("Please Enter your Lastname: ");
                        lastname = Console.ReadLine();
                        if (!name.ValidateName() || !lastname.ValidateName())
                        {
                            Console.WriteLine("Firstname or Lastname is not correct! try again");
                            goto names;
                        }

                    person:
                        Console.WriteLine("Please Enter your Social Number [YYYYMMDD]: ");
                        personnr = Console.ReadLine();
                        if (!personnr.ValidateCustomerID() || personnr.CustomerExists())
                        {

                            if (personnr.CustomerExists())
                            {
                                Console.WriteLine("Customer with that Social Number already exists");
                                PushToContinue();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input try again [YYYYMMDD]");
                                goto person;
                            }                                                      
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


        //Print push to continue then clears after user enters anything
        public static void PushToContinue()
        {
            Console.WriteLine("Push any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }


}
