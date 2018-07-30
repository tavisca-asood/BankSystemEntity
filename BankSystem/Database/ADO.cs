using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BankSystem
{
    class ADO:Database.IDatabase
    {
        string connectinString;
        SqlConnection connection = new SqlConnection();
        public ADO()
        {
            connectinString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            connection.ConnectionString = connectinString;
            try
            {
                Console.WriteLine("Attempting to create table");
                connection.Open();
                string query = "create table Accounts(AccountNumber int identity(1,1) primary key, Firstname varchar(20),Lastname varchar(20),Accounttype varchar(20), Balance float);";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Table Created");
            }
            catch (Exception exc)
            {
                connection.Close();
                Console.WriteLine("Accounts table already available");
            }
        }
        public void AddAccount(string fName, string lName, AccountType accountType, double balance)
        {
            connection.Open();
            string query = "insert into Accounts values('" + fName + "','" + lName + "','" + Enum.GetName(typeof(AccountType), accountType) + "'," + balance + ")";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateBalance(int ID, double balance)
        {
            connection.Open();
            string query = "update Accounts set Balance = " + balance + "where AccountNumber =" + ID;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public double GetBalance(int ID)
        {
            connection.Open();
            double balance = -1;
            string query = "select * from Accounts where AccountNumber =" + ID;
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    balance = double.Parse(Convert.ToString(reader[4]));
                }
            }
            connection.Close();
            return balance;
        }

        public string GetAccountType(int ID)
        {
            connection.Open();
            string type = "";
            string query = "select * from Accounts where AccountNumber =" + ID;
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    type = Convert.ToString(reader[3]);
                }
            }
            connection.Close();
            return type;
        }

        public void Display()
        {
            connection.Open();
            string query = "select * from Accounts";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (reader.HasRows)
            {
                Console.Clear();
                while (reader.Read())
                {
                    int id = int.Parse(Convert.ToString(reader[0]));
                    string fname = Convert.ToString(reader[1]);
                    string lname = Convert.ToString(reader[2]);
                    string accountType = Convert.ToString(reader[3]);
                    double balance = double.Parse(Convert.ToString(reader[4]));
                    Console.WriteLine("\nAccount Number={0}\n{1} {2}\n{3} Account\nBalance={4}\n", id, fname, lname, accountType, balance);
                }
            }
            Console.ResetColor();
            connection.Close();
        }
    }
}
