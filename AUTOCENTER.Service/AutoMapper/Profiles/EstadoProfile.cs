using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class EstadoProfile : Profile
    {
        public EstadoProfile()
        {
            CreateMap<EstadoDTO, Estado>()
            .ForMember(dest => dest.Pais, opt => opt.Ignore())
            .ForMember(dest => dest.PaisId, opt => opt.MapFrom(src => src.PaisId));

            CreateMap<Estado, EstadoDTO>();
        }
    }
}