using CRUD.Controllers;
using CRUD.Models;
using CRUD.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace CRUD.View
{
	/// <summary>
	/// Logique d'interaction pour DetailsFenetre.xaml
	/// </summary>
	public partial class DetailsFenetre : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;
		private static readonly Regex intRegex = new Regex(@"^[\d]+$");

		private MarqueController _controller;
		private voitureDBContext _context;


		public string Mode { get; set; }
		public MainWindow Mw { get; set; }
		public DetailsFenetre(MarqueDtoAvecModel v, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_controller = new MarqueController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(v);
			BtnActivationDesactivation();
		}
		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(MarqueDtoAvecModel v)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtMarque.Text = v.Libelle;
				txtIdVoiture.Text = v.IdMarque.ToString();
				//txtModel.Text = v.Model;

				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtMarque.IsEnabled = false;
					txtIdVoiture.IsEnabled = false;
					//txtModel.IsEnabled = false;
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
			MarqueDtoAvecModel v = new MarqueDtoAvecModel(Int32.Parse((string)txtIdVoiture.Text), txtMarque.Text);

			switch (Mode)
			{
				case "Ajouter": _controller.CreateMarque(v); break;
				case "Modifier": _controller.UpdateMarque(Int32.Parse((string)txtIdVoiture.Text), v); break;
				case "Supprimer": _controller.DeleteMarque(Int32.Parse((string)txtIdVoiture.Text)); break;
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


			// Recup des données dans les inputs
			int km;
			String marque = txtMarque.Text;
			//String model = txtModel.Text;
			//String valueKm = txtNbKm.Text;

			// Vérification des données pour Ajout
			if (marque.Length > 0)
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

		private void txtNbKm_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = !intRegex.IsMatch(e.Text);
		}
	}
}
