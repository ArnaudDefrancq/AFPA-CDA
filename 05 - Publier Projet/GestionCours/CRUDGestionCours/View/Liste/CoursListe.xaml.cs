using CRUDGestionCours.Controllers;
using CRUDGestionCours.Helpers;
using CRUDGestionCours.Models;
using CRUDGestionCours.Models.Dtos;
using CRUDGestionCours.View.Formulaire;
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
using System.Windows.Shapes;

namespace CRUDGestionCours.View.Liste
{
	/// <summary>
	/// Logique d'interaction pour CoursListe.xaml
	/// </summary>
	public partial class CoursListe : Window
	{
		private CoursController _controller;
		public GestionCoursDBContext _context;

		public bool validModif = false;
		public bool validSuppr = false;

		private MainWindow Mw { get; set; }
		public CoursListe(MainWindow w)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_controller = new CoursController(_context);
			DisplayDataGrid();
		}

		//*******************************************************//
		//Affiche dans le dataGrid etudiant
		public void DisplayDataGrid()
		{
			gridDataCours.ItemsSource = _controller.GetAllCours();
		}

		//*******************************************************//
		//Affiche dans le dataGrid Info etudiant
		private void DisplayDataGridInfoEtudiant()
		{
			CoursDtoOutAplatie cours = (CoursDtoOutAplatie)gridDataCours.SelectedItem;

			if (cours != null)
			{
				gridDataEtudiant.ItemsSource = cours.ListEtudiantInscrit;
			}
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

		//*******************************************************//
		// Permet d'activer les btn suppr et modifier au click sur un element de la dataGrid
		private void SelectCours(object sender, SelectionChangedEventArgs e)
		{
			DisplayDataGridInfoEtudiant();
			validSuppr = true;
			validModif = true;

			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionClick(object sender, EventArgs e)
		{
			CoursDtoOutAplatie item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new CoursDtoOutAplatie();
			}
			else
			{
				item = (CoursDtoOutAplatie)gridDataCours.SelectedItem;
			}

			CoursFormulaire cf = new CoursFormulaire(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			cf.ShowDialog();
			this.Opacity = 1;

			DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionAnnulClick(object sender, EventArgs e)
		{
			this.Close();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void Row_DoubleClick(object sender, EventArgs e)
		{
			CoursDtoOutAplatie item = gridDataCours.SelectedItem as CoursDtoOutAplatie;

			CoursFormulaire cf = new CoursFormulaire(item, this, "Modifier");
			this.Opacity = 0.7;
			cf.ShowDialog();
			this.Opacity = 1;
			DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}
	}
}
