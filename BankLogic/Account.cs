namespace BankLogic
{

    public enum AccountType
    {
        SavingsAccount,
        SpendingAccount,
    }
    public class Account
    {
        public long AccountNumber { get; }
        public string AccountID { get; }
        public AccountType AccountType { get; }
        public decimal AccountBalance { get; private set; }
        public decimal Interest { get; }

        //Constructor
        public Account(string accountId, AccountType accountType)
        {
            AccountNumber = Bank.GetUniqueAccountNumber();
            AccountID = accountId;
            AccountType = accountType;
            if (AccountType == AccountType.SavingsAccount)
            {
                Interest = 1.15M;
            }
            else
            {
                Interest = 1.05M;
            }
        }

        // Deposit
        public bool Deposit(decimal amount)
        {
            bool validated = false;
            if(amount > 0)
            {
                AccountBalance += amount;
                validated = true;
            }
            return validated;
        }

        // Withdraw
        public decimal 










        //Get the account number and return it
        public long GetAccountNumber()
        {
            return AccountNumber;
        }

        //Get the account ID and return it
        public string GetAccountId()
        {
            return AccountID;
        }

        //Get the account type and return it
        public AccountType GetAccountType()
        {
            return AccountType;
        }

        //Get the account Balance and return it
        public decimal GetAccountBalance()
        {
            return AccountBalance;
        }

        //Get the interest and return it
        public decimal GetInterest()
        {
            return Interest;
        }

        public override string ToString()
        {
            return $"[{AccountNumber}]:{AccountType}:{AccountBalance:C}";
        }
    }
}
