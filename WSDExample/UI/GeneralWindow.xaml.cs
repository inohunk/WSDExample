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
			MessageBox.Show(id.ToString());
			var machineName = System.Environment.UserDomainName;
            
			dbManager = DatabaseManager.getInstance($"{System.Environment.UserDomainName}", "usersdb");

            var user = dbManager.GetUserById(id);
            userNameLabel.Content = user.login;
			
		}
    }
}