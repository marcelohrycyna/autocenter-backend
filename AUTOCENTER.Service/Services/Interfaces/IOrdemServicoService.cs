using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.Services.Interfaces
{
    public interface IOrdemServicoService : IBaseDTOService<OrdemServicoDTO>
    {
        Task<List<OrdemServicoDTO>> GetByStatus(bool? status);
        Task<List<OrdemServicoDTO>> GetByClienteId(int clienteId);
    }
}