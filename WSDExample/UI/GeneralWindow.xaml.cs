using System.Windows;
using WSDExample.Classes.Database;

namespace WSDExample.UI
{
    public partial class GeneralWindow : Window
    {
		private DatabaseManager dbManager;

		public GeneralWindow(int id)
        {
            InitializeComponent();
			var machineName = System.Environment.UserDomainName;
            
			dbManager = DatabaseManager.getInstance($"{System.Environment.UserDomainName}", "usersdb");

            var user = dbManager.GetUserById(id);
            userNameLabel.Content = $"Welcome, {user.login}";
			
		}

		private void Logout_Click(object sender, RoutedEventArgs e)
		{
			var window = new AuthWindow();
			window.Show();
			this.Close();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}