using Humanizer;

namespace OdusBankApp
{
    public class AccountManager : IAccountManager
    {
        public static List<Account> Accounts = new();

        public void AddAccount(string name, string email, int accountNumber, decimal balance, int bvn)
        {
            int id = Accounts.Count > 0 ? Accounts.Count + 1 : 1;

            var account = new Account
            {
                Id = id,
                Name = name,
                Email = email,
                AccountNumber = accountNumber,
                BVN = bvn,
                Balance = 0,
                CreatedAt = DateTime.Now
            };

            Accounts.Add(account);
            System.Console.WriteLine($"\nAccount created successfully!\nThanks for choosing ODUSpay :)");
        }

        public void CheckBalance(int accountNumber)
        {
            int accountCount = Accounts.Count;

            if (accountCount == 0)
            {
                System.Console.WriteLine($"\nAccounts are yet to be opened.");
                return;
            }

            var foundAccount = FindAccount(accountNumber);
            if (foundAccount == null)
            {
                Console.WriteLine("\nAccount not found!.");
            }
            else
            {
                Console.WriteLine($"\nYour Account Balance is:" + "#" + foundAccount.Balance);
            }
        }

        public void Deposit(int accountNumber)
        {
            int accountCount = Accounts.Count;

            if (accountCount == 0)
            {
                System.Console.WriteLine($"\nAccounts are yet to be opened.");
                return;
            }

            var foundAccount = FindAccount(accountNumber);
            if (foundAccount != null)
            {
                Console.Write("Enter deposit amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                foundAccount.Balance += amount;
                Console.WriteLine($"Deposit successful.\nYour new balance is #{foundAccount.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public bool IsUserExist(int accountNumber)
        {
            return Accounts.Exists(acc => acc.AccountNumber == accountNumber);
        }

        public void SearchAccount(int accountNumber)
        {
            int accountCount = Accounts.Count;

            if (accountCount == 0)
            {
                System.Console.WriteLine($"\nAccounts are yet to be opened.");
                return;
            }

            var foundAccount = FindAccount(accountNumber);
            if (foundAccount == null)
            {
                System.Console.WriteLine($"\nAccount with account number {accountNumber} not found");
                return;
            }
            else
            {
                System.Console.WriteLine($"\nSearching Account...");

                System.Console.WriteLine($"\nAccount Found!");

                Console.WriteLine($"\n===ACCOUNT DETAILS===\nAccount ID: {foundAccount.Id}\nCreated At: {foundAccount.CreatedAt.Humanize()}.\nAccount Holder: {foundAccount.Name}\nAccount Number: {foundAccount.AccountNumber}\nAccount Holder Email: {foundAccount.Email}");
            }
        }

        public void CloseAccount(int accountNumber)
        {
            int accountCount = Accounts.Count;

            if (accountCount == 0)
            {
                System.Console.WriteLine($"\nAccounts are yet to be opened.");
                return;
            }

            var foundAccount = FindAccount(accountNumber);
            if (foundAccount == null)
            {
                System.Console.WriteLine($"\nAccount with account number {accountNumber} not found");
                return;
            }
            else
            {
                System.Console.WriteLine($"\nClosing Account :( ...");

                System.Console.WriteLine($"\nAccount Closed!");
                Accounts.Remove(foundAccount);
            }
        }

        public void Transfer(int accountNumber)
        {
            int accountCount = Accounts.Count;

            if (accountCount == 0)
            {
                System.Console.WriteLine($"\nAccounts are yet to be opened.");
                return;
            }

            var senderAccount = FindAccount(accountNumber);
            if (senderAccount == null)
            {
                System.Console.WriteLine("\nSender Account not found!.");
                return;
            }
            else
            {
                System.Console.Write("\nEnter recipient's Account Number: ");
                int recipientAcctNum = Convert.ToInt32(Console.ReadLine());

                var recipientAccount = FindAccount(recipientAcctNum);
                if (recipientAccount == null)
                {
                    System.Console.WriteLine("\nRecipient account not found.");
                    return;
                }
                else
                {
                    Console.Write("\nEnter transfer amount: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    if (senderAccount.Balance > amount) // Check if sender has sufficient fund to transfer
                    {
                        senderAccount.Balance -= amount; //Withdraw amount from sender account
                        recipientAccount.Balance += amount; //Add Deposit amount to recipient account
                        System.Console.WriteLine("\nTransaction successful.");
                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient funds for transfer.");
                        return;
                    }
                    return;
                }

            }


        }

        public Account? FindAccount(int accountNumber)
        {
            return Accounts.Find(acc => acc.AccountNumber == accountNumber);

        }

        // public void Withdraw(decimal amount)
        // {
        //     Balance -= amount;
        // }

        // public bool HasSufficientFunds(decimal amount)
        // {
        //     return Balance > amount;
        // }
    }
}
