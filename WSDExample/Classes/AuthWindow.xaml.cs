using System;
using System.Data.SqlClient;
using System.Windows;
using WSDExample.Classes.Database;
using WSDExample;
using WSDExample.UI;

namespace WSDExample
{
    public partial class AuthWindow : Window
    {
        private DatabaseManager dbManager;
        public AuthWindow()
        {
            InitializeComponent();
            dbManager = new DatabaseManager("DESKTOP-OO2V3AM", "usersdb");
        }

        public void LoginButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            var res = dbManager.Auth(LoginTextBox.Text.ToString(), PasswordTextBox.Password.ToString());
            MessageBox.Show(res.ToString(), "Success");
            if (res)
            {
                new MainWindow().Show();
            }
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            
        }
        
        
    }
}