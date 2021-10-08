using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public static class Bank
    {
        public static List<Customer> CustomerList { get; set; } = new List<Customer>();



        public static bool AddCustomer(long id, string fname, string lname)
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
            string read = File.ReadAllText("currentAccount.csv");

            _ = long.TryParse(Console.ReadLine(), out long currentAccount);

            if (currentAccount > 0)
            {
                SaveUniqueAccountNumber(currentAccount);
                return currentAccount;
            }
            else
            {
                SaveUniqueAccountNumber(1001);
                return 1001;
            }           
        }
        public static void SaveUniqueAccountNumber(long number)
        {
            File.WriteAllText((Path.Combine(Directory.GetCurrentDirectory(), "currentAccount.csv")), number.ToString());
        }
    }
}
