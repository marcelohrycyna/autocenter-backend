using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories
{
    [Scoped]
    public class OrdemServicoServicoRepository : BaseRepositoryWithoutId<OrdemServicoServico>, IOrdemServicoServicoRepository
    {
        public OrdemServicoServicoRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public async Task UpdateAll(List<OrdemServicoServico> oss)
        {
            if (_context is not null && oss != null && oss.Count > 0)
            {
                var osId = oss.Select(x => x.OrdemServicoId).FirstOrDefault();
                List<OrdemServicoServico> servicosDaOs = await GetByOsId(osId);

                await DeleteRange(servicosDaOs);
                await _context.SaveChangesAsync();

                await CreateRange(oss);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        //Métodos Privados
        private async Task<List<OrdemServicoServico>> GetByOsId(int osId)
        {
            if (_context is not null)
            {
                return await _context.OrdemServicoServicos
                                     .Where(e => e.OrdemServicoId == osId)
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