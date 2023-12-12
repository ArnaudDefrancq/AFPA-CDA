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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace gestionStock.View.Formulaires
{
	/// <summary>
	/// Logique d'interaction pour ArticleFormulaire.xaml
	/// </summary>
	public partial class ArticleFormulaire : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;
		public bool selectItem = false;
		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		private ArticleController _controllerArticle;
		private CategorieController _categoryController;
		private TypesProduitController _typesProduitController;
		private GestionStocksDBContext _context;

		public string Mode { get; set; }
		public ArticleListe Al { get; set; }

		public ArticleFormulaire(ArticleDtoOutAplatie aDtoA, ArticleListe a, string mode)
		{
			InitializeComponent();
			Al = a;
			_context = Al._context;
			_controllerArticle = new ArticleController(_context);
			_typesProduitController = new TypesProduitController(_context);
			_categoryController = new CategorieController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(aDtoA);
			DisplayListCategorie(aDtoA);
			BtnActivationDesactivation();
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(ArticleDtoOutAplatie a)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtLibelleArticle.Text = a.LibelleArticle;
				txtQuantiteStrockee.Text = a.QuantiteStrockee.ToString();
				txtIdArticle.Text = a.IdArticle.ToString();
				txtTypeProduit.Text = a.LibelleTypeProduit;
				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtLibelleArticle.IsEnabled = false;
					txtQuantiteStrockee.IsEnabled = false;
					groupCategorie.IsEnabled = false;
				}
			}
			else
			{
				txtIdArticle.Text = "0";
			}
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		private void DisplayListCategorie(ArticleDtoOutAplatie a)
		{
			List<CategorieDtoAplatie> list = _categoryController.GetAllCategories().ToList();

			groupCategorie.ItemsSource = list;

			if (Mode != "Ajouter")
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].IdCategorie == a.IdCategorie)
					{
						groupCategorie.SelectedIndex = i;
					}
				}

			}
		}

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			CategorieDtoAplatie categ = groupCategorie.SelectedItem as CategorieDtoAplatie;

			ArticleDtoIn a = new ArticleDtoIn(txtLibelleArticle.Text, Int32.Parse(txtQuantiteStrockee.Text), categ.IdCategorie);

			switch (Mode)
			{
				case "Ajouter": _controllerArticle.CreateArticle(a); break;
				case "Modifier": _controllerArticle.UpdateArticle(Int32.Parse((string)txtIdArticle.Text), a); break;
				case "Supprimer": _controllerArticle.DeleteArticle(Int32.Parse((string)txtIdArticle.Text)); break;
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
			int quantite;
			String libelleArticle = txtLibelleArticle.Text;
			String valueQuantite = txtQuantiteStrockee.Text;
			String libelleType = txtTypeProduit.Text;

			// Vérification des données pour Ajout
			if (int.TryParse(valueQuantite, out quantite) && libelleArticle.Length > 0 && libelleType.Length > 0 && selectItem)
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
		// Permet d'écrire uniquement des chiffres dans les inputs
		private void CheckOnlyNumber(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !intRegex.IsMatch(e.Text);
		}

		//*******************************************************//
		// Verife de la categorie est selectionner
		private void groupCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int quantite;
			String libelleArticle = txtLibelleArticle.Text;
			String valueQuantite = txtQuantiteStrockee.Text;

			DisplayType();

			if (groupCategorie.SelectedItem != null && int.TryParse(valueQuantite, out quantite) && libelleArticle.Length > 0)
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
		// Permet d'afficher le type en fonction de la categorie selectionner
		private void DisplayType()
		{
			List<TypesProduitDtoAplatie> list = _typesProduitController.GetAllTypesProduits().ToList();

			CategorieDtoAplatie categ = groupCategorie.SelectedItem as CategorieDtoAplatie;

			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].IdTypeProduit == categ.IdTypeProduit)
				{
					txtTypeProduit.Text = list[i].LibelleTypeProduit;
				}
			}
		}

		//*******************************************************//
		// Permet de saisir uniquement des letre dans les inputs
		//private void CheckOnlyLettre(object sender, TextCompositionEventArgs e)
		//{
		//	e.Handled = !textRegex.IsMatch(e.Text);
		//}
	}
}
