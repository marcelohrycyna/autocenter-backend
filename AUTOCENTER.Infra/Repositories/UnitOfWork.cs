using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPaisRepository PaisRepository { get; }
        public IEstadoRepository EstadoRepository { get; }
        public ICidadeRepository CidadeRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IAutomovelRepository AutomovelRepository { get; }

        public IServicoRepository ServicoRepository { get; }
        public IOrdemServicoRepository OrdemServicoRepository { get; }
        public IOrdemServicoServicoRepository OrdemServicoServicoRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PaisRepository = new PaisRepository(_context);
            EstadoRepository = new EstadoRepository(_context);
            CidadeRepository = new CidadeRepository(_context);
            ClienteRepository = new ClienteRepository(_context);
            AutomovelRepository = new AutomovelRepository(_context);
            ServicoRepository = new ServicoRepository(_context);
            OrdemServicoRepository = new OrdemServicoRepository(_context);
            OrdemServicoServicoRepository = new OrdemServicoServicoRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}