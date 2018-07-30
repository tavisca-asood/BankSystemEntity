using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BankSystem
{
    class Program
    {

        //static void AddAccount(ref List<Account> accounts)
        //{
        //    Console.WriteLine("Enter first name.");
        //    string fname = Console.ReadLine().Trim();
        //    Console.WriteLine("Enter last name.");
        //    string lname = Console.ReadLine().Trim();
        //    Console.WriteLine("Enter account type");
        //    int type;
        //    AccountType accountType;
        //    Console.WriteLine("Enter '1' for Savings account.\nEnter '2' for Current account.\nEnter '3' for DMAT account.\nDefault is Savings.");
        //    int.TryParse(Console.ReadLine(), out type);                                 //Used out
        //    switch (type)
        //    {
        //        case 1:
        //            accountType = AccountType.Savings;
        //            break;
        //        case 2:
        //            accountType = AccountType.Current;
        //            break;
        //        case 3:
        //            accountType = AccountType.DMAT;
        //            break;
        //        default:
        //            accountType = AccountType.Savings;
        //            break;
        //    }
        //    Console.WriteLine("Enter the starting balance.");
        //    double balance;
        //    double.TryParse(Console.ReadLine(), out balance);                           //Used out
        //    while (accountType == AccountType.Savings && balance < 1000)
        //    {
        //        Console.WriteLine("The minimum balance for a Savings account is 1000.");
        //        double.TryParse(Console.ReadLine(), out balance);
        //    }
        //    while (accountType == AccountType.Current && balance < 0)
        //    {
        //        Console.WriteLine("The minimum balance for a Current account is 0.");
        //        double.TryParse(Console.ReadLine(), out balance);
        //    }
        //    while (accountType == AccountType.DMAT && balance < -10000)
        //    {
        //        Console.WriteLine("The minimum balance for a DMAT account is -10000.");
        //        double.TryParse(Console.ReadLine(), out balance);
        //    }
        //    //accounts.Add(new Account(fname, lname, accountType, balance));

        //    //---------------------------ADO Code
        //    ADO ado = new ADO();
        //    ado.AddAccount(fname, lname, accountType, balance);
        //}


        //static Account ChooseAccount(int id, List<Account> accounts)                            //Implemented search by ID in this method
        //{
        //    foreach (Account account in accounts)
        //    {
        //        if (account.ID == id)
        //            return account;
        //    }
        //    return null;
        //}

        //static void PerformOperations(ref List<Account> accounts)
        //{
        //    Console.WriteLine("Enter account ID to choose account to perform operations");
        //    int id;
        //    int.TryParse(Console.ReadLine(), out id);                   //Used out
        //    Account chosenAccount = ChooseAccount(id, accounts);
        //    if (chosenAccount != null)
        //    {
        //        int operation;
        //        Console.WriteLine("Enter 1 to deposit.\nEnter 2 to withdraw.\nEnter 3 to display interest.");
        //        int.TryParse(Console.ReadLine(), out operation);                    //Used out
        //        switch (operation)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the amount to be deposited");
        //                chosenAccount.Deposit(double.Parse(Console.ReadLine()));
        //                break;
        //            case 2:
        //                Console.WriteLine("Enter the amount to be withdrawn");
        //                chosenAccount.Withdraw(double.Parse(Console.ReadLine()));
        //                break;
        //            case 3:
        //                Console.WriteLine(chosenAccount.CalculateInterest());
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        static void Main(string[] args)
        {
            bool flag = true;
            int databaseType;
            int choice;
            int id = 0;
            int operation;
            double amount;
            Account account = new Account();
            Console.WriteLine("Enter 1 for ADO.\nEnter 2 for Entity Framework.");
            int.TryParse(Console.ReadLine(), out databaseType);
            switch (databaseType)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("Enter 1 to to display accounts.\nEnter 2 to add an account.\nEnter 0 to exit.");
                        int.TryParse(Console.ReadLine(), out choice);
                        switch (choice)
                        {
                            case 1:
                                account.DisplayADO();
                                Console.WriteLine("Enter Account number to perform operations on account");
                                int.TryParse(Console.ReadLine(), out id);
                                Console.WriteLine("Enter 1 to deposit.\nEnter 2 to Withdraw.\nEnter 3 to get interest");
                                int.TryParse(Console.ReadLine(), out operation);
                                switch (operation)
                                {
                                    case 1:
                                        Console.WriteLine("Enter amount to deposit");
                                        double.TryParse(Console.ReadLine(), out amount);
                                        account.DepositADO(id, amount);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter amount to withdraw");
                                        double.TryParse(Console.ReadLine(), out amount);
                                        account.WithdrawADO(id, amount);
                                        break;
                                    case 3:
                                        Console.WriteLine(Environment.NewLine + account.CalculateInterestADO(id));
                                        break;
                                    default: break;
                                }
                                break;
                            case 2:
                                account.AddAccountADO();
                                break;
                            case 0:
                                flag = false;
                                break;
                        }
                        if (flag == false)
                            break;
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter 1 to to display accounts.\nEnter 2 to add an account.\nEnter 0 to exit.");
                        int.TryParse(Console.ReadLine(), out choice);
                        switch (choice)
                        {
                            case 1:
                                account.DisplayEntity();
                                Console.WriteLine("Enter Account number to perform operations on account");
                                int.TryParse(Console.ReadLine(), out id);
                                Console.WriteLine("Enter 1 to deposit.\nEnter 2 to Withdraw.\nEnter 3 to get interest");
                                int.TryParse(Console.ReadLine(), out operation);
                                switch (operation)
                                {
                                    case 1:
                                        Console.WriteLine("Enter amount to deposit");
                                        double.TryParse(Console.ReadLine(), out amount);
                                        account.DepositEntity(id, amount);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter amount to withdraw");
                                        double.TryParse(Console.ReadLine(), out amount);
                                        account.WithdrawEntity(id, amount);
                                        break;
                                    case 3:
                                        Console.WriteLine(Environment.NewLine + account.CalculateInterestEntity(id));
                                        break;
                                    default: break;
                                }
                                break;
                            case 2:
                                account.AddAccountEntity();
                                break;
                            case 0:
                                flag = false;
                                break;
                        }
                        if (flag == false)
                            break;
                    }
                    break;
            }
        }
    }
}
