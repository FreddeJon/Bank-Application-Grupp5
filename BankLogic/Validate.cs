using System.Linq;
using System.Text.RegularExpressions;

namespace BankLogic
{
    public static class Validate
    {
        /// <summary>
        /// Returns name uppercase if name is valid
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string UpperCase(this string name)
        {
            string s = name[0].ToString().ToUpper() + name.Substring(1);
            return s;
        }
        /// <summary>
        /// Returns true if name is valid
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidateName(this string name)
        {
            return Regex.Match(name, "^[a-öA-Ö]*$").Success && !string.IsNullOrWhiteSpace(name);
        }



        /// <summary>
        /// Returns true if valid customerID format YYYYMMDD Input should be a string
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool ValidateCustomerID(this string customerID)
        {
            // Inte så snyggt men det fungerar
            bool validated = false;
            if (long.TryParse(customerID, out long _))
            {
                if (Regex.Match(customerID, "\\A[0-9]{8}\\z").Success)
                {
                    if (long.TryParse(customerID[0..4], out long year))
                    {
                        if (year > 1900 && year < 2021)
                        {
                            if (long.TryParse(customerID[4..6], out long month))
                            {
                                if (month > 0 && month < 13)
                                {
                                    if (long.TryParse(customerID[6..], out long day))
                                    {
                                        if (day > 0 && day < 32)
                                        {
                                            validated = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                } 
            }

            return validated;
        }



        /// <summary>
        /// Checks if customer exists
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool CustomerExists(this string customerID)
        {
            var exists = Bank.GetCustomers().Where(x => x.GetCustomerID() == customerID).ToList();
            return exists.Count > 0;
        }
    }
}
