using AUTOCENTER.Service.DTOs;
using Microsoft.AspNetCore.Http;

namespace AUTOCENTER.Service.Interfaces
{
    public interface IOrdemServicoPdfService// : IBaseDTOService<OrdemServicoDTO>
    {
        public Task<IFormFileCollection> GerarPdf(int id);
    }
}