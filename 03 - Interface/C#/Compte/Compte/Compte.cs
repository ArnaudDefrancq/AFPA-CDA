using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compte
{
	internal class Compte
	{
		public int Solde { get; set; }
		public static int idCompte = 0;

		public Compte(int solde)
		{
			Solde = solde;
		}
	}
}
