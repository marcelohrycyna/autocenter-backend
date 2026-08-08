using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Estado>> Get()
        {
            if (_context is not null)
            {
                return await _context.Set<Estado>()
                                     .Include(e => e.Pais)
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public override async Task<Estado> Get(int id)
        {
            if (_context is not null)
            {
                return await _context.Set<Estado>()
                                     .Include(e => e.Pais)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(e => e.Id == id);
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }
    }
}
