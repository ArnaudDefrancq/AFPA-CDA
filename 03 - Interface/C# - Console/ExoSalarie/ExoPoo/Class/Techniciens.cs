using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	public class Techniciens : Employe
	{
		const Double SALAIRE_DE_BASE = 40;

		//Propriete
		public Double SalaireDeBase { get; private set; } = SALAIRE_DE_BASE;

		// Constructeur
		public Techniciens(int age, string nom, string prenom) : base(age, nom, prenom)
		{
			Salaire = CalculSalaire();
		}

		// Methode
		/// <summary>
		/// Calcul le salaire d'un technicien
		/// </summary>
		/// <returns></returns>
		public override Double CalculSalaire()
		{
			return SalaireDeBase;
		}

	}
}
