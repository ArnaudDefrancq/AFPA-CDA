using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class MedicamentProfile : Profile
	{
		public MedicamentProfile()
		{
			CreateMap<Medicament, MedicamentDto>();
			CreateMap<MedicamentDto, Medicament>();

			CreateMap<Medicament, MedicamentDtoOutPrescription>();
			CreateMap<MedicamentDtoOutPrescription, Medicament>();
		}
	}
}
