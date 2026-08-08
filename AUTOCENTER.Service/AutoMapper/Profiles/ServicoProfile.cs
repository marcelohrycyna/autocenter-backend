using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<Servico, ServicoDTO>()
                .ReverseMap();
        }
    }
}