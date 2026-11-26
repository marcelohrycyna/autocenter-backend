using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.Services.Interfaces;
using AUTOCENTER.Utils;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class OrdemServicoPdfService : PdfBaseService, IOrdemServicoPdfService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdemServicoPdfService> _logger; 

        LineSeparator ls = new LineSeparator(new SolidLine());

        public OrdemServicoPdfService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OrdemServicoPdfService> logger)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IFormFileCollection> GerarPdf(int osId)
        {
            _logger.LogInformation("Iniciando a geração do PDF para a Ordem de Serviço ID: {Id}", osId);
            var os = await GetOs(osId);

            var formfile = await CriarPdf(os);
            return formfile;
        }

        private async Task<OrdemServico> GetOs(int id)
        {
            var os = await _uow.OrdemServicoRepository.Get(id);
            return os;
        }


        private async Task<IFormFileCollection> CriarPdf(OrdemServico os)
        {
            CriarDocumento();

            _documento?.Add(CriarCabecalhoPadrao());
            _documento?.Add(ls);

            _documento?.Add(CriarSubCabecalhoPadrao(StringResource.TextoSubCabecalhoOrdemServicoPdf(os.Id.ToString())));
            _documento?.Add(ls);

            if (os.Cliente is not null)
            {
                _documento?.Add(CriarClientePadrao(os.Cliente));
            }
            _documento?.Add(ls);

            if (os.Automovel is not null)
            {
                _documento?.Add(CriarAutomovelPadrao(os.Automovel));
            }
            _documento?.Add(ls);

            _documento?.Add(CriarSubCabecalhoPadrao(StringResource.Servicos));
            _documento?.Add(ls);

            {
                _documento?.Add(CriarTabelaServicos(os.OrdemServicoServicos));
            }

            FecharDocumento();

            // Garanta que a sua MemoryStream original volte para a posição zero para ser lida por completo
            if (_memoryStream!.CanSeek)
            {
                _memoryStream.Position = 0;
            }

            // Crie o FormFile diretamente a partir do _memoryStream
            var formFile = new FormFile(
                baseStream: _memoryStream,
                baseStreamOffset: 0,
                length: _memoryStream.Length,
                name: "Files",
                fileName: "OrdemServico.pdf"
            )
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            };

            var formFileCollection = new FormFileCollection();
            formFileCollection.Add(formFile);

            return formFileCollection;
        }

        private Table CriarTabelaServicos(ICollection<OrdemServicoServico> ordemServicoServicos)
        {
            var tabServicos = CriarTabelaPadrao(4);

            CriarCabecalhoTabelaServicos(tabServicos);

            if (ordemServicoServicos is not null && ordemServicoServicos.Count > 0)
            {
                foreach (var servico in ordemServicoServicos)
                {
                    PreencherServicoNaTabelaServicos(tabServicos, servico);
                }

                tabServicos.AddCell(CriarCelulaEmBrancoPadrao(4));
                PreencherValorTotalNaTabelaServicos(tabServicos, ordemServicoServicos.Sum(p => p.ValorTotal));
            }
            else
            {
                CriarCelulaSemRegistroPadrao(tabServicos);
            }

            return tabServicos;
        }

        private void PreencherServicoNaTabelaServicos(Table tabServicos, OrdemServicoServico servico)
        {
            var celServico = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: servico.Servico.Tipo,
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabServicos.AddCell(celServico);

            var celQtde = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: servico.Quantidade.ToString(),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabServicos.AddCell(celQtde);

            var celValorUnit = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: servico.ValorUnitario.ToString(),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabServicos.AddCell(celValorUnit);

            var celValorTotal = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: servico.ValorTotal.ToString(),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabServicos.AddCell(celValorTotal);
        }

        private void PreencherValorTotalNaTabelaServicos(Table tabServicos, decimal total)
        {
            var celServico = CriarCelulaPadraoNegrito(
                celula: new Cell(1, 4),
                texto: "Total: " + total
            );
            tabServicos.AddCell(celServico);
        }

        private void CriarCabecalhoTabelaServicos(Table tabServicos)
        {
            var cabServico = CriarCelulaPadraoNegrito(
                celula: new Cell(1, 1),
                texto: "Serviço"
            );
            tabServicos.AddCell(cabServico);

            var cabQtde = CriarCelulaPadraoNegrito(
                celula: new Cell(1, 1),
                texto: "Qtde"
            );
            tabServicos.AddCell(cabQtde);

            var cabValorUnit = CriarCelulaPadraoNegrito(
                celula: new Cell(1, 1),
                texto: "Valor Unit"
            );
            tabServicos.AddCell(cabValorUnit);

            var cabValorTotal = CriarCelulaPadraoNegrito(
                celula: new Cell(1, 1),
                texto: "Valor Total"
            );
            tabServicos.AddCell(cabValorTotal);
        }
    }
}