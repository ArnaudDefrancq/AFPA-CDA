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

			// Ajout de la class GestionDonnée
			GestionDonnees BDD = new GestionDonnees(CreerListe());

			// Création des données JSON
			BDD.UploaderDonnees();

			// Récupération des données du JSON
			List<Produits> prod = BDD.DownloaderDonnees();

			prod.Dump();


			// Ajout des données du JSON dans la DataGrid
			//gridData.ItemsSource = BDD.GetListProd();
		}



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


		//private void btnAjouter_Click(object sender, RoutedEventArgs e)
		//{
		//	GestionDonnees BDD = new GestionDonnees();
		//	int quantite, date, prixUnitaire;
		//	String libelleProd = "";
		//	String valueQuantite = txtQuantite.Text;
		//	String valueDate = txtDate.Text;
		//	String valuePrixUnitaire = txtPrixUnitaire.Text;

		//	try
		//	{
		//		int.TryParse(valueQuantite, out quantite);
		//		int.TryParse(valueDate, out date);
		//		int.TryParse(valuePrixUnitaire, out prixUnitaire);
		//		libelleProd = txtLibelle.Text;

		//		if (libelleProd.Length > 0)
		//		{
		//			Produits p = new Produits(libelleProd, quantite, prixUnitaire, date);

		//			p.Dump();

		//			BDD.AjouterDonneeJSON(p);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		ex.Message.Dump();
		//	}

		//}

	}



}
