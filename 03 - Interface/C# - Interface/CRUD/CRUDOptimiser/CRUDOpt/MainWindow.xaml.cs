using CRUDOpt.Models.Data;
using CRUDOpt.Models.Services;
using CRUDOpt.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CRUDOpt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool validModif = false;
		public bool validSuppr = false;

		public MainWindow()
		{
			InitializeComponent();

			DisplayDataGridArticle();
		}

		//************************************************//
		// Affichage des articles dans le dataGrid
		public void DisplayDataGridArticle()
		{
			List<Article> art = ArticleService.GetAllArticles();

			gridDataArticle.ItemsSource = art;
		}

		//************************************************//
		// Permet d'activer les btn suppr et modifier au click sur un element de la dataGrid
		private void gridDataArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			validSuppr = true;
			validModif = true;

			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//************************************************//
		// Permet d'activer les btn suppr et modifier
		private void BtnActiveDesactiveSuppr()
		{
			if (validSuppr)
			{
				btnSuppr.IsEnabled = true;
			}
			else
			{
				btnSuppr.IsEnabled = false;
			}
		}

		public void BtnActiveDesactiveModif()
		{
			if (validModif)
			{
				btnModifier.IsEnabled = true;
			}
			else
			{
				btnModifier.IsEnabled = false;
			}
		}

		//************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionClick(object sender, EventArgs e)
		{
			Article item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new Article();
			}
			else
			{
				item = (Article)gridDataArticle.SelectedItem;
			}

			ArticleDetails w = new ArticleDetails(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			DisplayDataGridArticle();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void Row_DoubleClick(object sender, EventArgs e)
		{
			Article item = gridDataArticle.SelectedItem as Article;

			ArticleDetails w = new ArticleDetails(item, this, "Modifier");
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			DisplayDataGridArticle();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}
	}

}
