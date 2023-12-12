using gestionStock.Controllers;
using gestionStock.Models;
using gestionStock.Models.Dtos;
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
	/// Logique d'interaction pour CategorieFormulaire.xaml
	/// </summary>
	public partial class CategorieFormulaire : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;
		public bool selectItem = false;
		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		private CategorieController _categoryController;
		private TypesProduitController _typesProduitController;
		private GestionStocksDBContext _context;

		public string Mode { get; set; }
		public CategorieListe Cl { get; set; }

		public CategorieFormulaire(CategorieDtoAplatie cDtoA, CategorieListe a, string mode)
		{
			InitializeComponent();
			Cl = a;
			_context = Cl._context;
			_typesProduitController = new TypesProduitController(_context);
			_categoryController = new CategorieController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(cDtoA);
			DisplayListTypeProduit(cDtoA);
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(CategorieDtoAplatie c)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtCategorie.Text = c.LibelleCategorie;
				txtIdCategorie.Text = c.IdCategorie.ToString();
				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtCategorie.IsEnabled = false;
					groupTypeProduit.IsEnabled = false;
				}
			}
			else
			{
				txtIdCategorie.Text = "0";
			}
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		private void DisplayListTypeProduit(CategorieDtoAplatie c)
		{
			List<TypesProduitDtoAplatie> list = _typesProduitController.GetAllTypesProduits().ToList();

			groupTypeProduit.ItemsSource = list;

			if (Mode != "Ajouter")
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].IdTypeProduit == c.IdTypeProduit)
					{
						groupTypeProduit.SelectedIndex = i;
					}
				}

			}
		}

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			TypesProduitDtoAplatie typesProd = groupTypeProduit.SelectedItem as TypesProduitDtoAplatie;

			CategorieDtoIn c = new CategorieDtoIn(txtCategorie.Text, typesProd.IdTypeProduit);

			switch (Mode)
			{
				case "Ajouter": _categoryController.CreateCategorie(c); break;
				case "Modifier": _categoryController.UpdateCategorie(Int32.Parse((string)txtIdCategorie.Text), c); break;
				case "Supprimer": _categoryController.DeleteCategorie(Int32.Parse((string)txtIdCategorie.Text)); break;
			}
			this.Close();
		}

		//*******************************************************//
		// Action de fermer la page
		private void annuler_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		//*******************************************************//
		// Activation du button si les inputs sont correctes
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			String libelleCategorie = txtCategorie.Text;

			// Vérification des données pour Ajout
			if (libelleCategorie.Length > 0 && selectItem)
			{
				validAjoutArticle = true;
				validModifArticle = true;
				BtnActivationDesactivation();
			}
			else
			{
				validAjoutArticle = false;
				validModifArticle = false;
				BtnActivationDesactivation();
			}
		}

		//*******************************************************//
		// Activation du button en fonction
		private void BtnActivationDesactivation()
		{
			if (validAjoutArticle || validModifArticle)
			{
				btnValide.IsEnabled = true;
				Style dynamicStyle = (Style)Application.Current.Resources["btnStyle"];
				btnValide.Style = dynamicStyle;
			}
			else
			{
				btnValide.IsEnabled = false;
				btnValide.Style = null;
			}
		}

		//*******************************************************//
		// Verife que le typeProduit est selectionner
		private void groupCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Recup des données dans les inputs
			String libelleCategorie = txtCategorie.Text;

			if (groupTypeProduit.SelectedItem != null && libelleCategorie.Length > 0)
			{
				validAjoutArticle = true;
				validModifArticle = true;
				selectItem = true;
				BtnActivationDesactivation();
			}
			else
			{
				validAjoutArticle = false;
				validModifArticle = false;
				selectItem = false;
				BtnActivationDesactivation();
			}
		}

		private void txtCategorie_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
