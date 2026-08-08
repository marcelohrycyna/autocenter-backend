using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {

        public ServicoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}