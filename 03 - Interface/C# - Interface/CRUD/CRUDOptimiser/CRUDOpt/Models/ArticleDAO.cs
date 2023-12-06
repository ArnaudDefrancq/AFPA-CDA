using CRUDOpt.Models.Data;
using Newtonsoft.Json;
using System.IO;


namespace CRUDOpt.Models
{
	public class ArticleDAO
	{
		// Permet d'écrire dans un fichier JSON 
		static public void EcrireDansJSON(StructureJson sj, string path)
		{
			string[] contenu = { JsonConvert.SerializeObject(sj) };
			File.WriteAllLines(path, contenu);
		}

		static public StructureJson LireFichier(string path)
		//Renvoi un tableau de chaine contenant les records stockées dans le fichier records
		{
			string contenu;
			//Lecture et stockage 
			contenu = File.ReadAllText(path);
			//transformation en liste d'object
			StructureJson sj = JsonConvert.DeserializeObject<StructureJson>(contenu);
			return sj; // renvoi la liste des tableaux
		}

	}
}
