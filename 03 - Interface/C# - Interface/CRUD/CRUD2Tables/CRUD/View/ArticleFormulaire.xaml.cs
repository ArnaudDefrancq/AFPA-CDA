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
		public bool validMofidierArticle = false;
		public bool selectCategorie = false;
		public bool itemSelect = false;


		public ArticleFormulaire(MainWindow w)
		{
			InitializeComponent();
			Mw = w;

			DisplayValueInput();
			DisplayListCategorie();
		}
		//************************************************//
		//Permet d'afficher les categories dans la listBox
		private void DisplayListCategorie()
		{
			CategorieController controller = new CategorieController();
			List<Categorie> categorie = controller.GetAllCategories();

			groupCategorie.ItemsSource = categorie;
			if (itemSelect)
			{
				Article a = Mw.gridDataArticle.SelectedItem as Article;



				for (int i = 0; i < categorie.Count; i++)
				{
					if (categorie[i].LibelleCategorie == a.LabelleCategorie)
					{
						groupCategorie.SelectedIndex = i;

					}
				}

			}
		}

		//************************************************//
		// Evenement quand on selectionne une categorie
		private void groupCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int quantite, prixUnitaire;
			string valueQuantite = txtQuantite.Text;
			string valuePrixUnitaire = txtPrixUnitaire.Text;

			if (groupCategorie.SelectedItem != null && Mw.validAjoutArticle && int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire))
			{
				selectCategorie = true;
				validAjoutArticle = true;
				BtnActiveAjout();
				txtMontantTotal.Text = (quantite * prixUnitaire).ToString();
			}

			if (groupCategorie.SelectedItem != null && Mw.validModiftArticle && int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire))
			{
				validMofidierArticle = true;
				BtnActiveModif();
				txtMontantTotal.Text = (quantite * prixUnitaire).ToString();
			}
		}

		//************************************************//
		//Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			int quantite, prixUnitaire, montantTotal;
			String libelleArticle = txtLibelleArticle.Text;
			String valueQuantite = txtQuantite.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			// Vérification des données pour Ajout
			if (Mw.validAjoutArticle && int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleArticle = txtLibelleArticle.Text).Length > 0 && selectCategorie)
			{
				validAjoutArticle = true;
				BtnActiveAjout();
			}
			else
			{
				validAjoutArticle = false;
				BtnDesactiveAjout();
			}

			// Vérification des données pour Modif
			if (Mw.validModiftArticle && int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleArticle = txtLibelleArticle.Text).Length > 0)
			{
				validMofidierArticle = true;
				BtnActiveModif();
			}
			else
			{
				validMofidierArticle = false;
				BtnDesactiveModif();
			}

			// Ajout du montant total
			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valuePrixUnitaire, out prixUnitaire))
			{
				txtMontantTotal.Text = (quantite * prixUnitaire).ToString();
			}
			else
			{
				txtMontantTotal.Text = "0";
			}
		}

		//************************************************//
		//  Evenement activation / desactivation Btn
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

		public void BtnActiveModif()
		{
			if (validMofidierArticle)
			{
				btnModifArticle.IsEnabled = true;
			}
		}
		public void BtnDesactiveModif()
		{
			if (!validMofidierArticle)
			{
				btnModifArticle.IsEnabled = false;
			}
		}

		//************************************************//
		// Si pour modif, on affiche les valeurs du produit dans les inputs
		private void DisplayValueInput()
		{
			if (Mw.gridDataArticle.SelectedItem != null)
			{
				// Permet de savoir si un item a été sélectionner
				itemSelect = true;

				// Récup des données du  produit et ajout des les inputs
				Article a = Mw.gridDataArticle.SelectedItem as Article;
				txtLibelleArticle.Text = a.LibelleArticle;
				txtPrixUnitaire.Text = a.PrixUnitaire.ToString();
				txtQuantite.Text = a.Quantite.ToString();
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
