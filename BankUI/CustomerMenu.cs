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
        public void Run()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Enter CustomerID [e] to exit");
                string userInp = Console.ReadLine().ToLower();
                if (userInp == "e")    // || or    && and 
                {
                    quit = true;
                }
                else if (userInp.ValidateCustomerID())
                {

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
         
        }

    }
}
