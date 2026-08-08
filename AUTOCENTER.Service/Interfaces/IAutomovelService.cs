using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.Interfaces
{
    public interface IAutomovelService : IBaseDTOService<AutomovelDTO>
    {
        Task<List<AutomovelDTO>> GetByClienteId(int clienteId);
    }
}