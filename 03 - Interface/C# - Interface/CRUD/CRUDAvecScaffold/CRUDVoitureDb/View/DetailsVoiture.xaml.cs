using CRUDVoitureDb.Models.Dtos;
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

namespace CRUDVoitureDb.View
{
	/// <summary>
	/// Logique d'interaction pour DetailsVoiture.xaml
	/// </summary>
	public partial class DetailsVoiture : Window
	{
		public bool validAjoutArticle = false;
		public bool validModifArticle = false;

		public string Mode { get; set; }
		public MainWindow Mw { get; set; }

		public DetailsVoiture(VoitureDto v, MainWindow w, string mode)
		{
			InitializeComponent();
			Mw = w;
			Mode = mode;
			btnValide.Content = Mode;
		}
	}
}
