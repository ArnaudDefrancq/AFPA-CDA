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
		/// <summary>
		/// Permet d'activer les btn modifier et ajouter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			int quantite, date, prixUnitaire;
			String libelleProd = "";
			String valueQuantite = txtQuantite.Text;
			String valueDate = txtDate.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			String libelleFixe = txtLibelleFixe.Text;
			String quantiteFixe = txtQuantiteFixe.Text;
			String dateFixe = txtDateFixe.Text;
			String prixUnitaireFixe = txtPrixUnitaireFixe.Text;


			//libelleFixe.Dump();
			//quantiteFixe.Dump();
			//dateFixe.Dump();
			//prixUnitaireFixe.Dump();

			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0)
			{
				validAjout = true;
				BtnActiveAjout();


			}
			else
			{
				validAjout = false;
				BtnDesactiveAjout();
			}


		}

		/// <summary>
		/// out dans les inputs des valeurs de la ligne du datagrid et active le btn suppr
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridData_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Produits p;
			if (gridData.SelectedItem != null)
			{
				validSuppr = true;
				BtnActive();
				p = gridData.SelectedItem as Produits;

				txtLibelleFixe.Text = p.LibelleProduit;
				txtQuantiteFixe.Text = p.Quantite.ToString();
				txtPrixUnitaireFixe.Text = p.PrixUnitaire.ToString();
				txtDateFixe.Text = p.Date.ToString();


			}
			else
			{
				validSuppr = false;
				BtnDesactive();
			}

		}

		private void BtnActive()
		{

			if (validModif)
			{
				btnModifier.IsEnabled = true;
			}
			if (validSuppr)
			{
				btnSuppr.IsEnabled = true;
			}
		}

		private void BtnActiveAjout()
		{
			if (validAjout)
			{
				btnAjouter.IsEnabled = true;
			}
		}
		private void BtnDesactiveAjout()
		{
			if (!validAjout)
			{
				btnAjouter.IsEnabled = false;
			}
		}
		private void BtnDesactive()

		{

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
		//***************Actions des btns******************//

		/// <summary>
		/// Permet d'ajouter dun nouvelle item dans le JSON et d'actualiser le dataGrid au click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			int quantite, date, prixUnitaire;
			String libelleProd = "";
			String valueQuantite = txtQuantite.Text;
			String valueDate = txtDate.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			try
			{
				if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0)
				{
					GestionDonnees BDD = new GestionDonnees();

					Produits p = new Produits(libelleProd, quantite, prixUnitaire, date);

					BDD.AjouterDonneeJSON(p);

					gridData.ItemsSource = BDD.DownloaderDonnees();

				}
			}
			catch (Exception ex)
			{
				ex.Message.Dump();
			}

		}

		/// <summary>
		/// Permet de modifier un nouvelle item dans le JSON et d'actualiser le dataGrid au click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModifier_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// Permet de supprimer un element et d'actualiser la liste au click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSuppr_Click(object sender, RoutedEventArgs e)
		{
			GestionDonnees BDD = new GestionDonnees();
			if (validSuppr)
			{
				Produits p = gridData.SelectedItem as Produits;

				//p.Dump();

				BDD.SupprimerDonneeJson(p);

				//BDD.DownloaderDonnees();
			}
		}
	}



}
