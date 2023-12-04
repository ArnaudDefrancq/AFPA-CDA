using APP.Controller;
using APP.Helpers;
using APP.Models.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace APP.View
{
	/// <summary>
	/// Logique d'interaction pour ProduitFormulaire.xaml
	/// </summary>
	public partial class ProduitFormulaire : Window
	{
		public bool validAjout = false;
		public bool validModif = false;
		public bool itemSelect = false;

		public MainWindow Mw { get; set; }

		public ProduitFormulaire(MainWindow w)
		{
			InitializeComponent();

			Mw = w;

			DisplayValueInput();

			ActiveBtnSuppr();
		}

		//************************************************//
		//Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int quantite, date, prixUnitaire;
			String libelleProd = "";
			String valueQuantite = txtQuantite.Text;
			String valueDate = txtAnnee.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			// Vérification des données pour Ajout
			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && !itemSelect)
			{
				validAjout = true;
				BtnActiveAjout();
			}
			else
			{
				validAjout = false;
				BtnDesactiveAjout();
			}

			// Vérification des données pour Modif
			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && itemSelect && !Mw.validSuppr)
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
		// Si pour modif, on affiche les valeurs du produit dans les inputs
		private void DisplayValueInput()
		{
			if (Mw.gridData.SelectedItem != null)
			{
				// Permet de savoir si un item a été sélectionner
				itemSelect = true;

				// Récup des données du  produit et ajout des les inputs
				Produits p = Mw.gridData.SelectedItem as Produits;
				txtAnnee.Text = p.Date.ToString();
				txtLibelle.Text = p.LibelleProduit;
				txtPrixUnitaire.Text = p.PrixUnitaire.ToString();
				txtQuantite.Text = p.Quantite.ToString();
			}
		}

		//************************************************//
		// Evenement du click ajouter
		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			if (validAjout)
			{
				// Création d'un nouvelle objet
				ProduitController controller = new ProduitController();
				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtAnnee.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);
				Produits p = new Produits(libelleProd, valueQuantite, valuePrixUnitaire, valueDate);

				// Appel du controller
				controller.CreateProduit(p);

				// Modif de l'affichage dans la fenetre principale
				Mw.DisplayDataGrid();

				// Remise des inputs a 0
				txtLibelle.Text = "";
				txtPrixUnitaire.Text = "";
				txtAnnee.Text = "";
				txtQuantite.Text = "";
			}
		}

		//************************************************//
		// Evenement du click modifier
		private void btnModifier_Click(object sender, RoutedEventArgs e)
		{
			if (validModif)
			{
				//Créer un nouvelle objet avec modif
				ProduitController controller = new ProduitController();
				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtAnnee.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);
				Produits produitSansModif = Mw.gridData.SelectedItem as Produits; // Permet de récup l'Id de l'objet a modifier
				Produits produitModif = new Produits(produitSansModif.IdProduit, libelleProd, valueQuantite, valuePrixUnitaire, valueDate);

				// Appel du controller
				controller.UpdateProduit(produitModif);

				// Modif de l'affichage dans la fenetre principale
				Mw.DisplayDataGrid();
				this.Close();

			}
		}

		//************************************************//
		// Evenement du click suppr
		private void btnSuppr_Click(object sender, RoutedEventArgs e)
		{
			if (Mw.validSuppr)
			{
				// Initiation d'un nouvelle objet controller
				ProduitController controller = new ProduitController();
				Produits p = Mw.gridData.SelectedItem as Produits;

				controller.DeleteProduit(p);
				Mw.DisplayDataGrid();
				this.Close();

			}
		}

		private void ActiveBtnSuppr()
		{
			if (Mw.validSuppr)
			{
				btnSuppr.IsEnabled = true;

				txtAnnee.IsEnabled = false;
				txtLibelle.IsEnabled = false;
				txtPrixUnitaire.IsEnabled = false;
				txtQuantite.IsEnabled = false;
			}
		}
		//************************************************//
	}
}
