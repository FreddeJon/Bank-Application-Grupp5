using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BankLogic
{
    public static class Bank
    {
        public static List<Customer> CustomerList { get; set; } = new List<Customer>();



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

        public static List<Customer> GetCustomers()
        {
            foreach (var customer in CustomerList)
            {
                Console.WriteLine($"Firstname: {customer.FirstName} | Lastname: {customer.LastName}");
            }
            return CustomerList;
        }

        public static List<Customer> GetCustomerByCustomerID(long id)
        {
            foreach (var customer in CustomerList.Where(c => c.GetCustomerID() == id))
            {

                Console.WriteLine($"Firstname: {customer.FirstName} | Lastname: {customer.LastName}");

            }
            return CustomerList;
        }

        public static List<Customer> RemoveCustomer(long id)
        {
            foreach (var customer in CustomerList.Where(c => c.GetCustomerID() == id))
            {
                CustomerList.Remove(customer);
            }
            return CustomerList;
        }

        public static long GetUniqueAccountNumber()
        {
            string read = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\currentAccount.csv");

            _ = long.TryParse(read, out long currentAccount);

            if (currentAccount > 0)
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
    }
}
