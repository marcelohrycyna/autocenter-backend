using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<CidadeDTO, Cidade>()
            .ForMember(dest => dest.Estado, opt => opt.Ignore())
            .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.EstadoId));

            CreateMap<Cidade, CidadeDTO>();
        }
    }
}