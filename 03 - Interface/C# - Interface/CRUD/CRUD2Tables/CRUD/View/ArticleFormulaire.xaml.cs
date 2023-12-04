﻿using CRUD.Controllers;
using CRUD.Helpers;
using CRUD.Models.Data;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CRUD.View
{


	public partial class ArticleFormulaire : Window
	{
		public MainWindow Mw { get; set; }
		public bool validAjoutArticle = false;
		public bool selectCategorie = false;

		public ArticleFormulaire(MainWindow w)
		{
			InitializeComponent();
			Mw = w;

			DisplayListCategorie();
		}
		//************************************************//
		//Permet d'afficher les categories dans la listBox
		private void DisplayListCategorie()
		{
			CategorieController controller = new CategorieController();
			List<Categorie> categorie = controller.GetAllCategories();
			groupCategorie.ItemsSource = categorie;
		}

		//************************************************//
		// Evenement quand on selectionne une categorie
		private void groupCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (groupCategorie.SelectedItem != null)
			{
				selectCategorie = true;
				selectCategorie.Dump();
			}
		}

		//************************************************//
		//Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int quantite, prixUnitaire, montantTotal;
			String libelleArticle = txtLibelleArticle.Text;
			String valueQuantite = txtPrixUnitaire.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;


			// Vérification des données pour Ajout
			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleArticle = txtLibelleArticle.Text).Length > 0 && selectCategorie)
			{
				validAjoutArticle = true;
				BtnActiveAjout();
				txtMontantTotal.Text = (quantite * prixUnitaire).ToString();
			}
			else
			{
				validAjoutArticle = false;
				BtnDesactiveAjout();
			}

			// Vérification des données pour Modif
			//if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && itemSelect && !Mw.validSuppr)
			//{
			//	validModif = true;
			//	BtnActiveModif();
			//}
			//else
			//{
			//	validModif = false;
			//	BtnDesactiveModif();
			//}
		}
		private void BtnActiveAjout()
		{
			if (validAjoutArticle)
			{
				btnAjoutArticle.IsEnabled = true;
			}
		}
		private void BtnDesactiveAjout()
		{
			if (!validAjoutArticle)
			{
				btnAjoutArticle.IsEnabled = false;
			}
		}

		//************************************************//
		// Evenement du click ajouter
		private void btnAjoutArticle_Click(object sender, RoutedEventArgs e)
		{
			if (validAjoutArticle)
			{
				// Récupération de la catégorie
				Categorie categorie = groupCategorie.SelectedItem as Categorie;

				// Création d'un nouvelle objet Article
				ArticleController controller = new ArticleController();
				String libelleProd = txtLibelleArticle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);
				int valueMontantTotal = Convert.ToInt32(txtMontantTotal.Text);

				Article a = new Article(libelleProd, valueQuantite, valuePrixUnitaire, categorie.LibelleCategorie);

				// Appel du controller
				controller.CreateArticle(a);

				// Modif de l'affichage dans la fenetre principale
				Mw.DisplayDataGridArticle();

				// Remise des inputs a 0
				txtLibelleArticle.Text = "";
				txtPrixUnitaire.Text = "";
				txtQuantite.Text = "";
			}
		}

		//************************************************//
		// Evenement du click Modifier

		//************************************************//
		// Evenement du click Supprimer

	}
}
