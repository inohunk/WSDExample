using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WSDExample.Classes.Database
{
    class DatabaseManager
    {
        private static DatabaseManager INSTANCE = null;
        public static DatabaseManager getInstance(string _dataSource, string _database)
        {
            if (INSTANCE == null)
            {
                INSTANCE = new DatabaseManager(_dataSource, _database);
            }
            return INSTANCE;
        }

        private string dataSource = "";

        private string database = "";



        private string BASE_DATABASE_URL =

            "Data Source={0};Integrated Security={1};Trusted_Connection=Yes;Initial Catalog = {2}";



        private string connectionUri = "";



        private bool connected = false;



        private SqlConnection connection;



        private DatabaseManager(string _dataSource, string _database)

        {

            dataSource = _dataSource;

            database = _database;

            connectionUri = String.Format(BASE_DATABASE_URL, dataSource, true, database);

            Connect();

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

        public bool Auth(string login, string password)

        {

            var result = false;

            if (connected)

            {



                var command = new SqlCommand(

                    $"SELECT * FROM users WHERE login = '{login}' AND password = '{password}'",

                    connection);

                try

                {

                    var reader = command.ExecuteReader();

                    result = reader.Read();

                    reader.Close();

                }

                catch (Exception e) { }

            }

            return result;

        }

        public bool Register(string login, string password)
        {
            var result = false;
            if (connected)
            {
                var command = new SqlCommand($"INSERT INTO users([login],[password]) VALUES('{login}', '{password}')", connection);
                try
                {

                    var reader = command.ExecuteReader();

                    result = true;

                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Registration error {e.Message}", "Error");

                }
            }
            return result;
        }
        public bool Delete(string login, string password)
        {
            var result = false;
            if (connected)
            {
                var command = new SqlCommand($"DELETE FROM users WHERE [login] = '{login}' and [password] = '{password}'", connection);
                try
                {
                    var reader = command.ExecuteNonQuery();
                    result = reader == 1;

                }
                catch (Exception e)
                {
                    MessageBox.Show($"Delete error {e.Message}", "Error");
                }
            }
            return result;
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
