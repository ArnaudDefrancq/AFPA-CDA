﻿using System;
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

namespace Produits
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnModifier_Click(object sender, RoutedEventArgs e)
		{
			String codeTest = "Test";
			Fenetre2 f2 = new Fenetre2(this, codeTest);
			this.Opacity = 0.6;
			f2.ShowDialog();
			this.Opacity = 1;
		}

		public void ChangeTextBtn(String mot)
		{
			btnModifier.Content = mot;
		}
	}
}
