using AutoMapper;
using AUTOCENTER.Service.DTOs;
using Microsoft.Data.SqlClient;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class OrdemServicoServicoProfile : Profile
    {
        public OrdemServicoServicoProfile()
        {
            CreateMap<OrdemServicoServico, OrdemServicoServicoDTO>()
                .ForMember(dest => dest.Servico, opt => opt.MapFrom(src => src.Servico.Tipo))
                .ForMember(dest => dest.OrdemServicoId, opt => opt.MapFrom(src => src.OrdemServico.Id));

            CreateMap<OrdemServicoServico, OrdemServicoServicoDTO>();
        }
    }
}