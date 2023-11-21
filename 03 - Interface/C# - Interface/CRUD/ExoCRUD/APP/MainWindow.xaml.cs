using APP.CLASS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
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

namespace APP
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Ajout de la classe GestionDonnée
			GestionDonnees BDD = new GestionDonnees(CreerListe());

			// Création des données JSON
			//BDD.CreateJSON();

			// Récupération des données du JSON
			List<Produits> produits = new List<Produits>();
			produits = BDD.GetListProd();

			// Ajout des données du JSON dans la DataGrid
			gridData.ItemsSource = produits;
		}

		List<Produits> produits = new List<Produits>();


		/// <summary>
		/// Création de la BDD JSON
		/// </summary>
		/// <param name="path">Chemin du fichier</param>


		private List<Produits> CreerListe()
		{
			List<Produits> liste = new List<Produits>();

			for (int i = 1; i < 15; i++)
			{
				Produits p = new Produits("Produit" + i, i * 2, i * 6, 2023);
				liste.Add(p);
			}

			return liste;
		}


	}



}
