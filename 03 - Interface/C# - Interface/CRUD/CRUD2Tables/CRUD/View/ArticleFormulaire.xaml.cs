using CRUD.Controllers;
using CRUD.Models.Data;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CRUD.View
{
	/// <summary>
	/// Logique d'interaction pour ArticleFormulaire.xaml
	/// </summary>
	public partial class ArticleFormulaire : Window
	{
		public MainWindow Mw { get; set; }
		public bool validAjoutArticle = false;

		public ArticleFormulaire(MainWindow w)
		{
			InitializeComponent();

			Mw = w;
		}
		//************************************************//
		//Permet d'afficher les categories dans la listBox
		private void DisplayListCategorie()
		{
			CategorieController controller = new CategorieController();
			List<Categorie> categorie = controller.GetAllCategories();
			listCategorie.ItemsSource = categorie;
		}

		//************************************************//
		//Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int quantite, date, prixUnitaire;
			String libelleArticle = "";
			String valueQuantite = txtQuantite.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			// Vérification des données pour Ajout
			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleArticle = txtLibelleArticle.Text).Length > 0)
			{
				validAjoutArticle = true;
				BtnActiveAjout();
			}
			else
			{
				validAjoutArticle = false;
				BtnDesactiveAjout();
			}

			// Vérification des données pour Modif
			//if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && itemSelect && !Mw.validSuppr)
			//{
			//	validModif = true;
			//	BtnActiveModif();
			//}
			//else
			//{
			//	validModif = false;
			//	BtnDesactiveModif();
			//}
		}
		private void BtnActiveAjout()
		{
			if (validAjoutArticle)
			{
				btnAjoutArticle.IsEnabled = true;
			}
		}
		private void BtnDesactiveAjout()
		{
			if (!validAjoutArticle)
			{
				btnAjoutArticle.IsEnabled = false;
			}
		}

	}
}

