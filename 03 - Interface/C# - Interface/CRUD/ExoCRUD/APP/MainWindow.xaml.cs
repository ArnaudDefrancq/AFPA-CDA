using APP.Controller;
using APP.Helpers;
using APP.Models;
using APP.Models.Data;
using APP.Models.Dtos;
using APP.View;
using System;
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
		public bool validAjout = false;
		public bool validModif = false;
		public bool validSuppr = false;
		public bool selectItem = false;

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
		// Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			int quantite, date, prixUnitaire;
			String libelleProd = "";
			String valueQuantite = txtQuantite.Text;
			String valueDate = txtDate.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && !selectItem)
			{
				validAjout = true;
				BtnActiveAjout();
			}
			else
			{
				validAjout = false;
				BtnDesactiveAjout();
			}

			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && selectItem)
			{
				validModif = true;
				BtnActiveModif();
			}
			else
			{
				validModif = false;
				BtnDesactiveModif();
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

		private void BtnActiveModif()
		{
			if (validModif)
			{
				btnModifier.IsEnabled = true;
			}
		}
		private void BtnDesactiveModif()
		{
			if (!validModif)
			{
				btnModifier.IsEnabled = false;
			}
		}

		//************************************************//
		// Permet d'ajouter un produit en base de donnée JSON
		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			if (validAjout)
			{
				ProduitController controller = new ProduitController();

				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtDate.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);
				Produits p = new Produits(libelleProd, valueQuantite, valuePrixUnitaire, valueDate);
				controller.CreateProduit(p);
				DisplayDataGrid();
				txtLibelle.Text = "";
				txtPrixUnitaire.Text = "";
				txtDate.Text = "";
				txtQuantite.Text = "";
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
				selectItem = true;
				BtnActiveSuppr();
				txtLibelleFixe.Text = produit.LibelleProduit;
				txtQuantiteFixe.Text = produit.Quantite.ToString();
				txtPrixUnitaireFixe.Text = produit.PrixUnitaire.ToString();
				txtDateFixe.Text = produit.Date.ToString();
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
				selectItem = false;
				BtnDesactiveSuppr();
				DisplayDataGrid();
				txtLibelleFixe.Text = "";
				txtPrixUnitaireFixe.Text = "";
				txtDateFixe.Text = "";
				txtQuantiteFixe.Text = "";
			}
		}

		//************************************************//
		// Permet de modifier un produit de la base JSON
		private void btnModifier_Click(object sender, RoutedEventArgs e)
		{
			if (validModif)
			{
				//ProduitFormulaire formulaire = new ProduitFormulaire();
				//this.Opacity = 0.7;
				//formulaire.ShowDialog();
				ProduitController controller = new ProduitController();

				//Créer un nouvelle objet avec modif
				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtDate.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);

				Produits produitSansModif = gridData.SelectedItem as Produits;

				Produits produitModif = new Produits(produitSansModif.IdProduit, libelleProd, valueQuantite, valuePrixUnitaire, valueDate);

				controller.UpdateProduit(produitModif);

				// Actualisation de l'affichage
				DisplayDataGrid();

				// on désactive les btn et remise a 0 des formulaires
				validSuppr = false;
				selectItem = false;
				BtnDesactiveSuppr();
				txtLibelleFixe.Text = "";
				txtPrixUnitaireFixe.Text = "";
				txtDateFixe.Text = "";
				txtQuantiteFixe.Text = "";
				txtLibelle.Text = "";
				txtPrixUnitaire.Text = "";
				txtDate.Text = "";
				txtQuantite.Text = "";
			}
		}

	}



}
