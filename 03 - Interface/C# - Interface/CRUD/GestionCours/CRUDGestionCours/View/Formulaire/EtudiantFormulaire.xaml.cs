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
	/// Logique d'interaction pour EtudiantFormulaire.xaml
	/// </summary>
	public partial class EtudiantFormulaire : Window
	{
		private EtudiantController _etudiantController;
		private GestionCoursDBContext _context;

		public bool validInput = false;

		private static readonly Regex intRegex = new Regex(@"^[\d]+$");
		private static readonly Regex textRegex = new Regex(@"^[a-zA-Z]+$");

		public string Mode { get; set; }
		public EtudiantListe El { get; set; }

		public EtudiantFormulaire(EtudiantDtoOutAplatie ea, EtudiantListe w, string mode)
		{
			InitializeComponent();
			El = w;
			_context = El._context;
			_etudiantController = new EtudiantController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(ea);
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(EtudiantDtoOutAplatie ea)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtNomEtudiant.Text = ea.Nom;
				txtPrenomEtudiant.Text = ea.Prenom;
				txtAgeEtudiant.Text = ea.Age.ToString();
				txtIdEtudiant.Text = ea.IdEtudiants.ToString();
				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtNomEtudiant.IsEnabled = false;
					txtPrenomEtudiant.IsEnabled = false;
					txtAgeEtudiant.IsEnabled = false;
				}
			}
			else
			{
				txtIdEtudiant.Text = "0";
			}
		}

		//*******************************************************//
		// Permet d'écrire uniquement des chiffres dans les inputs
		private void CheckOnlyNumber(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !intRegex.IsMatch(e.Text);
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
			String nom = txtNomEtudiant.Text;
			String prenom = txtPrenomEtudiant.Text;
			String age = txtAgeEtudiant.Text;

			// Vérification des données pour Ajout
			if (nom.Length > 0 && prenom.Length > 0 && age.Length > 0)
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
			EtudiantDtoIn eIn = new EtudiantDtoIn(txtNomEtudiant.Text, txtPrenomEtudiant.Text, Int32.Parse(txtAgeEtudiant.Text));

			switch (Mode)
			{
				case "Ajouter": _etudiantController.CreateEtudiant(eIn); break;
				case "Modifier": _etudiantController.UpdateEtudiant(Int32.Parse((string)txtIdEtudiant.Text), eIn); break;
				case "Supprimer": _etudiantController.DeleteEtudiant(Int32.Parse((string)txtIdEtudiant.Text)); break;
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
		// Pour ajouter des placeholder
		private void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			if (textBox.Text == "Description du cours")
			{
				textBox.Text = "";
			}
		}

		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			if (string.IsNullOrWhiteSpace(textBox.Text))
			{
				textBox.Text = "Description du cours";
			}
		}

	}
}
