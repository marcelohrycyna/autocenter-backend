using Microsoft.AspNetCore.Http;

namespace AUTOCENTER.Service.Services.Interfaces
{
    public interface IOrdemServicoPdfService
    {
        public Task<IFormFileCollection> GerarPdf(int osId);
    }
}