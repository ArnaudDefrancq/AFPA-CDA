using APP.Controller;
using APP.Models.Data;
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

namespace APP.View
{

	/// <summary>
	/// Logique d'interaction pour ProduitFormulaire.xaml
	/// </summary>
	public partial class ProduitFormulaire : Window
	{
		public bool validAjout = false;
		public bool validModif = false;
		public bool selectItem = false;


		public ProduitFormulaire(bool itemSelect)
		{
			InitializeComponent();

			selectItem = itemSelect;
		}


		//Permet d'activer les btn ajouter
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			int quantite, date, prixUnitaire;
			String libelleProd = "";
			String valueQuantite = txtQuantite.Text;
			String valueDate = txtAnnee.Text;
			String valuePrixUnitaire = txtPrixUnitaire.Text;

			if (int.TryParse(valueQuantite, out quantite) && int.TryParse(valueDate, out date) && int.TryParse(valuePrixUnitaire, out prixUnitaire) && (libelleProd = txtLibelle.Text).Length > 0 && !selectItem)
			{
				validAjout = true;
				BtnActiveAjout();
			}
			else
			{
				validAjout = false;
				BtnDesactiveAjout();
			}

			if (selectItem)
			{
				validModif = true;
				BtnActiveModif();
			}
			else
			{
				validModif = false;
				BtnDesactiveModif();
			}

		}
		private void BtnActiveAjout()
		{
			if (validAjout)
			{
				btnAjouter.IsEnabled = true;
			}
		}
		private void BtnDesactiveAjout()
		{
			if (!validAjout)
			{
				btnAjouter.IsEnabled = false;
			}
		}

		private void BtnActiveModif()
		{
			if (validModif)
			{
				btnModifier.IsEnabled = true;
			}
		}
		private void BtnDesactiveModif()
		{
			if (!validModif)
			{
				btnModifier.IsEnabled = false;
			}
		}

		private void btnAjouter_Click(object sender, RoutedEventArgs e)
		{
			if (validAjout)
			{
				ProduitController controller = new ProduitController();

				String libelleProd = txtLibelle.Text;
				int valueQuantite = Convert.ToInt32(txtQuantite.Text);
				int valueDate = Convert.ToInt32(txtAnnee.Text);
				int valuePrixUnitaire = Convert.ToInt32(txtPrixUnitaire.Text);

				Produits p = new Produits(libelleProd, valueQuantite, valuePrixUnitaire, valueDate);
				controller.CreateProduit(p);

				txtLibelle.Text = "";
				txtPrixUnitaire.Text = "";
				txtAnnee.Text = "";
				txtQuantite.Text = "";
			}
		}
	}


}
