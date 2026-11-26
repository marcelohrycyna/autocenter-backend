using autocenterEmailService.Contracts;

namespace AUTOCENTER.Service.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(EmailRequestDto payload);
    }
}