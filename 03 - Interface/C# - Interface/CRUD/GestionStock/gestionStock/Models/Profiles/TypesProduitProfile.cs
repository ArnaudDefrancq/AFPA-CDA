﻿using AutoMapper;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;
using System.Linq;

namespace gestionStock.Models.Profiles
{
	public class TypesProduitProfile : Profile
	{
		public TypesProduitProfile()
		{
			CreateMap<TypesProduit, TypesProduitDtoIn>();
			CreateMap<TypesProduitDtoIn, TypesProduit>();

			CreateMap<TypesProduit, TypesProduitDtoSansCategorie>();
			CreateMap<TypesProduitDtoSansCategorie, TypesProduit>();

			CreateMap<TypesProduit, TypesProduitDtoAplatie>()
			.ForMember(tpa => tpa.AllCategories, o => o.MapFrom(tp => tp.LesCategories));

			CreateMap<TypesProduitDtoAplatie, TypesProduit>();
		}
	}
}
