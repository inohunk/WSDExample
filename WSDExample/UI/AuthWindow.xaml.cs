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
			var machineName = System.Environment.UserDomainName;
            dbManager = DatabaseManager.getInstance($"{System.Environment.UserDomainName}", "usersdb");
        }

        public void LoginButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            var res = dbManager.Auth(LoginTextBox.Text.ToString(), PasswordTextBox.Password.ToString());
            if (res != -1)
            {
                new GeneralWindow(res).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect login/pass", "Error");
            }

        }

        public void RegisterButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
			var res = dbManager.Register(LoginTextBox.Text, PasswordTextBox.Password);
			if (res)
			{
				MessageBox.Show("Success!");
			}else
			{
				MessageBox.Show("Register Error");
			}
        }
        
        
    }
}