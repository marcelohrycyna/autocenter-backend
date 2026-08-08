using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository PaisRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        ICidadeRepository CidadeRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IAutomovelRepository AutomovelRepository { get; }
        IServicoRepository ServicoRepository { get; }
        IOrdemServicoRepository OrdemServicoRepository { get; }
        IOrdemServicoServicoRepository OrdemServicoServicoRepository { get; }

        Task<int> CommitAsync();
    }
}