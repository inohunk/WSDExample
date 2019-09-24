using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows;

namespace WSDExample.Classes.Database
{
    public class DatabaseManager
    {
        private string dataSource = "";
        private string database = "";
        private string table = "";
        private string login = "";
        private string password = "";
        
        private string BASE_DATABASE_URL =
            "Data Source={0};Initial Catalog={1};Integrated Security={2};Trusted_Connection=Yes;DataBase={3};";

        private string USER_AUTH =
            "User ID={0};Password={1};";

        private string connectionUri = "";

        private bool connected = false;
        
        public DatabaseManager(string _dataSource, string _database, string _table)
        {
            dataSource = _dataSource;
            database = _database;
            connectionUri = String.Format(BASE_DATABASE_URL, dataSource, table, true, database);
            Connect();
        }
        
        public DatabaseManager(string _dataSource, string _database, string _table, string _login, string _password)
        {
            dataSource = _dataSource;
            database = _database;
            connectionUri = String.Format(BASE_DATABASE_URL, dataSource, table, true, database);
            connectionUri += ";" + String.Format(USER_AUTH, _login, _password);
            Connect();
        }


        private void Connect()
        {
            SqlConnection connection = new SqlConnection(connectionUri);
            try
            {
                connection.Open();
                connected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection error", "Error");
            }
        }
    }
}