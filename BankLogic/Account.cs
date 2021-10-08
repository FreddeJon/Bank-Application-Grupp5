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
        public long AccountID { get; }
        public AccountType AccountType { get; }
        public decimal AccountBalance { get; private set; }
        public decimal Interest { get; }

        //Constructor
        public Account(long accountId, AccountType accountType )
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

       
        //Get the account number and return it
        public long GetAccountNumber()
        {
            return AccountNumber;
        }

        //Get the account ID and return it
        public long GetAccountId()
        {
            return AccountID;
        }

        //Get the account type and return it
        public AccountType accountType()
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
