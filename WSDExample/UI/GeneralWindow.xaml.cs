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

        }
    }
}