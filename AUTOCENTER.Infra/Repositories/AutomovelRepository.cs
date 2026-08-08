using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class AutomovelRepository : BaseRepository<Automovel>, IAutomovelRepository
    {
        public AutomovelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Automovel>> Get()
        {
            if (_context is not null)
            {
                return await _context.Set<Automovel>()
                                     .Include(e => e.Cliente)
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public override async Task<Automovel> Get(int id)
        {
            if (_context is not null)
            {
                return await _context.Set<Automovel>()
                                     .Include(e => e.Cliente)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(e => e.Id == id);
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public async Task<List<Automovel>> GetByClienteId(int clienteId)
        {
            if (_context is not null)
            {
                return await _context.Set<Automovel>()
                                     .Include(e => e.Cliente)
                                     .Where(e => e.ClienteId == clienteId)
                                     .AsNoTracking()
                                     .ToListAsync();                       
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }
    }
}