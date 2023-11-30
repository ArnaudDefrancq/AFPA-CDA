using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class MedecinProfile : Profile
	{
		public MedecinProfile()
		{
			CreateMap<Medecin, MedecinDto>();
			CreateMap<MedecinDto, Medecin>();

			CreateMap<Medecin, MedecinDtoPost>();
			CreateMap<MedecinDtoPost, Medecin>();

			CreateMap<Medecin, MedecinDtoAplatie>().ForMember(md => md.DatePrescription, o=>o.MapFrom(m => m.Prescriptions.Select(p => p.DatePrescription))).ForMember(md => md.NomMedicament, o => o.MapFrom(m => m.Prescriptions.Select(p => p.ListMedicaments.NomMedicament)));
			CreateMap<MedecinDtoAplatie, Medecin>();
		}
	}
}
