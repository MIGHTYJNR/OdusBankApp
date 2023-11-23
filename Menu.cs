using System.Runtime.CompilerServices;

namespace OdusBankApp
{
    public class Menu
    {
        public Menu()
        {
            accountManager = new AccountManager();
        }
        private readonly AccountManager accountManager;


        public static void PrintMenu()
        {
            Console.Title = "ODUSpay Virtual Console";

            Console.WriteLine("===Welcome To ODUSpay Virtual Bank===");


            Console.WriteLine("\nWhat would you like to do?\n");
            Console.WriteLine("* Create Account Press 1. ");
            Console.WriteLine("* Search Account Press 2. ");
            Console.WriteLine("* Deposit Funds Press 3. ");
            Console.WriteLine("* Make Transfer Press 4. ");
            Console.WriteLine("* Check Account Balance Press 5. ");
            Console.WriteLine("* Close Account Press 6. ");
            Console.WriteLine("* Exit Press 0. ");
        }

        public void MyMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Clear();
                PrintMenu();
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            System.Console.WriteLine("==Input Account Holder Details==");

                            System.Console.Write("Enter Fullname [Surname Firstname Middlename]: ");
                            string name = Console.ReadLine()!;
                            name = name.ToUpper();

                            System.Console.Write("Enter Active E-mail: ");
                            string email = Console.ReadLine()!;
                            email = email.ToLower();

                            decimal balance = 0;

                            Random random = new();
                            int accountNumber = random.Next(0000000000, 1999999999);
                            int bvn = random.Next(0000000000, 1999999999);

                            System.Console.WriteLine($"Your Account Number is: {accountNumber}");

                            System.Console.WriteLine($"Your Account BVN Number is: {bvn}");

                            accountManager.AddAccount(name, email, accountNumber, balance, bvn);
                            break;
                        case 2:
                            Console.WriteLine("\nSearching Initiated...");
                            Console.Write("Enter Account Number: ");
                            int searchAccount = Convert.ToInt32(Console.ReadLine()!);

                            accountManager.SearchAccount(searchAccount);
                            break;
                        case 3:
                            Console.WriteLine("\nInitiating Deposit...");
                            Console.Write("\nEnter Account Number: ");
                            int depositAccount = Convert.ToInt32(Console.ReadLine()!);

                            accountManager.Deposit(depositAccount);
                            break;
                        case 4:
                            Console.WriteLine("\nInitiating Transfer...");
                            Console.Write("\nEnter sender's Account Number: ");
                            int senderAcctNum = Convert.ToInt32(Console.ReadLine()!);

                            accountManager.Transfer(senderAcctNum);
                            break;
                        case 5:
                            Console.WriteLine("\nChecking Balance...");
                            Console.Write("\nEnter Account Number: ");
                            int checkAccount = Convert.ToInt32(Console.ReadLine()!);

                            accountManager.CheckBalance(checkAccount);
                            break;
                        case 6:
                            Console.WriteLine("\nClosing Initiated...");
                            System.Console.WriteLine($"\nEnter Account Number: ");
                            int closeAccount = Convert.ToInt32(Console.ReadLine()!);

                            accountManager.CloseAccount(closeAccount);
                            break;
                        case 0:
                            isAppRunning = false;
                            System.Console.WriteLine($"\nExiting program...\nDo have a nice day champ");

                            break;
                        default:
                            System.Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    if (isAppRunning)
                    {
                        HoldScreen();
                    }
                }
            }
        }
        private static void HoldScreen()
        {
            System.Console.WriteLine("\nPress enter key to continue.");
            Console.ReadKey();
        }
    }
}