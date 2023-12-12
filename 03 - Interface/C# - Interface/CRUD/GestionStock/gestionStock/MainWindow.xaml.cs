using gestionStock.Models;
using gestionStock.Models.Data;
using gestionStock.View;
using gestionStock.View.Listes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gestionStock
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public GestionStocksDBContext _context;

		public MainWindow()
		{
			InitializeComponent();
			_context = new GestionStocksDBContext();
		}


		//*******************************************************//
		// Action sur les btns Categorie/Produits/TypesProduits
		private void BtnActionClick(object sender, RoutedEventArgs e)
		{
			switch (((Button)sender).Name)
			{
				case "btnArticle":
					ArticleListe articleListe = new ArticleListe();
					this.Opacity = 0.7;
					articleListe.ShowDialog();
					this.Opacity = 1;
					break;
				case "btnCategories":
					CategorieListe categorieListe = new CategorieListe();
					this.Opacity = 0.7;
					categorieListe.ShowDialog();
					this.Opacity = 1;
					break;
				case "btnTypeProduit":
					TypesProduitListe typesProduitListe = new TypesProduitListe();
					this.Opacity = 0.7;
					typesProduitListe.ShowDialog();
					this.Opacity = 1;
					break;
			}

		}
	}
}
