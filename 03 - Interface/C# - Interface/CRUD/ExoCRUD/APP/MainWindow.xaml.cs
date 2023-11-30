﻿using APP.Controller;
using APP.Helpers;
using APP.Models;
using APP.Models.Data;
using APP.Models.Dtos;
using APP.Models.Profiles;
using APP.Models.Service;
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
			List<ProduitDto> produitDtos = controller.GetAllProduits();

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
				ProduitDto produitDto = gridData.SelectedItem as ProduitDto;
				validSuppr = true;
				selectItem = true;
				BtnActiveSuppr();
				txtLibelleFixe.Text = produitDto.LibelleProduit;
				txtQuantiteFixe.Text = produitDto.Quantite.ToString();
				txtPrixUnitaireFixe.Text = produitDto.PrixUnitaire.ToString();
				txtDateFixe.Text = produitDto.Date.ToString();
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
				ProduitController controller = new ProduitController();
				ProduitDto p = gridData.SelectedItem as ProduitDto;
				controller.DeleteProduit(p);
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

	}



}
