namespace OdusBankApp
{
    interface IAccountManager
    {
        void AddAccount(string name, string email, int accountNumber, decimal balance, int bvn);
        void SearchAccount(int accountNumber);
        void Deposit(int accountNumber);
        void Transfer(int accountNumber);
        void CheckBalance(int accountNumber);
        void CloseAccount(int accountNumber);
        bool IsUserExist(int accountNumber);
    }
}