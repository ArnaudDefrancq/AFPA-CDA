using APP.CLASS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace APP
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CreerListeJSON(path);
		}

		List<Produits> produits = new List<Produits>();
		String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

		private void CreerListeJSON(String path)
		{
			List<Produits> liste = new List<Produits>();

			for (int i = 1; i < 15; i++)
			{
				Produits p = new Produits("Produit" + i, i * 2, i * 6);
				liste.Add(p);
			}


			String json = JsonConvert.SerializeObject(liste);

			File.WriteAllText(path, json);
		}





	}



}
