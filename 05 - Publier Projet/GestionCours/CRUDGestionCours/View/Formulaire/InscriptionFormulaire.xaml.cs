using CRUDGestionCours.Controllers;
using CRUDGestionCours.Models;
using CRUDGestionCours.Models.Dtos;
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

namespace CRUDGestionCours.View.Formulaire
{
	/// <summary>
	/// Logique d'interaction pour InscriptionFormulaire.xaml
	/// </summary>
	public partial class InscriptionFormulaire : Window
	{
		private InscriptionController _inscriptionController;
		private CoursController _coursController;
		private EtudiantController _etudiantController;
		private GestionCoursDBContext _context;

		public bool selectCours = false;
		public bool selectEtudiant = false;

		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public InscriptionFormulaire(InscriptionDtoOutAplatie ia, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			_context = Mw._context;
			_inscriptionController = new InscriptionController(_context);
			_coursController = new CoursController(_context);
			_etudiantController = new EtudiantController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(ia);
			DisplayListCours(ia);
			DisplayListEtudiant(ia);
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(InscriptionDtoOutAplatie ia)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtDescription.Text = ia.DescriptionCours;
				txtIdInscription.Text = ia.IdInscriptions.ToString();
				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					groupCours.IsEnabled = false;
					listEtudiant.IsEnabled = false;
				}
			}
			else
			{
				txtIdInscription.Text = "0";
			}
		}

		//*******************************************************//
		// Permet de remplire l'inputs cours
		private void DisplayListCours(InscriptionDtoOutAplatie ia)
		{
			List<CoursDtoOutAplatie> list = _coursController.GetAllCours().ToList();

			groupCours.ItemsSource = list;

			if (Mode != "Ajouter")
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].IdCours == ia.IdCours)
					{
						groupCours.SelectedIndex = i;
					}
				}

			}
		}

		//*******************************************************//
		// Permet de remplire l'inputs etudiant
		private void DisplayListEtudiant(InscriptionDtoOutAplatie ia)
		{
			List<EtudiantDtoOutAplatie> list = _etudiantController.GetAllEtudiants().ToList();

			listEtudiant.ItemsSource = list;

			if (Mode != "Ajouter")
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].IdEtudiants == ia.IdEtudiant)
					{
						listEtudiant.SelectedIndex = i;
					}
				}

			}
		}

		//*******************************************************//
		// Action lors de la select d'un cours (affiche la description du cours selectionner)
		private void SelectCoursInscription(object sender, SelectionChangedEventArgs e)
		{
			CoursDtoOutAplatie cours = (CoursDtoOutAplatie)groupCours.SelectedItem;
			txtDescription.Text = cours.Description;
			selectCours = true;
			BtnActivationDesactivation();
		}

		//*******************************************************//
		// Activation du button en fonction
		private void BtnActivationDesactivation()
		{
			if (selectEtudiant && selectCours)
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
		// Per de selectionner un étudiant
		private void SelectEtudiantInscription(object sender, SelectionChangedEventArgs e)
		{
			selectEtudiant = true;
			BtnActivationDesactivation();
		}

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			CoursDtoOutAplatie cours = (CoursDtoOutAplatie)groupCours.SelectedItem;
			EtudiantDtoOutAplatie etudiant = (EtudiantDtoOutAplatie)listEtudiant.SelectedItem;
			DateTime currentTime = DateTime.Now;

			InscriptionDtoIn i = new InscriptionDtoIn(etudiant.IdEtudiants, cours.IdCours, currentTime);

			switch (Mode)
			{
				case "Ajouter": _inscriptionController.CreateInscription(i); break;
				case "Modifier": _inscriptionController.UpdateInscription(Int32.Parse((string)txtIdInscription.Text), i); break;
				case "Supprimer": _inscriptionController.DeleteInscription(Int32.Parse((string)txtIdInscription.Text)); break;
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
