namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IOrdemServicoRepository : IBaseRepository<OrdemServico>
    {
        Task<List<OrdemServico>> GetByStatus(bool? status);
        Task<List<OrdemServico>> GetByClienteId(int clienteId);
    }
}