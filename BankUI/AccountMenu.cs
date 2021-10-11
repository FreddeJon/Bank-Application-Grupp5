using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUI
{
    public class AccountMenu
    {
        public static void Start()
        {
            //While loop, switch
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("1. TBA\n2.TBA\n3. TBA\n4. TBA\n5. Back");
                switch (Console.ReadLine())
                {
                    case "1": // Deposit
                        break;
                    case "2": // Withdraw
                        break;
                    case "3": // Add Account
                        break;
                    case "4": // Delete Account
                        break;
                    case "5": // Exit
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
