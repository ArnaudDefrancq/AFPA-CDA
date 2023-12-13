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

namespace gestionStock.View.Listes
{
	/// <summary>
	/// Logique d'interaction pour TypesProduitListe.xaml
	/// </summary>
	public partial class TypesProduitListe : Window
	{
		private TypesProduitController _controller;
		public GestionStocksDBContext _context;
		public bool validModif = false;
		public bool validSuppr = false;
		public MainWindow Mw { get; set; }

		public TypesProduitListe(MainWindow w)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_controller = new TypesProduitController(_context);
			DisplayListTypeProduit();
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayListTypeProduit()
		{
			List<TypesProduitDtoAplatie> list = _controller.GetAllTypesProduits().ToList();
			groupTypeProduit.ItemsSource = list;
			list.Dump();
		}

		//*******************************************************//
		// Verife de la categorie est selectionner
		private void SelectTypeProduit(object sender, SelectionChangedEventArgs e)
		{
			TypesProduitDtoAplatie tpa = groupTypeProduit.SelectedItem as TypesProduitDtoAplatie;

			//if (tpa.AllCategories != null)
			//{
			//	listCategorie.ItemsSource = tpa.AllCategories;

			//	validSuppr = true;
			//	validModif = true;
			//	BtnActiveDesactiveModif();
			//	BtnActiveDesactiveSuppr();
			//}
		}

		//*******************************************************//
		// Permet de selectionner une categorie
		private void listCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		//*******************************************************//
		// Permet d'afficher dans le dataGrid les articles
		private void DisplayDataGridArticles()
		{

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
			TypesProduitDtoAplatie item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new TypesProduitDtoAplatie();
			}
			else
			{
				item = (TypesProduitDtoAplatie)groupTypeProduit.SelectedItem;
			}

			TypesProduitFormulaire af = new TypesProduitFormulaire(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			af.ShowDialog();
			this.Opacity = 1;

			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}
	}
}

