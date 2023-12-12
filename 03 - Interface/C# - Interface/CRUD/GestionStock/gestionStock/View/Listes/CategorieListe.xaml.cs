using gestionStock.Controllers;
using gestionStock.Helpers;
using gestionStock.Models;
using gestionStock.Models.Dtos;
using gestionStock.View.Formulaires;
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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace gestionStock.View
{
	/// <summary>
	/// Logique d'interaction pour CategorieListe.xaml
	/// </summary>
	public partial class CategorieListe : Window
	{
		private CategorieController _controller;
		public GestionStocksDBContext _context;
		public bool validModif = false;
		public bool validSuppr = false;
		public MainWindow Mw { get; set; }

		public CategorieListe(MainWindow w)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_controller = new CategorieController(_context);
			DisplayListCategorie();
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		private void DisplayListCategorie()
		{
			var list = _controller.GetAllCategories();
			groupCategorie.ItemsSource = list;
		}

		//*******************************************************//
		// Verife de la categorie est selectionner
		private void groupCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CategorieDtoAplatie categ = groupCategorie.SelectedItem as CategorieDtoAplatie;

			txtTypeProduit.Text = categ.LibelleTypeProduit;

			gridDataArticle.ItemsSource = categ.ListArticles;

			validSuppr = true;
			validModif = true;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();

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
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionAnnulClick(object sender, EventArgs e)
		{
			this.Close();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionClick(object sender, EventArgs e)
		{
			CategorieDtoAplatie item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new CategorieDtoAplatie();
			}
			else
			{
				item = (CategorieDtoAplatie)groupCategorie.SelectedItem;
			}

			CategorieFormulaire af = new CategorieFormulaire(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			af.ShowDialog();
			this.Opacity = 1;
			DisplayListCategorie();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}
	}
}
