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
			if (machineName == "LAPTOP-9G8HOK7A")
			{
				machineName += "\\RISOLIN";
			}
			dbManager = DatabaseManager.getInstance($"{System.Environment.UserDomainName}", "usersdb");

			
			
		}
    }
}