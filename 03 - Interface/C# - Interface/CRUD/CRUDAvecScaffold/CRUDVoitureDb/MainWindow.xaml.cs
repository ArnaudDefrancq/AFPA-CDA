using CRUDVoitureDb.Controllers;
using CRUDVoitureDb.Models;
using CRUDVoitureDb.Models.Dtos;
using CRUDVoitureDb.View;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CRUDVoitureDb
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private VoitureController _controller;
		public VoitureDBContext _context;

		public bool validModif = false;
		public bool validSuppr = false;
		public MainWindow()
		{
			InitializeComponent();

			_context = new VoitureDBContext();
			_controller = new VoitureController(_context);

			DisplayDataGrid();
		}

		//*******************************************************//
		//Affiche dans le dataGRid
		public void DisplayDataGrid()
		{
			gridDataArticle.ItemsSource = _controller.GetAllVoitures();
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
			VoitureDto item;
			if (((Button)sender).Name == "btnAjouter")
			{
				item = new VoitureDto();
			}
			else
			{
				item = (VoitureDto)gridDataArticle.SelectedItem;
			}

			DetailsVoiture w = new DetailsVoiture(item, this, (string)((Button)sender).Content);
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;

			//DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}

		//*******************************************************//
		// Action sur les btns Ajouts/Modifier/Supprimer
		private void Row_DoubleClick(object sender, EventArgs e)
		{
			VoitureDto item = gridDataArticle.SelectedItem as VoitureDto;

			DetailsVoiture w = new DetailsVoiture(item, this, "Modifier");
			this.Opacity = 0.7;
			w.ShowDialog();
			this.Opacity = 1;
			//DisplayDataGrid();
			validSuppr = false;
			validModif = false;
			BtnActiveDesactiveModif();
			BtnActiveDesactiveSuppr();
		}
	}
}

