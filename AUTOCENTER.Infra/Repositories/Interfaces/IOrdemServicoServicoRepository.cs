namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IOrdemServicoServicoRepository : IBaseRepositoryWithoutId<OrdemServicoServico>
    {
        //Task<List<OrdemServicoServico>> GetByOrdemServicoId(int ordemServicoId);
        Task UpdateAll(List<OrdemServicoServico> oss);
    }
}