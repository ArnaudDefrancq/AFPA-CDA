using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDVoitureDb
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	}
}

// A mettre dans le appsetting.json
// DbName = DbName

//"ConnectionStrings": {
//	"Default": "Server=localhost;User=root;Database=DbName;Port=3306;SslMode=None;"
//	}


// Le scaffold
// scaffold-DbContext -Connection Name=Default -ProviderMySql.EntityFrameworkCore -OutpuDir Models/Data -Context DbNameDBContext -ContextDir Models


