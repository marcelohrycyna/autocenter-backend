using AutoMapper;
using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.AutoMapper.Profiles
{
    public class OrdemServicoProfile : Profile
    {
        /*public OrdemServicoProfile()
        {
            CreateMap<OrdemServicoDTO, OrdemServico>()
            .ForMember(dest => dest.Cliente, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.Automovel, opt => opt.Ignore())
            .ForMember(dest => dest.AutomovelId, opt => opt.MapFrom(src => src.AutomovelId));

            CreateMap<OrdemServico, OrdemServicoDTO>();
        }*/
        public OrdemServicoProfile()
        {
            // 1. Mapeamento dos itens da lista (DTO para Entidade de ligação)
            CreateMap<OrdemServicoServicoDTO, OrdemServicoServico>()
                .ForMember(dest => dest.ServicoId, opt => opt.MapFrom(src => src.ServicoId))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.ValorUnitario, opt => opt.MapFrom(src => src.ValorUnitario))
                //.ForMember(dest => dest.OrdemServicoId, opt => opt.Ignore())
                .ForMember(dest => dest.OrdemServicoId, opt =>
                {
                    opt.Condition(src => src.OrdemServicoId > 0);
                    opt.MapFrom(src => src.OrdemServicoId);
                })
                .ForMember(dest => dest.OrdemServico, opt => opt.Ignore())
                .ForMember(dest => dest.Servico, opt => opt.Ignore());

            // 2. Mapeamento da Ordem de Serviço (DTO para Entidade)
            CreateMap<OrdemServicoDTO, OrdemServico>()
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Automovel, opt => opt.Ignore())
                // Mapeia automaticamente a lista de DTOs para a lista da tabela de ligação
                .ForMember(dest => dest.OrdemServicoServicos, opt => opt.MapFrom(src => src.OrdemServicoServicoDTO));

            // 3. Mapeamento reverso (Entidade para DTO - opcional para retorno da API)
            CreateMap<OrdemServico, OrdemServicoDTO>()
                .ForMember(dest => dest.OrdemServicoServicoDTO, opt => opt.MapFrom(src => src.OrdemServicoServicos));

            CreateMap<OrdemServicoServico, OrdemServicoServicoDTO>();
        }
    }
}