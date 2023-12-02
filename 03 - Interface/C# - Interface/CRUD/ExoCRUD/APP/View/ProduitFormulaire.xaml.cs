using APP.Controller;
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
		}

		//************************************************//
		//Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			int quantite, date, prixUnitaire;
			String libelleProd = "";
			String valueQuantite = txtQuantite.Text;
			String valueDate = txtAnnee.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

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

			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && itemSelect)
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
				itemSelect = true;

				Produits p = Mw.gridData.SelectedItem as Produits;
				txtAnnee.Text = p.Date.ToString();
				txtLibelle.Text = p.LibelleProduit;
				txtPrixUnitaire.Text = p.PrixUnitaire.ToString();
				txtQuantite.Text = p.Quantite.ToString();

				validModif = true;
				validAjout = false;
				Mw.BtnDesactiveAjout();
				Mw.BtnActiveModif();
			}
		}
		//************************************************//
		// Evenement du click ajouter
		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			if (validAjout)
			{
				ProduitController controller = new ProduitController();

				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtAnnee.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);

				Produits p = new Produits(libelleProd, valueQuantite, valuePrixUnitaire, valueDate);
				controller.CreateProduit(p);

				Mw.DisplayDataGrid();

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
				ProduitController controller = new ProduitController();

				//Créer un nouvelle objet avec modif
				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtAnnee.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);

				Produits produitSansModif = Mw.gridData.SelectedItem as Produits;

				Produits produitModif = new Produits(produitSansModif.IdProduit, libelleProd, valueQuantite, valuePrixUnitaire, valueDate);

				controller.UpdateProduit(produitModif);

				Mw.DisplayDataGrid();
			}
		}
	}


}
