using CRUDVoitureDb.Controllers;
using CRUDVoitureDb.Helpers;
using CRUDVoitureDb.Models;
using CRUDVoitureDb.Models.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using CRUDVoitureDb.Models.Dtos;


namespace CRUDVoitureDb
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private VoitureController _controller;
		private VoitureDBContext _context;
		public MainWindow()
		{
			InitializeComponent();

			_context = new VoitureDBContext();
			_controller = new VoitureController(_context);

			var v = _controller.GetAllVoitures();

			v.Value.Dump();
		}
	}
}

