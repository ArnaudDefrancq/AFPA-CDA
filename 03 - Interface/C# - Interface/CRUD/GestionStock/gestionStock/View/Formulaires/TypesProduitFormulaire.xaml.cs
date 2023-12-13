using gestionStock.Controllers;
using gestionStock.Models;
using gestionStock.Models.Dtos;
using gestionStock.View.Listes;
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

namespace gestionStock.View.Formulaires
{
	/// <summary>
	/// Logique d'interaction pour TypesProduitFormulaire.xaml
	/// </summary>
	public partial class TypesProduitFormulaire : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;

		private TypesProduitController _typesProduitController;
		private GestionStocksDBContext _context;

		public string Mode { get; set; }
		public TypesProduitListe TPl { get; set; }

		public TypesProduitFormulaire(TypesProduitDtoAplatie tDtoA, TypesProduitListe a, string mode)
		{
			InitializeComponent();
			TPl = a;
			_context = TPl._context;
			_typesProduitController = new TypesProduitController(_context);
			Mode = mode;
			btnValide.Content = Mode;
			DisplayInput(tDtoA);
		}

		//*******************************************************//
		// Permet de remplire les inputs quand on veut modifier ou supprimer
		public void DisplayInput(TypesProduitDtoAplatie t)
		{
			if (Mode != "Ajouter") // On ecrit dans les inputs les valeurs
			{
				txtTypesProduit.Text = t.LibelleTypeProduit;
				txtIdTypesProduit.Text = t.IdTypeProduit.ToString();
				// Si supprimer, les inputs ne peuvent pas être modifier
				if (Mode == "Supprimer")
				{
					txtTypesProduit.IsEnabled = false;
				}
			}
			else
			{
				txtIdTypesProduit.Text = "0";
			}
		}

		//*******************************************************//
		// Action du btn valider en fonction des btns Ajouts/Modifier/Supprimer
		private void valider_Click(object sender, RoutedEventArgs e)
		{
			TypesProduitDtoIn t = new TypesProduitDtoIn(txtTypesProduit.Text);

			switch (Mode)
			{
				case "Ajouter": _typesProduitController.CreateTypesProduit(t); break;
				case "Modifier": _typesProduitController.UpdateTypesProduit(Int32.Parse((string)txtIdTypesProduit.Text), t); break;
				case "Supprimer": _typesProduitController.DeleteTypesProduit(Int32.Parse((string)txtIdTypesProduit.Text)); break;
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
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			// Recup des données dans les inputs
			String libelleTypesProduit = txtTypesProduit.Text;

			// Vérification des données pour Ajout
			if (libelleTypesProduit.Length > 0)
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
				Style dynamicStyle = (Style)Application.Current.Resources["btnStyle"];
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
