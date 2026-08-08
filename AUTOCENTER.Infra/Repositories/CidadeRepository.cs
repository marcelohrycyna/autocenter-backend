using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Cidade>> Get()
        {
            if (_context is not null)
            {
                return await _context.Set<Cidade>()
                                     .Include(e => e.Estado)
                                     .ThenInclude(estado => estado.Pais)
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public override async Task<Cidade> Get(int id)
        {
            if (_context is not null)
            {
                return await _context.Set<Cidade>()
                                     .Include(e => e.Estado)
                                     .ThenInclude(estado => estado.Pais)
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