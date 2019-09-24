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
        
        private string BASE_DATABASE_URL =
            "Data Source={0};Integrated Security={1};Trusted_Connection=Yes;Initial Catalog = {2}";
        
        private string connectionUri = "";

        private bool connected = false;

        private SqlConnection connection;
        
        public DatabaseManager(string _dataSource, string _database)
        {
            dataSource = _dataSource;
            database = _database;
            connectionUri = String.Format(BASE_DATABASE_URL, dataSource, true, database);
            Connect();
        }
        
        public bool Auth(string login, string password)
        {
            var result = false;
            if (connected)
            {

                var command = new SqlCommand(
                    $"SELECT * FROM Users WHERE login = '{login}' AND password = '{password}'",
                    connection);
                try
                {
                    var reader = command.ExecuteReader();
                    result = reader.Read();
                    reader.Close();
                }
                catch (Exception e) {}
            }
            return result;
        }

        private void Connect()
        { 
            connection = new SqlConnection(connectionUri);
            try
            {
                connection.Open();
                connected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Connection error {e.Message}", "Error");
            }
        }

        ~DatabaseManager()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}