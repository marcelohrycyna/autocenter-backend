using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDTO, Cliente>()
            .ForMember(dest => dest.Cidade, opt => opt.Ignore())
            .ForMember(dest => dest.CidadeId, opt => opt.MapFrom(src => src.CidadeId));

            CreateMap<Cliente, ClienteDTO>();
        }
    }
}