using CRUDOpt.Models;
using CRUDOpt.Models.Data;
using CRUDOpt.Models.Dtos;
using CRUDOpt.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CRUDOpt.View
{
	public partial class ArticleDetails : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;

		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public ArticleDetails(ArticleDto a, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			Mode = mode;
			btnValide.Content = Mode;
			DisplayCategorie();
			RemplissageChamp(a);
			BtnActivationDesactivation();
		}

		//************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void RemplissageChamp(ArticleDto a)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtLibelleArticle.Text = a.LibelleArticle;
				txtIdProduit.Text = a.IdArticle.ToString();
				txtNumeroArticle.Text = a.NumeroArticle.ToString();
				txtQuantite.Text = a.Quantite.ToString();
				txtPrixUnitaire.Text = a.PrixUnitaire.ToString();

				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtIdProduit.IsEnabled = false;
					txtNumeroArticle.IsEnabled = false;
					txtQuantite.IsEnabled = false;
					txtLibelleArticle.IsEnabled = false;
					txtPrixUnitaire.IsEnabled = false;
				}
			}
			else
			{
				txtIdProduit.Text = "0";
			}
		}

		//************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			Categorie categSelect = groupCategorie.SelectedItem as Categorie;

			Article a = new Article(Int32.Parse((string)txtIdProduit.Text), txtLibelleArticle.Text, Int32.Parse(txtNumeroArticle.Text), Int32.Parse(txtQuantite.Text), Int32.Parse(txtPrixUnitaire.Text), categSelect.IdCategorie);



			switch (Mode)
			{
				case "Ajouter": ArticleService.AddArticle(a); break;
				case "Modifier": ArticleService.UpdateArticle(a); break;
				case "Supprimer": ArticleService.DeleteArticle(a); break;
			}
			this.Close();
		}

		//************************************************//
		// Action de fermer la page
		private void annuler_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		//************************************************//
		// Activation du button si les inputs sont correctes
		private void TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int quantite, prixUnitaire, numeroArticle;
			String libelleArticle = txtLibelleArticle.Text;
			String valueQuantite = txtQuantite.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;
			String valueNumeroArticle = txtNumeroArticle.Text;


			// Vérification des données pour Ajout
			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleArticle = txtLibelleArticle.Text).Length > 0 && int.TryParse(valueNumeroArticle, out numeroArticle))
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

		//************************************************//
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

		//************************************************//
		// Afficher dans les categories disponibles
		private void DisplayCategorie()
		{
			List<Categorie> categ = CategorieService.GetAllCategories();

			groupCategorie.ItemsSource = categ;

			if (Mode != "Ajouter")
			{
				ArticleDto a = Mw.gridDataArticle.SelectedItem as ArticleDto;

				for (int i = 0; i < categ.Count; i++)
				{
					if (categ[i].LibelleCategorie == a.LibelleCategorie)
					{
						groupCategorie.SelectedIndex = i;

					}
				}
			}
		}
	}
}
