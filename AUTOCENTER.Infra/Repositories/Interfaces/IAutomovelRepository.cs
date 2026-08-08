namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IAutomovelRepository : IBaseRepository<Automovel>
    {
        Task <List<Automovel>>GetByClienteId(int clienteId);
    }
}