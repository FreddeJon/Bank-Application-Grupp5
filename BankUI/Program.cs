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

            Console.WriteLine(Bank.CustomerList.GetHashCode());
            AddCustomer(); 
            Console.ReadLine();
        }
        public static void AddCustomer()
        {
            
            Console.WriteLine(Bank.CustomerList.GetHashCode());
           
        }
    }


}
