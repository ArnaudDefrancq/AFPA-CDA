using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	public class Entreprise
	{
		//Propriete
		public List<Commerciaux> Commerciaux { get; set; }
		public List<Techniciens> Techniciens { get; set; }
		public String Nom { get; set; }

		//Constructeur
		public Entreprise(List<Commerciaux> commerciaux, List<Techniciens> techniciens, string nom)
		{
			Commerciaux = commerciaux;
			Techniciens = techniciens;
			Nom = nom;
		}

		//Methode
		//Affichage
		public override string ToString()
		{
			String aff = "";
			aff += "nom entreprise : " + Nom + " - Masse salariale : " + MasseSalariale() + " \n liste commerciaux : \n";
			foreach (Commerciaux commerciaux in Commerciaux)
			{
				aff += commerciaux.ToString() + "\n";
			}
			aff += " - liste techniciens : \n";
			foreach (Techniciens techniciens in Techniciens)
			{
				aff += techniciens.ToString() + "\n";
			}

			return aff;
		}

		/// <summary>
		/// Calcule la masse salariale de l'entreprise
		/// </summary>
		/// <returns></returns>
		public Double MasseSalariale()
		{
			Double totalSalaire = 0;

			foreach (Commerciaux commerciux in Commerciaux)
			{
				totalSalaire += commerciux.Salaire;
			};

			foreach (Techniciens techniciens in Techniciens)
			{
				totalSalaire += techniciens.Salaire;
			}

			return totalSalaire;

		}


	}
}
