using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;


namespace CRUD.Models.Profiles
{
	public class PrescriptionProfile : Profile
	{
		public PrescriptionProfile()
		{
			CreateMap<Prescription, PrescriptionDtoOut>();
			CreateMap<PrescriptionDtoOut, Prescription>();

			CreateMap<Prescription, PrescriptionDtoIn>();
			CreateMap<PrescriptionDtoIn, Prescription>();

			CreateMap<Prescription, PrescriptionDtoOutAplatie>()
				.ForMember(pa => pa.NomMedecin, o => o.MapFrom(p => p.LeSoignant.Nom))
			.ForMember(pa => pa.PrenomMedecin, o => o.MapFrom(p => p.LeSoignant.Prenom))
			.ForMember(pa => pa.AgeMedecin, o => o.MapFrom(p => p.LeSoignant.Age))
			.ForMember(pa => pa.NomMedicament, o => o.MapFrom(p => p.LeMedicament.NomMedicament))
			.ForMember(pa => pa.NomEntreprise, o => o.MapFrom(p => p.LeMedicament.Entreprise));
			CreateMap<PrescriptionDtoOutAplatie, Prescription>();
		}
	}
}
