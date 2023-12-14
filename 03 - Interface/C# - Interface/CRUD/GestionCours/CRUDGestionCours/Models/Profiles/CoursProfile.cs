using AutoMapper;
using CRUDGestionCours.Models.Data;
using CRUDGestionCours.Models.Dtos;
using System.Linq;

namespace CRUDGestionCours.Models.Profiles
{
	public class CoursProfile : Profile
	{
		public CoursProfile()
		{
			CreateMap<Cour, CoursDtoIn>();
			CreateMap<CoursDtoIn, Cour>();

			CreateMap<Cour, CoursDtoOutSansInscription>();
			CreateMap<CoursDtoOutSansInscription, Cour>();

			CreateMap<Cour, CoursDtoOutAplatie>()
			.ForMember(ca => ca.ListEtudiantInscrit, o => o.MapFrom(c => c.Inscriptions));
			CreateMap<CoursDtoOutAplatie, Cour>();
		}
	}
}
