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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			result.Text = "";
			List<Button> btnSigne = new List<Button>() { btnPlus, btnMoins, btnDiviser, btnMultiple };
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
			List<Char> signe = new List<Char>() { '+', '-', '/', '*' };

			foreach (Char c in signe)
			{
				if (result.Text.Contains(c))
				{
					return true;
				}
			}
			return false;

		}

		//private void activeBtn(Button btn)
		//{
		//	foreach (Button item in btn)
		//	{

		//	}
		//}

		private void desactiveBtn()
		{

		}

		private void btnNumb_Click(object sender, RoutedEventArgs e)
		{
			result.Text += (String)((Button)sender).Content;

			if (avoirSigne())
			{
				btnVirgule.IsEnabled = true;
			}
		}



		private void btnVirgule_Click(object sender, RoutedEventArgs e)
		{
			if (!result.Text.Contains(','))
			{
				result.Text += (String)((Button)sender).Content;
				btnVirgule.IsEnabled = false;
			}
		}



		private void btnSigne_Click(object sender, RoutedEventArgs e)
		{
			if (!avoirSigne())
			{
				result.Text += (String)((Button)sender).Content;
			}


		}

		private void btnCe_Click(object sender, RoutedEventArgs e)
		{
			result.Text = "";
		}

		private void btnEgal_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
