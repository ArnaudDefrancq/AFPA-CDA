using gestionStock.Controllers;
using gestionStock.Models;
using gestionStock.Models.Dtos;
using gestionStock.View.Listes;
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

namespace gestionStock.View.Formulaires
{
	/// <summary>
	/// Logique d'interaction pour TypesProduitFormulaire.xaml
	/// </summary>
	public partial class TypesProduitFormulaire : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;
		public bool selectItem = false;
		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		private TypesProduitController _typesProduitController;
		private GestionStocksDBContext _context;

		public string Mode { get; set; }
		public TypesProduitListe TPl { get; set; }

		public TypesProduitFormulaire(TypesProduitDtoAplatie tDtoA, TypesProduitListe a, string mode)
		{
			InitializeComponent();
		}
	}
}
