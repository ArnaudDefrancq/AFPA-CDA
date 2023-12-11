using CRUD.Controllers;
using CRUD.Helpers;
using CRUD.Models;
using CRUD.Models.Data;
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
	/// Logique d'interaction pour AppartementFormulaire.xaml
	/// </summary>
	public partial class AppartementFormulaire : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;
		public bool selectItem = false;
		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		private AppartementController _controllerAppartement;
		private CategorieController _categoryController;
		private ImmobilierDBContext _context;


		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public AppartementFormulaire(AppartementDtoApplatieAvecCategorie v, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_controllerAppartement = new AppartementController(_context);
			_categoryController = new CategorieController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(v);
			DisplayListCategorie(v);
			BtnActivationDesactivation();
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(AppartementDtoApplatieAvecCategorie v)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtAdresse.Text = v.Adresse;
				txtNbAppartement.Text = v.NumeroAppartement.ToString();
				txtPrix.Text = v.Prix.ToString();
				txtVille.Text = v.Ville;
				txtIdAppartement.Text = v.IdAppartement.ToString();

				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtAdresse.IsEnabled = false;
					txtIdAppartement.IsEnabled = false;
					txtNbAppartement.IsEnabled = false;
					txtPrix.IsEnabled = false;
					txtVille.IsEnabled = false;
					groupCategorie.IsEnabled = false;
				}
			}
			else
			{
				txtIdAppartement.Text = "0";
			}
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		private void DisplayListCategorie(AppartementDtoApplatieAvecCategorie v)
		{
			List<CategorieDtoOutSansAppartement> list = _categoryController.GetAllCategories().ToList();

			groupCategorie.ItemsSource = list;

			if (Mode != "Ajouter")
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].IdCategorie == v.Type)
					{
						groupCategorie.SelectedIndex = i;
					}
				}

			}
		}

		//SelectionChanged="groupCategorie_SelectionChanged" 

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			CategorieDtoOutSansAppartement categ = groupCategorie.SelectedItem as CategorieDtoOutSansAppartement;

			AppartementDtoIn v = new AppartementDtoIn(Int32.Parse((string)txtIdAppartement.Text), Int32.Parse(txtPrix.Text), txtAdresse.Text, Int32.Parse(txtNbAppartement.Text), txtVille.Text, categ.IdCategorie);

			switch (Mode)
			{
				case "Ajouter": _controllerAppartement.CreateAppartement(v); break;
				case "Modifier": _controllerAppartement.UpdateAppartement(Int32.Parse((string)txtIdAppartement.Text), v); break;
				case "Supprimer": _controllerAppartement.DeleteAppartement(Int32.Parse((string)txtIdAppartement.Text)); break;
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
			int prix, nbAppartement;
			String adresse = txtAdresse.Text;
			String ville = txtVille.Text;
			String valuePrix = txtPrix.Text;
			String valueNbApaprtement = txtNbAppartement.Text;

			// Vérification des données pour Ajout
			if (int.TryParse(valuePrix, out prix) && adresse.Length > 0 && ville.Length > 0 && int.TryParse(valueNbApaprtement, out nbAppartement) && selectItem)
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
				Style dynamicStyle = (Style)Application.Current.Resources["btnTemp"];
				btnValide.Style = dynamicStyle;
			}
			else
			{
				btnValide.IsEnabled = false;
				btnValide.Style = null;
			}
		}

		//*******************************************************//
		// Permet d'écrire uniquement des chiffres dans les inputs
		private void PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !intRegex.IsMatch(e.Text);
		}

		//*******************************************************//
		// Verife de la categorie est selectionner
		private void groupCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int prix, nbAppartement;
			String adresse = txtAdresse.Text;
			String ville = txtVille.Text;
			String valuePrix = txtPrix.Text;
			String valueNbApaprtement = txtNbAppartement.Text;

			if (groupCategorie.SelectedItem != null && int.TryParse(valuePrix, out prix) && adresse.Length > 0 && ville.Length > 0 && int.TryParse(valueNbApaprtement, out nbAppartement))
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


		//*******************************************************//
		// Permet de saisir uniquement des letre dans les inputs
		private void txtVille_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !textRegex.IsMatch(e.Text);
		}
	}
}
