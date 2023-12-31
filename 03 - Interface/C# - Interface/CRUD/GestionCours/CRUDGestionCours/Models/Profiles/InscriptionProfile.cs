﻿using AutoMapper;
using CRUDGestionCours.Models.Data;
using CRUDGestionCours.Models.Dtos;

namespace CRUDGestionCours.Models.Profiles
{
	public class InscriptionProfile : Profile
	{
		public InscriptionProfile()
		{
			CreateMap<Inscription, InscriptionDtoIn>();
			CreateMap<InscriptionDtoIn, Inscription>();

			CreateMap<Inscription, InscriptionDtoSansCours>();
			CreateMap<InscriptionDtoSansCours, Inscription>();

			CreateMap<Inscription, InscriptionDtoSansEtudiant>();
			CreateMap<InscriptionDtoSansEtudiant, Inscription>();

			CreateMap<Inscription, InscriptionDtoOutAplatie>()
				.ForMember(ia => ia.IdCours, o => o.MapFrom(i => i.LeCours.IdCours))
				.ForMember(ia => ia.NomCours, o => o.MapFrom(i => i.LeCours.Nom))
				.ForMember(ia => ia.DescriptionCours, o => o.MapFrom(i => i.LeCours.Description))
				.ForMember(ia => ia.IdEtudiant, o => o.MapFrom(i => i.LeEtudiant.IdEtudiants))
				.ForMember(ia => ia.NomEtudiant, o => o.MapFrom(i => i.LeEtudiant.Nom))
				.ForMember(ia => ia.PrenomEtudiant, o => o.MapFrom(i => i.LeEtudiant.Prenom));
			CreateMap<InscriptionDtoOutAplatie, Inscription>();
		}
	}
}
