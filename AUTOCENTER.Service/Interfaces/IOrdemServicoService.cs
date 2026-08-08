using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.Interfaces
{
    public interface IOrdemServicoService : IBaseDTOService<OrdemServicoDTO>
    {
        Task<List<OrdemServicoDTO>> GetByClienteId(int clienteId);
    }
}