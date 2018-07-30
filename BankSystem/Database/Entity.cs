using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BankSystem.Database
{
    class Entity : Database.IDatabase
    {
        TrainingEntities1 entity = new TrainingEntities1();
        public void AddAccount(string fName, string lName, AccountType accountType, double balance)
        {
            var test = new Account
            {
                FirstName = fName,
                LastName = lName,
                Balance = balance,
                AccountType = Enum.GetName(typeof(AccountType), accountType)
            };
            entity.Accounts.Add(test);
            entity.SaveChanges();
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            List<Account> accounts = new List<Account>();
            accounts = entity.Accounts.ToList();
            foreach(Account account in accounts)
            {
                Console.WriteLine("\nAccount Number={0}\n{1} {2}\n{3} Account\nBalance={4}\n", account.AccountNumber, account.FirstName, account.LastName, account.AccountType, account.Balance);
            }
            Console.ResetColor();
        }

        public string GetAccountType(int ID)
        {
            try
            {
                return entity.Accounts.Find(ID).AccountType;
            }
            catch (Exception exc)
            {
                return "";
            }
        }

        public double GetBalance(int ID)
        {
            try
            {
                return (double)entity.Accounts.Find(ID).Balance;
            }
            catch (Exception exc)
            {
                return 0;
            }
        }

        public void UpdateBalance(int ID, double balance)
        {
            entity.Accounts.Find(ID).Balance=balance;
            entity.SaveChanges();
        }
    }
}
