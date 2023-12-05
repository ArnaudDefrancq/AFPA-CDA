﻿using CRUD.Controllers;
using CRUD.Helpers;
using CRUD.Models;
using CRUD.Models.Data;
using CRUD.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CRUD
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool validAjoutArticle = true;
		public bool validModiftArticle = false;
		public bool validSupprArticle = false;

		public MainWindow()
		{
			InitializeComponent();

			InitJSON();

			DisplayDataGridArticle();
		}


		//************************************************//
		// Permet de créer la list des Articles
		private List<Article> CreerListeArticles()
		{
			List<Article> liste = new List<Article>();

			for (int i = 1; i < 15; i++)
			{
				Article p = new Article("Article" + i, i * 2, i * 6, "Categorie " + RandomNumber());
				liste.Add(p);
			}

			return liste;
		}

		private int RandomNumber()
		{
			Random rand = new Random();
			int numb = rand.Next(1, 4);
			return numb;
		}

		// Permet de créer la list des categories
		private List<Categorie> CreerListeCategories()
		{
			List<Categorie> liste = new List<Categorie>();

			for (int i = 1; i < 4; i++)
			{
				Categorie p = new Categorie("Categorie " + i);
				liste.Add(p);
			}

			return liste;
		}

		//************************************************//
		// Init des JSON
		private void InitJSON()
		{
			GestionDonnesContext BDD = new GestionDonnesContext(CreerListeArticles(), CreerListeCategories());
			BDD.UploaderDonnees();
		}

		//************************************************//
		// Affichage dans le dataGridArticle
		public void DisplayDataGridArticle()
		{
			ArticleController controller = new ArticleController();
			List<Article> produitDtos = controller.GetAllArticles();

			gridDataArticle.ItemsSource = produitDtos;
		}

		//************************************************//
		// Permet de selectionner un element dans la dataGrid
		private void gridData_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (gridDataArticle.SelectedItem != null)
			{
				// Instancie un nouvelle obj Dto
				validAjoutArticle = false;
				validModiftArticle = true;
				validSupprArticle = true;

				// Modification du formulaire et des btn
				//validSuppr = true;
				//validModif = true;
				//validAjout = false;
				//BtnActiveModif();
				//BtnActiveSuppr();
				//BtnDesactiveAjout();
			}
		}

		//************************************************//
		// Evenement au click du btn AjouterArticle
		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			if (validAjoutArticle)
			{
				// Redirection sur le formulaire
				ArticleFormulaire formulaire = new ArticleFormulaire(this);
				this.Opacity = 0.7;
				formulaire.ShowDialog();

				// Retour à la normal des Btn quand on revient sur la fenetre principal
				this.Opacity = 1;
				//validModiftArticle = false;
				//validSupprtArticle = false;
				//BtnDesactiveModif();
				//BtnDesactiveSuppr();
			}
		}

		//************************************************//
		// Evenement au click du btn ModifierArticle
		private void btnModifier_Click(object sender, RoutedEventArgs e)
		{
			if (validModiftArticle)
			{
				//validSuppr = false;
				// Redirection sur le formulaire
				ArticleFormulaire formulaire = new ArticleFormulaire(this);
				this.Opacity = 0.7;
				formulaire.ShowDialog();
				this.Opacity = 1;

				// Retour à la normal des Btn quand on revient sur la fenetre principal
				//validAjout = true;
				//validModif = false;
				//validSuppr = false;
				//modifOrSuppr = false;
				//BtnActiveAjout();
				//BtnDesactiveModif();
				//BtnDesactiveSuppr();
			}
		}

		//************************************************//
		// Evenement activation / desactivation Btn

		private void BtnActiveSuppr()
		{
			if (validSupprArticle)
			{
				btnSuppr.IsEnabled = true;
			}
		}
		private void BtnDesactiveSuppr()
		{
			if (!validSupprArticle)
			{
				btnSuppr.IsEnabled = false;
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
	}
}




