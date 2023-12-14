using CRUDGestionCours.Controllers;
using CRUDGestionCours.Models;
using CRUDGestionCours.Models.Data;
using CRUDGestionCours.Models.Dtos;
using CRUDGestionCours.View.Formulaire;
using CRUDGestionCours.View.Liste;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CRUDGestionCours
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public GestionCoursDBContext _context;
		private InscriptionController _controllerInscription;
		public bool validModif = false;
		public bool validSuppr = false;

		public MainWindow()
		{
			InitializeComponent();
			_context = new GestionCoursDBContext();
			_controllerInscription = new InscriptionController(_context);
			DisplayDataGridInsciption();
		}

		//*******************************************************//
		//Affiche dans le dataGRid
		public void DisplayDataGridInsciption()
		{
			gridDataInscription.ItemsSource = _controllerInscription.GetAllInscriptions();
		}

		//*******************************************************//
		// Permet d'activer les btn suppr et modifier
		private void BtnActiveDesactiveSuppr()
		{
			if (validSuppr)
			{
				btnSuppr.IsEnabled = true;
			}
			else
			{
				btnSuppr.IsEnabled = false;
			}
		}

		public void BtnActiveDesactiveModif()
		{
			if (validModif)
			{
				btnModifier.IsEnabled = true;
				Style dynamicStyle = (Style)Application.Current.Resources["btnStyle"];
				btnModifier.Style = dynamicStyle;
			}
			else
			{
				btnModifier.IsEnabled = false;
				btnModifier.Style = null;
			}
		}

		//************************************************//
		// Permet d'activer les btn suppr et modifier au click sur un element de la dataGrid
		private void gridDataArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			validSuppr = true;
			validModif = true;

			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionClick(object sender, EventArgs e)
		{
			InscriptionDtoOutAplatie item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new InscriptionDtoOutAplatie();
			}
			else
			{
				item = (InscriptionDtoOutAplatie)gridDataInscription.SelectedItem;
			}

			InscriptionFormulaire w = new InscriptionFormulaire(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			DisplayDataGridInsciption();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void Row_DoubleClick(object sender, EventArgs e)
		{
			InscriptionDtoOutAplatie item = gridDataInscription.SelectedItem as InscriptionDtoOutAplatie;

			InscriptionFormulaire w = new InscriptionFormulaire(item, this, "Modifier");
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			DisplayDataGridInsciption();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		private void ListEtudiantClick(object sender, RoutedEventArgs e)
		{
			EtudiantListe el = new EtudiantListe(this);
			this.Opacity = 0.7;
			el.ShowDialog();
			this.Opacity = 1;
		}

		private void ListCoursClick(object sender, RoutedEventArgs e)
		{
			CoursListe el = new CoursListe(this);
			this.Opacity = 0.7;
			el.ShowDialog();
			this.Opacity = 1;
		}
	}
}


