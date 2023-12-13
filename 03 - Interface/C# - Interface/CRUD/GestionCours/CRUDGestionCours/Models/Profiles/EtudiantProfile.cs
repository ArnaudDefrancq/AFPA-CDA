using AutoMapper;
using CRUDGestionCours.Models.Data;
using CRUDGestionCours.Models.Dtos;
using System.Linq;

namespace CRUDGestionCours.Models.Profiles
{
	public class EtudiantProfile : Profile
	{
		public EtudiantProfile()
		{
			CreateMap<Etudiant, EtudiantDtoIn>();
			CreateMap<EtudiantDtoIn, Etudiant>();

			CreateMap<Etudiant, EtudiantDtoOutSansInscription>();
			CreateMap<EtudiantDtoOutSansInscription, Etudiant>();

			CreateMap<Etudiant, EtudiantDtoOutAplatie>()
				.ForMember(ea => ea.Inscriptions, o => o.MapFrom(e => e.Inscriptions.Select(i => i.LeCours)));
			CreateMap<EtudiantDtoOutAplatie, Etudiant>();
		}
	}
}
