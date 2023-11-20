using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		String calcul = "";
		public MainWindow()
		{
			InitializeComponent();
			result.Text = "";
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			//Faire apparaitre les tailles dans la sortie
			((Window)sender).ActualHeight.Dump();
			((Window)sender).ActualWidth.Dump();

			((Window)sender).Height = 4 / 3 * ((Window)sender).ActualWidth; // garder les proportions



		}

		private bool avoirSigne()
		{
			List<Char> signe = new List<Char>() { '+', '/', '*', '-' };
			foreach (Char c in signe)
			{
				if (result.Text.EndsWith(c))
				{
					return true;
				}
			}
			return false;
		}

		private void activeVirgule()
		{
			if (calcul.Contains(',') || calcul.Contains('.'))
			{
				btnVirgule.IsEnabled = false;
			}
			else
			{
				btnVirgule.IsEnabled = true;
			}
		}

		private void activeBtn()
		{
			List<Button> btnSigne = new List<Button>() { btnPlus, btnMoins, btnDiviser, btnMultiple };
			foreach (Button btn in btnSigne)
			{
				btn.IsEnabled = true;
			}
		}

		private void desactiveBtn()
		{
			List<Button> btnSigne = new List<Button>() { btnPlus, btnMoins, btnDiviser, btnMultiple };
			foreach (Button btn in btnSigne)
			{
				btn.IsEnabled = false;
			}

		}

		private void btnNumb_Click(object sender, RoutedEventArgs e)
		{
			result.Text += (String)((Button)sender).Content;
			calcul += (String)((Button)sender).Content;
			activeBtn();

			activeVirgule();
			result.Text.Dump();

			if (avoirSigne())
			{
				btnEgal.IsEnabled = false;
			}
			else
			{
				btnEgal.IsEnabled = true;
			}
		}

		private void btnVirgule_Click(object sender, RoutedEventArgs e)
		{
			result.Text += (String)((Button)sender).Content;
			calcul += (String)((Button)sender).Content;

			btnVirgule.IsEnabled = false;

		}

		private void btnSigne_Click(object sender, RoutedEventArgs e)
		{
			result.Text += (String)((Button)sender).Content;
			desactiveBtn();
			calcul = "";
		}

		private void btnCe_Click(object sender, RoutedEventArgs e)
		{
			result.Text = "";
			calcul = "";
			desactiveBtn();
			btnVirgule.IsEnabled = false;
		}

		private void btnEgal_Click(object sender, RoutedEventArgs e)
		{
			var dt = new DataTable();
			String exp = Convert.ToString(result.Text.Replace(',', '.'));


			result.Text = dt.Compute(exp, String.Empty).ToString();
			result.Text.Dump();

			calcul = result.Text;

			activeVirgule();
		}
	}
}
