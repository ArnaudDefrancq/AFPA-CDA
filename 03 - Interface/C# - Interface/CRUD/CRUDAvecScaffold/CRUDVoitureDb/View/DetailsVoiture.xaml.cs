using CRUDVoitureDb.Controllers;
using CRUDVoitureDb.Helpers;
using CRUDVoitureDb.Models;
using CRUDVoitureDb.Models.Dtos;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace CRUDVoitureDb.View
{
	/// <summary>
	/// Logique d'interaction pour DetailsVoiture.xaml
	/// </summary>
	public partial class DetailsVoiture : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;

		private VoitureController _controller;
		private VoitureDBContext _context;


		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public DetailsVoiture(VoitureDto v, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_controller = new VoitureController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(v);
			BtnActivationDesactivation();


		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(VoitureDto v)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtMarque.Text = v.Marque;
				txtIdVoiture.Text = v.IdVoiture.ToString();
				txtModel.Text = v.Model;
				txtNbKm.Text = v.Km.ToString();

				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtMarque.IsEnabled = false;
					txtIdVoiture.IsEnabled = false;
					txtModel.IsEnabled = false;
					txtNbKm.IsEnabled = false;
				}
			}
			else
			{
				txtIdVoiture.Text = "0";
			}
		}

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			VoitureDto v = new VoitureDto(Int32.Parse((string)txtIdVoiture.Text), txtMarque.Text, txtModel.Text, Int32.Parse(txtNbKm.Text));

			switch (Mode)
			{
				case "Ajouter": _controller.CreateVoiture(v); break;
				case "Modifier": _controller.UpdateVoiture(Int32.Parse((string)txtIdVoiture.Text), v); break;
				case "Supprimer": _controller.DeleteVoiture(Int32.Parse((string)txtIdVoiture.Text)); break;
			}

			this.Close();
		}

		//*******************************************************//
		// Action de fermer la page
		private void annuler_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		//*******************************************************//
		// Activation du button si les inputs sont correctes
		private void TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			Regex regexInt = new Regex(@"^[\d]+$");

			// Recup des données dans les inputs
			int km;
			String marque = txtMarque.Text;
			String model = txtModel.Text;
			String valueKm = txtNbKm.Text;

			// Permet de selectionner que des int dans l'input Km
			if (!int.TryParse(valueKm, out km) && txtNbKm.Text.Length != 0)
			{
				txtNbKm.Text = txtNbKm.Text.Remove(txtNbKm.Text.Length - 1, 1);
			}
			else
			{
				txtNbKm.Text = valueKm;
			}

			// Vérification des données pour Ajout
			if (int.TryParse(valueKm, out km) && marque.Length > 0 && model.Length > 0)
			{
				validAjoutArticle = true;
				validModifArticle = true;
				BtnActivationDesactivation();
			}
			else
			{
				validAjoutArticle = false;
				validModifArticle = false;
				BtnActivationDesactivation();
			}
		}

		//*******************************************************//
		// Activation du button en fonction
		private void BtnActivationDesactivation()
		{
			if (validAjoutArticle || validModifArticle)
			{
				btnValide.IsEnabled = true;
				Style dynamicStyle = (Style)Application.Current.Resources["btnTemp"];
				btnValide.Style = dynamicStyle;
			}
			else
			{
				btnValide.IsEnabled = false;
				btnValide.Style = null;
			}
		}
	}
}
