using CRUDGestionCours.Controllers;
using CRUDGestionCours.Models;
using CRUDGestionCours.Models.Dtos;
using CRUDGestionCours.View.Liste;
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

namespace CRUDGestionCours.View.Formulaire
{
	/// <summary>
	/// Logique d'interaction pour CoursFormulaire.xaml
	/// </summary>
	public partial class CoursFormulaire : Window
	{
		private CoursController _coursController;
		private GestionCoursDBContext _context;

		public bool validInput = false;

		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		public string Mode { get; set; }
		public CoursListe Cl { get; set; }

		public CoursFormulaire(CoursDtoOutAplatie ca, CoursListe w, string mode)
		{
			InitializeComponent();
			Cl = w;
			_context = Cl._context;
			_coursController = new CoursController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(ca);
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(CoursDtoOutAplatie ca)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtNomCours.Text = ca.Nom;
				txtDescriptionCours.Text = ca.Description;
				txtIdCours.Text = ca.IdCours.ToString();
				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtNomCours.IsEnabled = false;
					txtDescriptionCours.IsEnabled = false;
				}
			}
			else
			{
				txtIdCours.Text = "0";
			}
		}

		//*******************************************************//
		// Permet de saisir uniquement des letre dans les inputs
		private void CheckOnlyLettre(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !textRegex.IsMatch(e.Text);
		}

		//*******************************************************//
		// Activation du button si les inputs sont correctes
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			String nom = txtNomCours.Text;
			String description = txtDescriptionCours.Text;

			// Vérification des données pour Ajout
			if (nom.Length > 0 && description.Length > 0)
			{
				validInput = true;
				BtnActivationDesactivation();
			}
			else
			{
				validInput = false;
				BtnActivationDesactivation();
			}
		}

		//*******************************************************//
		// Activation du button en fonction
		private void BtnActivationDesactivation()
		{
			if (validInput)
			{
				btnValide.IsEnabled = true;
				Style dynamicStyle = (Style)Application.Current.Resources["btnStyle"];
				btnValide.Style = dynamicStyle;
			}
			else
			{
				btnValide.IsEnabled = false;
				btnValide.Style = null;
			}
		}

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			CoursDtoIn cIn = new CoursDtoIn(txtNomCours.Text, txtDescriptionCours.Text);

			switch (Mode)
			{
				case "Ajouter": _coursController.CreateCours(cIn); break;
				case "Modifier": _coursController.UpdateCours(Int32.Parse((string)txtIdCours.Text), cIn); break;
				case "Supprimer": _coursController.DeleteCours(Int32.Parse((string)txtIdCours.Text)); break;
			}

			this.Close();
		}

		//*******************************************************//
		// Action de fermer la page
		private void annuler_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

	}
}
