using gestionStock.Controllers;
using gestionStock.Models;
using gestionStock.Models.Dtos;
using gestionStock.View.Formulaires;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gestionStock.View
{
	/// <summary>
	/// Logique d'interaction pour ArticleListe.xaml
	/// </summary>
	public partial class ArticleListe : Window
	{
		private ArticleController _controller;
		public GestionStocksDBContext _context;
		public bool validModif = false;
		public bool validSuppr = false;

		public ArticleListe()
		{
			InitializeComponent();
			_context = new GestionStocksDBContext();
			_controller = new ArticleController(_context);
			DisplayDataGrid();

		}

		//*******************************************************//
		//Affiche dans le dataGRid
		public void DisplayDataGrid()
		{
			gridDataArticle.ItemsSource = _controller.GetAllArticles();
		}

		//*******************************************************//
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
				Style dynamicStyle = (Style)Application.Current.Resources["btnStyle"];
				btnModifier.Style = dynamicStyle;
			}
			else
			{
				btnModifier.IsEnabled = false;
				btnModifier.Style = null;
			}
		}

		//*******************************************************//
		// Permet d'activer les btn suppr et modifier au click sur un element de la dataGrid
		private void gridDataArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			validSuppr = true;
			validModif = true;

			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionClick(object sender, EventArgs e)
		{
			ArticleDtoOutAplatie item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new ArticleDtoOutAplatie();
			}
			else
			{
				item = (ArticleDtoOutAplatie)gridDataArticle.SelectedItem;
			}

			ArticleFormulaire af = new ArticleFormulaire(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			af.ShowDialog();
			this.Opacity = 1;

			DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}
		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer

		private void btnActionAnnulClick(object sender, EventArgs e)
		{
			this.Close();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void Row_DoubleClick(object sender, EventArgs e)
		{
			ArticleDtoOutAplatie item = gridDataArticle.SelectedItem as ArticleDtoOutAplatie;

			ArticleFormulaire w = new ArticleFormulaire(item, this, "Modifier");
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

	}
}
