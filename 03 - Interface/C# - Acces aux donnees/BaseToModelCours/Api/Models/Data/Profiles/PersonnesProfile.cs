using Api.Models.Data.DTO;
using AutoMapper;
using Api.Models.Data;

namespace Api.Models.Data.Profiles
{
	public class PersonnesProfile : Profile
	{
		public PersonnesProfile()
		{
			CreateMap<Personne, PersonnesDTO>();
			CreateMap<PersonnesDTO, Personne>();
		}
	}
}
