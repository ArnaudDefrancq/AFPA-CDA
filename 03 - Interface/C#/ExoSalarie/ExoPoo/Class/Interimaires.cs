using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	internal class Interimaires : Techniciens
	{
		const Double NB_IRIS_PAR_HEURE = 0.5;

		// Propriete
		public Double NbHeures { get; set; }

		// Constructeur
		public Interimaires(int age, string nom, string prenom, Double nbHeures) : base(age, nom, prenom)
		{
			NbHeures = nbHeures;
			Salaire = CalculSalaire();
		}

		// Methode
		/// <summary>
		/// Calcul du salaire en fonction du nombre d'heure
		/// </summary>
		/// <returns></returns>
		public override Double CalculSalaire()
		{
			Double sal;
			sal = NB_IRIS_PAR_HEURE * NbHeures;

			return sal;
		}

	}
}
