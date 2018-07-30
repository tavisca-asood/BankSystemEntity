using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    enum AccountType                    //Using enum
    {
        Savings = 0,
        Current,
        DMAT
    }
    class Account                          //Creating a class
    {
        static ADO ado = new ADO();
        static Database.Entity entity =new Database.Entity();
        public void DepositADO(int id, double amount)
        {
            double balance = ado.GetBalance(id);
            ado.UpdateBalance(id, balance + amount);
        }

        public void DepositEntity(int id, double amount)
        {
            double balance = entity.GetBalance(id);
            entity.UpdateBalance(id, balance + amount);
        }

        public void AddAccountADO()
        {
            Console.WriteLine("Enter first name.");
            string fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter last name.");
            string lname = Console.ReadLine().Trim();
            Console.WriteLine("Enter account type");
            int type;
            AccountType accountType;
            Console.WriteLine("Enter '1' for Savings account.\nEnter '2' for Current account.\nEnter '3' for DMAT account.\nDefault is Savings.");
            int.TryParse(Console.ReadLine(), out type);                                 //Used out
            switch (type)
            {
                case 1:
                    accountType = AccountType.Savings;
                    break;
                case 2:
                    accountType = AccountType.Current;
                    break;
                case 3:
                    accountType = AccountType.DMAT;
                    break;
                default:
                    accountType = AccountType.Savings;
                    break;
            }
            Console.WriteLine("Enter the starting balance.");
            double balance;
            double.TryParse(Console.ReadLine(), out balance);                           //Used out
            while (accountType == AccountType.Savings && balance < 1000)
            {
                Console.WriteLine("The minimum balance for a Savings account is 1000.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            while (accountType == AccountType.Current && balance < 0)
            {
                Console.WriteLine("The minimum balance for a Current account is 0.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            while (accountType == AccountType.DMAT && balance < -10000)
            {
                Console.WriteLine("The minimum balance for a DMAT account is -10000.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            ado.AddAccount(fname, lname, accountType, balance);
        }

        public void WithdrawADO(int id, double amount)
        {
            string type = ado.GetAccountType(id);
            if (type == "")
                return;
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), type);
            double balance = ado.GetBalance(id);
            if (accountType == AccountType.Savings)
            {
                if (balance - amount < 1000)
                {
                    Console.WriteLine("\nInsufficient Balance for withdrawal.\n");
                    return;
                }
                ado.UpdateBalance(id, balance - amount);
            }
            else if (accountType == AccountType.Current)
            {
                if (balance - amount < 0)
                {
                    Console.WriteLine("\nInsufficient Balance for withdrawal.\n");
                    return;
                }
                ado.UpdateBalance(id, balance - amount);
            }
            else if (accountType == AccountType.DMAT)
            {
                if (balance - amount < -10000)
                {
                    Console.WriteLine("\nInsufficient Balance for withdrawal.\n");
                    return;
                }
                ado.UpdateBalance(id, balance - amount);
            }
        }

        public double CalculateInterestADO(int id)
        {
            string type = ado.GetAccountType(id);
            if (type == "")
                return 0;
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), type);
            double balance = ado.GetBalance(id);
            if (accountType == AccountType.Savings)
            {
                return 4 * balance / 100;
            }
            if (accountType == AccountType.Current)
            {
                return 1 * balance / 100;
            }
            return 0;
        }

        public void DisplayADO()
        {
            ado.Display();
        }

        public void AddAccountEntity()
        {
            Console.WriteLine("Enter first name.");
            string fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter last name.");
            string lname = Console.ReadLine().Trim();
            Console.WriteLine("Enter account type");
            int type;
            AccountType accountType;
            Console.WriteLine("Enter '1' for Savings account.\nEnter '2' for Current account.\nEnter '3' for DMAT account.\nDefault is Savings.");
            int.TryParse(Console.ReadLine(), out type);                                 //Used out
            switch (type)
            {
                case 1:
                    accountType = AccountType.Savings;
                    break;
                case 2:
                    accountType = AccountType.Current;
                    break;
                case 3:
                    accountType = AccountType.DMAT;
                    break;
                default:
                    accountType = AccountType.Savings;
                    break;
            }
            Console.WriteLine("Enter the starting balance.");
            double balance;
            double.TryParse(Console.ReadLine(), out balance);                           //Used out
            while (accountType == AccountType.Savings && balance < 1000)
            {
                Console.WriteLine("The minimum balance for a Savings account is 1000.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            while (accountType == AccountType.Current && balance < 0)
            {
                Console.WriteLine("The minimum balance for a Current account is 0.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            while (accountType == AccountType.DMAT && balance < -10000)
            {
                Console.WriteLine("The minimum balance for a DMAT account is -10000.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            entity.AddAccount(fname, lname, accountType, balance);
        }
        public void WithdrawEntity(int id, double amount)
        {
            string type = entity.GetAccountType(id);
            if (type == "")
                return;
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), type);
            double balance = entity.GetBalance(id);
            if (accountType == AccountType.Savings)
            {
                if (balance - amount < 1000)
                {
                    Console.WriteLine("\nInsufficient Balance for withdrawal.\n");
                    return;
                }
                entity.UpdateBalance(id, balance - amount);
            }
            else if (accountType == AccountType.Current)
            {
                if (balance - amount < 0)
                {
                    Console.WriteLine("\nInsufficient Balance for withdrawal.\n");
                    return;
                }
                entity.UpdateBalance(id, balance - amount);
            }
            else if (accountType == AccountType.DMAT)
            {
                if (balance - amount < -10000)
                {
                    Console.WriteLine("\nInsufficient Balance for withdrawal.\n");
                    return;
                }
                entity.UpdateBalance(id, balance - amount);
            }
        }

        public double CalculateInterestEntity(int id)
        {
            string type = entity.GetAccountType(id);
            if (type == "")
                return 0;
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), type);
            double balance = entity.GetBalance(id);
            if (accountType == AccountType.Savings)
            {
                return 4 * balance / 100;
            }
            if (accountType == AccountType.Current)
            {
                return 1 * balance / 100;
            }
            return 0;
        }

        public void DisplayEntity()
        {
            entity.Display();
        }
    }
}
