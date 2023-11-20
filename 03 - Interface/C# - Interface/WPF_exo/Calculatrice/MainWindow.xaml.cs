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
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			//Faire apparaitre les tailles dans la sortie
			((Window)sender).ActualHeight.Dump();
			((Window)sender).ActualWidth.Dump();

			((Window)sender).Height = 4 / 3 * ((Window)sender).ActualWidth; // garder les proportions



		}

		private void btnNumb_Click(object sender, RoutedEventArgs e)
		{
			result.Text += (String)((Button)sender).Content;
		}

		private void btnVirgule_Click(object sender, RoutedEventArgs e)
		{
			if (!result.Text.Contains(','))
			{
				result.Text += (String)((Button)sender).Content;
			}
		}
	}
}
