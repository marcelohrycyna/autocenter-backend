using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class AutomovelProfile : Profile
    {
        public AutomovelProfile()
        {
            CreateMap<AutomovelDTO, Automovel>()
            .ForMember(dest => dest.Cliente, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId));

            CreateMap<Automovel, AutomovelDTO>();
        }
    }
}