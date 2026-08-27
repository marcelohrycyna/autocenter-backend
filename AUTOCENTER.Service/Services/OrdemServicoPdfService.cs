using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class OrdemServicoPdfService : PdfBaseService, IOrdemServicoPdfService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        LineSeparator ls = new LineSeparator(new SolidLine());


        public OrdemServicoPdfService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IFormFileCollection> GerarPdf(int id)
        {
            var os = await _uow.OrdemServicoRepository.Get(id);
            CriarDocumento();

            _documento.Add(CriarCabecalhoPadrao());
            _documento.Add(ls);

            _documento.Add(CriarSubCabecalhoPadrao(StringResource.TextoSubCabecalhoOrdemServicoPdf(os.Id.ToString())));
            _documento.Add(ls);

            if (os.Cliente is not null)
            {
                _documento.Add(CriarClientePadrao(os.Cliente));
            }
            _documento.Add(ls);

            if (os.Automovel is not null)
            {
                _documento.Add(CriarAutomovelPadrao(os.Automovel));
            }
            _documento.Add(ls);

            _documento.Add(CriarSubCabecalhoPadrao(StringResource.Servicos));
            _documento.Add(ls);

            {
                _documento.Add(CriarTabelaServicos(os.OrdemServicoServicos));
            }

            FecharDocumento();

            FileStreamResult fileStreamResult = new FileStreamResult(_memoryStream, "application/pdf");

            fileStreamResult.FileDownloadName = "OrdemServico.pdf";
            var formFile = new FormFile(fileStreamResult.FileStream, 0, fileStreamResult.FileStream.Length, "fileStreamAta", fileStreamResult.FileDownloadName);
            
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