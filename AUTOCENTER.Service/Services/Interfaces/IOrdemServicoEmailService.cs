namespace AUTOCENTER.Service.Services.Interfaces
{
    public interface IOrdemServicoEmailService
    {
        public Task<bool> EnviarEmail(int clienteId, int osId);
    }
}