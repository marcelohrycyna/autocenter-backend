namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IOrdemServicoServicoRepository : IBaseRepositoryWithoutId<OrdemServicoServico>
    {
        Task UpdateAll(List<OrdemServicoServico> oss);
    }
}