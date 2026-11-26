using AUTOCENTER.Service.Services.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using autocenterEmailService.Contracts;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class EmailService : IEmailService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IHttpClientFactory clientFactory, ILogger<EmailService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<bool> EnviarEmail(EmailRequestDto payload)
        {
            try
            {
                var client = _clientFactory.CreateClient("EmailServiceClient");

                // Converter a coleção de arquivos binários (IFormFileCollection) para a lista de strings Base64
                var listaAnexosBase64 = new List<object>(); // Usamos um objeto anônimo compatível com o EmailAttachment do microserviço

                if (payload.Attachments != null)
                {
                    foreach (var arquivo in payload.Attachments)
                    {
                        if (arquivo != null && arquivo.Length > 0)
                        {
                            using var memoryStream = new MemoryStream();
                            await arquivo.CopyToAsync(memoryStream);
                            byte[] fileBytes = memoryStream.ToArray();

                            listaAnexosBase64.Add(new
                            {
                                FileName = arquivo.FileName ?? "documento.pdf",
                                ContentType = !string.IsNullOrWhiteSpace(arquivo.ContentType) ? arquivo.ContentType : "application/pdf",
                                Base64Content = Convert.ToBase64String(fileBytes) // Conversão feita na saída da aplicação principal
                            });
                        }
                    }
                }

                // Montar o payload final em formato JSON correspondente ao novo DTO do microserviço
                var jsonPayload = new
                {
                    Subject = payload.Subject,
                    Body = payload.Body,
                    To = payload.To,
                    Cc = payload.Cc,
                    Attachments = listaAnexosBase64
                };

                // Serializar e preparar o conteúdo HTTP como application/json
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(jsonPayload),
                    Encoding.UTF8,
                    "application/json"
                );

                // Envia o POST JSON para o microserviço
                var response = await client.PostAsync("/v1/emails/enqueue", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("E-mail e anexos convertidos para JSON enviados com sucesso para o microserviço.");
                    return true;
                }

                var erroDetalhes = await response.Content.ReadAsStringAsync();
                _logger.LogError("Falha ao encaminhar e-mail. Status: {StatusCode}. Detalhes: {Detalhes}", response.StatusCode, erroDetalhes);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro de comunicação JSON com o microserviço de e-mail.");
                return false;
            }
        }
    }
}