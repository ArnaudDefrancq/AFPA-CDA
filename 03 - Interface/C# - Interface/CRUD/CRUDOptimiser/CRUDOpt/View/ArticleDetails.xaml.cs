using CRUDOpt.Models.Data;
using CRUDOpt.Models.Services;
using System;
using System.Windows;

namespace CRUDOpt.View
{
	/// <summary>
	/// Logique d'interaction pour ArticleDetails.xaml
	/// </summary>
	public partial class ArticleDetails : Window
	{
		public string Mode { get; set; }

		public ArticleDetails(Article a, MainWindow w, string mode)
		{
			InitializeComponent();
			Mode = mode;
			btnValide.Content = Mode;
			RemplissageChamp(a);
		}

		//************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void RemplissageChamp(Article a)
		{
			if (Mode != "Ajouter")
			{
				txtLibelleArticle.Text = a.LibelleArticle;
				txtIdProduit.Text = a.IdArticle.ToString();
				txtNumeroArticle.Text = a.NumeroArticle.ToString();
				txtQuantite.Text = a.Quantite.ToString();
				txtPrixUnitaire.Text = a.PrixUnitaire.ToString();
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
			Article a = new Article(Int32.Parse((string)txtIdProduit.Text), txtLibelleArticle.Text, Int32.Parse(txtNumeroArticle.Text), Int32.Parse(txtQuantite.Text), Int32.Parse(txtPrixUnitaire.Text));
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

	}
}
