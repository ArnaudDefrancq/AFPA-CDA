using CRUD.Controllers;
using CRUD.Models;
using CRUD.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD.View
{
	/// <summary>
	/// Logique d'interaction pour PrescriptionFormulaire.xaml
	/// </summary>
	public partial class PrescriptionFormulaire : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;
		public bool selectItem = false;
		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		private PrescriptionController _prescriptionController;
		private MedecinController _medecinController;
		private MedicamentController _medicamentController;
		private medecinedbDBContext _context;


		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public PrescriptionFormulaire(PrescriptionDtoOutAplatie p, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_prescriptionController = new PrescriptionController(_context);
			_medecinController = new MedecinController(_context);
			_medicamentController = new MedicamentController(_context);
			Mode = mode;
			//btnValide.Content = Mode;
		}
	}
}
