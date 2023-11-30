using APP.Models.Data;
using APP.Models.Dtos;
using APP.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Models.Profiles
{
	public class ProduitProfile
	{
		public List<ProduitDto> produitDto()
		{
			// Récup service
			ProduitService service = new ProduitService();
			List<Produits> p = service.GetAllProduits();

			// Initialisation de la List produitDto sans Id pour affichage
			List<ProduitDto> produitsDtoList = new List<ProduitDto>();

			// Boucle pour ajouter les produitsDto dans une boucle
			foreach (Produits produit in p)
			{
				String libelle = produit.LibelleProduit;
				int prixUnitaire = produit.PrixUnitaire;
				int dateProduits = produit.Date;
				int quantite = produit.Quantite;

				// Instanci un nouvelle objet
				ProduitDto prodDto = new ProduitDto(libelle, quantite, prixUnitaire, dateProduits);

				produitsDtoList.Add(prodDto);
			}

			return produitsDtoList;
		}

	}
}
