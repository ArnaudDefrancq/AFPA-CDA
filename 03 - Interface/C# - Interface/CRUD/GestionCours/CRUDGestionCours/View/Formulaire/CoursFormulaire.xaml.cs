using CRUDGestionCours.Controllers;
using CRUDGestionCours.Models;
using CRUDGestionCours.Models.Dtos;
using CRUDGestionCours.View.Liste;
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

namespace CRUDGestionCours.View.Formulaire
{
	/// <summary>
	/// Logique d'interaction pour CoursFormulaire.xaml
	/// </summary>
	public partial class CoursFormulaire : Window
	{
		private InscriptionController _inscriptionController;
		private CoursController _coursController;
		private EtudiantController _etudiantController;
		private GestionCoursDBContext _context;

		public bool validInput = false;

		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		public string Mode { get; set; }
		public EtudiantListe El { get; set; }

		public CoursFormulaire(CoursDtoOutAplatie ca, CoursListe w, string mode)
		{
			InitializeComponent();
		}
	}
}
