using Api.Models.Data;
using Api.Models.Dtos;
using AutoMapper;

namespace Api.Models.Profiles
{
	public class ClientProfile : Profile
	{
		public ClientProfile()
		{
			CreateMap<Client, ClientDto>();
			CreateMap<ClientDto, Client>();
		}
	}
}
