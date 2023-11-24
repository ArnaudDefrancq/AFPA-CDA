using APP.CLASS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Security.Cryptography.X509Certificates;
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
		public bool validAjout = false;
		public bool validModif = false;
		public bool validSuppr = false;

		public MainWindow()
		{
			InitializeComponent();

			// Ajout de la class GestionDonnée
			GestionDonnees BDD = new GestionDonnees(CreerListe());

			// Création des données JSON
			BDD.UploaderDonnees();

			// Récupération des données du JSON
			List<Produits> prod = BDD.DownloaderDonnees();

			// Ajout des données du JSON dans la DataGrid
			gridData.ItemsSource = prod;


		}

		//**************Création de la liste**************//

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

		//************************************************//

		//**************Activation des btns***************//
		private void TextChanged(object sender, TextChangedEventArgs e)
		{

			String quantite = txtQuantite.Text;
			String libelleProduit = txtLibelle.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;
			String valueDate = txtDate.Text;

			String quantiteFixe = txtQuantiteFixe.Text;
			String libelleProduitFixe = txtLibelleFixe.Text;
			String valuePrixUnitaireFixe = txtPrixUnitaireFixe.Text;
			String valueDateFixe = txtDateFixe.Text;


			if (quantite != "" && libelleProduit != "" && valuePrixUnitaire != "" && valueDate != "")
			{
				validAjout = true;
				BtnActive();

				if (quantiteFixe != "" && libelleProduitFixe != "" && valuePrixUnitaireFixe != "" && valueDateFixe != "")
				{
					validModif = true;
					BtnActive();

				}
				else
				{
					validModif = false;
					BtnDesactive();
				}
			}
			else
			{
				validAjout = false;
				BtnDesactive();
			}


		}

		private void gridData_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (gridData.SelectedItem != null)
			{
				validSuppr = true;
				BtnActive();
			}
			else
			{
				validSuppr = false;
				BtnDesactive();
			}
		}


		private void BtnActive()
		{
			if (validAjout)
			{
				btnAjouter.IsEnabled = true;
			}
			if (validModif)
			{
				btnModifier.IsEnabled = true;
			}
			if (validSuppr)
			{
				btnSuppr.IsEnabled = true;
			}
		}
		private void BtnDesactive()

		{
			if (!validAjout)
			{
				btnAjouter.IsEnabled = false;
			}
			if (!validModif)
			{
				btnModifier.IsEnabled = false;
			}
			if (!validSuppr)
			{
				btnSuppr.IsEnabled = false;
			}
		}




		//*************************************************//





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
