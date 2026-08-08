using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Cliente>> Get()
        {
            if (_context is not null)
            {
                return await _context.Set<Cliente>()
                                     .Include(e => e.Cidade)
                                     .ThenInclude(cidade => cidade.Estado)
                                     .Include(e => e.Cidade.Estado)
                                     .ThenInclude(estado => estado.Pais)
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public override async Task<Cliente> Get(int id)
        {
            if (_context is not null)
            {
                return await _context.Set<Cliente>()
                                     .Include(e => e.Cidade)
                                     .ThenInclude(cidade => cidade.Estado)
                                     .Include(e => e.Cidade.Estado)
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