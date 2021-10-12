﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BankLogic
{
    public static class Bank
    {
        private static List<Customer> CustomerList { get; set; } = new List<Customer>();


        public static bool AddCustomer(string fname, string lname, string id)
        {
            var customerid = CustomerList.FirstOrDefault(x => x.GetCustomerID() == id);

            if (customerid == null)
            {
                CustomerList.Add(new Customer(fname, lname, id));
                return true;
            }

            else
            {
                return false;
            }
        }

        public static List<Customer> GetCustomers() => CustomerList;

        public static Customer GetCustomerByCustomerID(string id) => CustomerList.FirstOrDefault(x => x.GetCustomerID() == id);


        public static void RemoveCustomer(string id)
        {
            CustomerList.Remove(GetCustomerByCustomerID(id));
        }

        public static long GetUniqueAccountNumber()
        {
            string read = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\currentAccount.csv");

            _ = long.TryParse(read, out long currentAccount);

            if (currentAccount >= 1002)
            {
                SaveUniqueAccountNumber(currentAccount + 1);
                return currentAccount;
            }
            else
            {
                SaveUniqueAccountNumber(1002);
                return 1001;
            }
        }


        public static void SaveUniqueAccountNumber(long number)
        {
            File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\currentAccount.csv", number.ToString());
        }


        public static void LoadFromTextFile()
        {
            CustomerList = Customer.ReadFromCustomerFile();
        }
        public static void SaveToTextFile()
        {
            var customersToSave = new string[CustomerList.Count()];
            int i = 0;
            foreach (var customer in CustomerList)
            {
                customersToSave[i] = $"{customer.GetFirstName()},{customer.GetLastName()},{customer.GetCustomerID()}";
            }
            File.WriteAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\Customer.csv", customersToSave);
        }
    }
}
