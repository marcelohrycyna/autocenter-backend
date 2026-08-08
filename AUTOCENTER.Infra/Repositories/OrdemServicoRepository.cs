using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class OrdemServicoRepository : BaseRepository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<OrdemServico>> Get()
        {
            if (_context is not null)
            {
                return await _context.OrdemServicos
                                     .Include(e => e.Cliente)
                                     .AsNoTracking()
                                     .Include(e => e.Automovel)
                                     .AsNoTracking()
                                     .Include(ss => ss.OrdemServicoServicos)
                                     .ThenInclude(s => s.Servico)
                                     .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public override async Task<OrdemServico> Get(int id)
        {
            if (_context is not null)
            {
                return await _context.OrdemServicos
                                     .Include(e => e.Cliente)
                                     .AsNoTracking()
                                     .Include(e => e.Automovel)
                                     .AsNoTracking()
                                     .Include(ss => ss.OrdemServicoServicos)
                                     .ThenInclude(s => s.Servico)
                                     .FirstOrDefaultAsync(e => e.Id == id);
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public async Task<List<OrdemServico>> GetByClienteId(int clienteId)
        {
            if (_context is not null)
            {
                return await _context.OrdemServicos
                                     .Include(e => e.Cliente)
                                     .Where(e => e.ClienteId == clienteId)
                                     .AsNoTracking()
                                     .Include(e => e.Automovel)
                                     .AsNoTracking()
                                     .Include(ss => ss.OrdemServicoServicos)
                                     .ThenInclude(s => s.Servico)
                                     .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }
    }
}