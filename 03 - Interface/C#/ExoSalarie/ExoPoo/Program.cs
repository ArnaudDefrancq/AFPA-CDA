using ExoPoo.Class;

namespace ExoPoo;

// max : 5 vendeurs, 2 représentants, 3 techniciens, 5 intérimaires

class Program
{
	static void Main()
	{
		Techniciens tech1 = new Techniciens(22, "Pourquoi", "Pas");
		Techniciens tech2 = new Techniciens(22, "Pourquoi", "Ca");
		Techniciens tech3 = new Techniciens(22, "Pourquoi", "Va");

		Interimaires int1 = new Interimaires(22, "interim", "maire", 1000);
		Interimaires int2 = new Interimaires(22, "interim", "mere", 200);
		Interimaires int3 = new Interimaires(22, "interim", "mer", 1300);
		Interimaires int4 = new Interimaires(22, "interim", "pere", 100);
		Interimaires int5 = new Interimaires(22, "interim", "paire", 500);


		List<Techniciens> techniciens = new List<Techniciens>() { tech1, tech2, tech3, int1, int2, int3, int4, int5 };

		Vendeurs v1 = new Vendeurs(22, "ven", "heure", 2, 62);
		Vendeurs v2 = new Vendeurs(22, "ven", "heure", 1, 42);
		Vendeurs v3 = new Vendeurs(22, "ven", "heure", 9, 22);

		Representants r1 = new Representants(22, "repre", "sante", 21, 6);
		Representants r2 = new Representants(22, "repre", "sante", 11, 7);

		List<Commerciaux> commerciauxes = new List<Commerciaux>() { v1, v2, v3, r1, r2 };

		Entreprise ent1 = new Entreprise(commerciauxes, techniciens, "paul");

		Console.WriteLine(ent1.ToString());
	}
}
