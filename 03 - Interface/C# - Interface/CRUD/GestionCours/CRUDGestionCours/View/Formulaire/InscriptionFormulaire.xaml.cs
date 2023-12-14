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
		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public InscriptionFormulaire(InscriptionDtoOutAplatie ia, MainWindow w, string mode)
		{
			InitializeComponent();
		}
	}
}
