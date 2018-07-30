using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Database
{
    interface IDatabase
    {
        void AddAccount(string fName, string lName, AccountType accountType, double balance);
        void UpdateBalance(int ID, double balance);
        double GetBalance(int ID);
        string GetAccountType(int ID);
        void Display();
    }
}
