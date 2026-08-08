using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {

        public PaisRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}