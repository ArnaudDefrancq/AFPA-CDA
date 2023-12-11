using CRUD.Controllers;
using CRUD.Models;
using CRUD.Models.Dtos;
using CRUD.View;
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

namespace CRUD
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private PrescriptionController _controller;
		public medecinedbDBContext _context;

		public bool validModif = false;
		public bool validSuppr = false;
		public MainWindow()
		{
			InitializeComponent();

			_context = new medecinedbDBContext();
			_controller = new PrescriptionController(_context);

			DisplayDataGrid();
		}

		//*******************************************************//
		//Affiche dans le dataGRid
		public void DisplayDataGrid()
		{
			gridDataPrescription.ItemsSource = _controller.GetAllPrescriptions();
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
				Style dynamicStyle = (Style)Application.Current.Resources["btnTemp"];
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
		private void gridDataArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			validSuppr = true;
			validModif = true;

			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}


		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void btnActionClick(object sender, EventArgs e)
		{
			PrescriptionDtoOutAplatie item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new PrescriptionDtoOutAplatie();
			}
			else
			{
				item = (PrescriptionDtoOutAplatie)gridDataPrescription.SelectedItem;
			}

			PrescriptionFormulaire w = new PrescriptionFormulaire(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;

			DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void Row_DoubleClick(object sender, EventArgs e)
		{
			PrescriptionDtoOutAplatie item = gridDataPrescription.SelectedItem as PrescriptionDtoOutAplatie;

			PrescriptionFormulaire w = new PrescriptionFormulaire(item, this, "Modifier");
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

	}
}
