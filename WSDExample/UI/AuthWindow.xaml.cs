using System;
using System.Data.SqlClient;
using System.Windows;
using WSDExample.Classes.Database;
using WSDExample.UI;

namespace WSDExample
{
    public partial class AuthWindow : Window
    {
        private DatabaseManager dbManager;
        public AuthWindow()
        {
            InitializeComponent();
            dbManager = DatabaseManager.getInstance("DESKTOP-OO2V3AM", "usersdb");
        }

        public void LoginButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            var res = dbManager.Auth(LoginTextBox.Text.ToString(), PasswordTextBox.Password.ToString());
            if (res)
            {
                new GeneralWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect login/pass", "Error");
            }

        }

        public void RegisterButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            
        }
        
        
    }
}