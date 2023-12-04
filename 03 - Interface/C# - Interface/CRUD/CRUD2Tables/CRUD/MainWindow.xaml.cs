using CRUD.Helpers;
using CRUD.Models;
using CRUD.Models.Data;
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

namespace CRUD
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();


			InitJSON();
		}


		//************************************************//
		// Permet de créer la list des Articles
		private List<Article> CreerListeArticles()
		{
			List<Article> liste = new List<Article>();

			for (int i = 1; i < 15; i++)
			{
				Article p = new Article("Produit" + i, i * 2, i * 6, "Categorie " + RandomNumber());
				liste.Add(p);
			}

			return liste;
		}

		private int RandomNumber()
		{
			Random rand = new Random();
			int numb = rand.Next(1, 4);
			return numb;
		}

		// Permet de créer la list des categories
		private List<Categorie> CreerListeCategories()
		{
			List<Categorie> liste = new List<Categorie>();

			for (int i = 1; i < 4; i++)
			{
				Categorie p = new Categorie("Categorie " + i);
				liste.Add(p);
			}

			return liste;
		}

		//************************************************//
		// Init des JSON
		private void InitJSON()
		{
			GestionDonnesContext BDD = new GestionDonnesContext(CreerListeArticles(), CreerListeCategories());
			BDD.UploaderDonnees();
		}

		//************************************************//
		// Affichage dans le dataGridArticle

		//public void DisplayDataGridArticle()
		//{
		//	ProduitController controller = new ProduitController();
		//	List<Article> produitDtos = controller.GetAllArticles();

		//	gridData.ItemsSource = produitDtos;
		//}

		//public void DisplayDataGridCategorie()
		//{
		//	ProduitController controller = new ProduitController();
		//	List<Categorie> produitDtos = controller.GetAllCategories();

		//	gridData.ItemsSource = produitDtos;
		//}
	}

}

