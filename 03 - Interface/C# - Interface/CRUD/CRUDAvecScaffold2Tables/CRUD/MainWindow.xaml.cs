using CRUD.Controllers;
using CRUD.Models;
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

namespace CRUD
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private MarqueController _controller;
		public voitureDBContext _context;

		public MainWindow()
		{
			InitializeComponent();
			_context = new voitureDBContext();
			_controller = new MarqueController(_context);

			var a = _controller.GetAllMarques();
		}
	}
}




