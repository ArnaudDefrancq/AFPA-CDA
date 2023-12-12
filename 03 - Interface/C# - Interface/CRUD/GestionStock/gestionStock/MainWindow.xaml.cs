using gestionStock.Models;
using gestionStock.View;
using gestionStock.View.Listes;
using System.Windows;
using System.Windows.Controls;


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
					ArticleListe articleListe = new ArticleListe(this);
					this.Opacity = 0.7;
					articleListe.ShowDialog();
					this.Opacity = 1;
					break;
				case "btnCategories":
					CategorieListe categorieListe = new CategorieListe(this);
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
