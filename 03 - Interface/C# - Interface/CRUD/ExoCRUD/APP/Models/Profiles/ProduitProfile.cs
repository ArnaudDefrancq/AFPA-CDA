using APP.Controller;
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
		public ProduitProfile()
		{
		}

		public List<ProduitDto> produitDtoOut()
		{
			// Récup service
			ProduitService produitService = new ProduitService();
			List<Produits> p = produitService.GetAllProduits();

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

		public Produits produitDtoIn(ProduitDto pDto)
		{
			// Récup service
			ProduitService produitService = new ProduitService();
			List<Produits> p = produitService.GetAllProduits();
			Produits prod = new Produits();

			foreach (Produits produit in p)
			{
				if (produit.LibelleProduit == pDto.LibelleProduit && produit.PrixUnitaire == pDto.PrixUnitaire && produit.Quantite == pDto.Quantite)
				{
					prod = new Produits(produit.IdProduit, produit.LibelleProduit, produit.Quantite, produit.PrixUnitaire, produit.Date);
					return prod;
				}
			}

			return prod;
		}
	}
}
