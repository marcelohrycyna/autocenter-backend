using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<Pais, PaisDTO>()
                .ReverseMap();
        }
    }
}