using APP.Controller;
using APP.Models;
using APP.Models.Data;
using APP.View;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace APP
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool validAjout = true;
		public bool validModif = false;
		public bool validSuppr = false;

		public MainWindow()
		{
			InitializeComponent();
			InitJSON();
			DisplayDataGrid();
		}

		//************************************************//
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
		// Init JSon
		private void InitJSON()
		{
			GestionDonnees BDD = new GestionDonnees(CreerListe());
			BDD.UploaderDonnees();
		}

		//************************************************//
		// Affiche dans le dataGrid
		public void DisplayDataGrid()
		{
			ProduitController controller = new ProduitController();
			List<Produits> produitDtos = controller.GetAllProduits();

			gridData.ItemsSource = produitDtos;
		}

		//************************************************//
		public void BtnActiveModif()
		{
			if (validModif)
			{
				btnModifier.IsEnabled = true;
			}
		}
		public void BtnDesactiveModif()
		{
			if (!validModif)
			{
				btnModifier.IsEnabled = false;
			}
		}

		public void BtnActiveAjout()
		{
			if (validAjout)
			{
				btnAjouter.IsEnabled = true;
			}
		}
		public void BtnDesactiveAjout()
		{
			if (!validAjout)
			{
				btnAjouter.IsEnabled = false;
			}
		}
		//************************************************//
		// Permet d'ajouter un produit en base de donnée JSON
		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			if (validAjout)
			{
				ProduitFormulaire formulaire = new ProduitFormulaire(this);
				this.Opacity = 0.7;
				formulaire.ShowDialog();
				DisplayDataGrid();
				this.Opacity = 1;
				validModif = false;
				validSuppr = false;
				BtnDesactiveModif();
				BtnDesactiveSuppr();

			}

		}

		//************************************************//
		// Permet d'activer le Btn Supprimer
		private void gridData_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (gridData.SelectedItem != null)
			{
				// Instancie un nouvelle obj Dto
				Produits produit = gridData.SelectedItem as Produits;

				// Modification du formulaire et des btn
				validSuppr = true;
				validModif = true;
				validAjout = false;
				BtnActiveModif();
				BtnActiveSuppr();
				BtnDesactiveAjout();
				//txtLibelleFixe.Text = produit.LibelleProduit;
				//txtQuantiteFixe.Text = produit.Quantite.ToString();
				//txtPrixUnitaireFixe.Text = produit.PrixUnitaire.ToString();
				//txtDateFixe.Text = produit.Date.ToString();
			}
		}
		private void BtnActiveSuppr()
		{
			if (validSuppr)
			{
				btnSuppr.IsEnabled = true;
			}
		}
		private void BtnDesactiveSuppr()
		{
			if (!validSuppr)
			{
				btnSuppr.IsEnabled = false;
			}
		}

		//************************************************//
		// Permet de supprimer un produit de la base JSON
		private void btnSuppr_Click(object sender, RoutedEventArgs e)
		{
			if (validSuppr)
			{
				// Initiation d'un nouvelle objet controller
				ProduitController controller = new ProduitController();
				Produits p = gridData.SelectedItem as Produits;
				controller.DeleteProduit(p);

				// Remise a 0 des btn et des inputs
				validSuppr = false;
				validModif = false;
				validAjout = true;
				BtnActiveAjout();
				BtnDesactiveModif();
				BtnDesactiveSuppr();
				DisplayDataGrid();
			}
		}

		//************************************************//
		// Permet de modifier un produit de la base JSON
		private void btnModifier_Click(object sender, RoutedEventArgs e)
		{
			if (validModif)
			{
				ProduitFormulaire formulaire = new ProduitFormulaire(this);
				this.Opacity = 0.7;
				formulaire.ShowDialog();
				this.Opacity = 1;
				DisplayDataGrid();
				validModif = false;
				validSuppr = false;
				validAjout = true;
				BtnActiveAjout();
				BtnDesactiveModif();
				BtnDesactiveSuppr();
			}
		}

	}



}
