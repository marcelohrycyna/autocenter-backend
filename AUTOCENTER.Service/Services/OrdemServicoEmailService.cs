using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.Services.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using autocenterEmailService.Contracts;
using AutoMapper;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using Microsoft.Extensions.Logging;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class OrdemServicoEmailService : PdfBaseService, IOrdemServicoEmailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IClienteService _clienteService;
        private readonly IOrdemServicoPdfService _ordemServicoPdfService;
        private readonly ILogger<OrdemServicoEmailService> _logger;

        LineSeparator ls = new LineSeparator(new SolidLine());

        public OrdemServicoEmailService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IEmailService emailService,
            IClienteService clienteService,
            IOrdemServicoPdfService ordemServicoPdfService,
            ILogger<OrdemServicoEmailService> logger)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _clienteService = clienteService;
            _ordemServicoPdfService = ordemServicoPdfService;
            _logger = logger;
        }

        public async Task<bool> EnviarEmail(int clienteId, int osId)
        {
            var cliente = await _clienteService.Get(clienteId);

            var pdfs = await _ordemServicoPdfService.GerarPdf(osId);

            var destinatarios = new List<string> { /*cliente?.Email ??*/ "marcelohrycyna@hotmail.com" };

            _logger.LogInformation("Enfileirando e-mail de Ordem de Serviço para: {Destinatarios}", string.Join(", ", destinatarios));

            var emailRequestDto = new EmailRequestDto(
                Subject: "Ordem de Serviço - Autocenter",
                Body: "<h1>Segue a Ordem de Serviço em anexo</h1>",
                To: destinatarios,
                Cc: new List<string>(),

                Attachments: pdfs != null && pdfs.Count > 0 ? pdfs : null
            );

            bool sucesso = await _emailService.EnviarEmail(emailRequestDto);

            if (sucesso)
            {
                _logger.LogInformation("Ordem de serviço encaminhada para a fila do microserviço com sucesso.");
                return true;
            }
            else
            {
                _logger.LogError("Falha ao enviar a ordem de serviço para o microserviço de e-mail.");
                return false;
            }
        }
    }
}