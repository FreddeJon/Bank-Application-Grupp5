using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
   public static class Bank
    {
        public static List<Customer> CustomerList { get; set; } = new List<Customer>();




        /*
         * 
         *
         * 
         * GetCustomers()
         * GetCustomerByCustomerID()
         * 
         * AddCustomer()
         * 
         * RemoveCustomer()
         * 
         * 
         * 
         */

        public bool AddCustomer(long id, string fname, string lname)
        {
          var customerid=  CustomerList.FirstOrDefault(x=> x.CustomerID==id);

            if (customerid == null)
            {
                CustomerList.Add(new Customer { FirstName=fname, LastName=lname});
                return true
            }

            else
            {
                return false;
            }
        }

        public List<Customer> GetCustomers()
        {
            foreach (var customer in CustomerList)
            {
                Console.WriteLine($"Firstname: {customer.FirstName} | Lastname: {customer.LastName}");
            }
	       return CustomerList;
        }

        public List<Customer> GetCustomerByCustomerID(long id)
        {
            foreach (var customer in CustomerList.Where(c=> c.CustomerID == id))
            { 

            Console.WriteLine($"Firstname: {customer.FirstName} | Lastname: {customer.LastName}");
                
            }
	         return CustomerList;
        }

        public List<Customer> RemoveCustomer()
        {
            foreach (var customer in CustomerList.Where(c=> c.CustomerID == id))
            {
                CustomerList.Remove(customer);
            }
	        return CustomerList;
        }
    }
}
