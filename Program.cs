using OdusBankApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MyMenu();
    }
}

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Create a BVN(generate randomly same as account number), an account with the BVN or not, search account, deposit & transfer,check ballance, close account, check if sufficient fund using (ballance > transfer amount)
// Transfer: Using nested if statement Check if sender acct is exist, check if recipient acct exist, if both exist now check if sender has sufficient fund if sender has SF, now withdraw amount from sender and deposit amount to recipient acct.
// Close account just as deleting user using  Accounts.Remove();
// Account details: Name, Acct No, BVN, email, Account type (Savings or Current)


