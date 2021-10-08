using BankLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string name, lastname;
            long personnr;

            
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Customer: ");
            Console.WriteLine("2. Remove Customer");
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
                    personnr = Convert.ToInt32(Console.ReadLine());

                    Bank.AddCustomer(personnr, name, lastname);
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Please Enter Personnummer to remove: ");
                    personnr = Convert.ToInt32(Console.ReadLine());

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
