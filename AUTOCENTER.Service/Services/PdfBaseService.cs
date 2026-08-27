using AUTOCENTER.Utils;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUTOCENTER.Service.Services
{
    public class PdfBaseService : IDisposable
    {
        public const string LOGO = "logo.png";

        protected float _tamanhoDaFonte = 11F;
        protected float _tamanhoDaFonteCabecalho = 24F;
        protected float _tamanhoDaFonteCabecalhoDados = 14F;
        protected float _espacoCaracter = 0.5F;
        protected MemoryStream _memoryStream;
        protected PdfDocument _pdfDoc;
        protected Document _documento;
        protected readonly LineSeparator _linhaSeparadora = new(new SolidLine());

        protected PdfBaseService() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void CriarDocumento(PageSize pageSize, bool immediateFlush)
        {
            _memoryStream = new MemoryStream();
            var writer = new PdfWriter(_memoryStream);
            _pdfDoc = new PdfDocument(writer);
            _documento = new Document(_pdfDoc, pageSize, immediateFlush);

            writer.SetCloseStream(false);
        }

        protected virtual void CriarDocumento()
        {
            CriarDocumento(PageSize.A4, false);
        }

        protected virtual void FecharDocumento()
        {
            _documento.Close();

            byte[] byteInfo = _memoryStream.ToArray();

            _memoryStream.Write(byteInfo, 0, byteInfo.Length);
            _memoryStream.Position = 0;
        }

        protected virtual IFormFile ObterArquivo(string nomeDoArquivo)
        {
            var fsAquivo = new FileStreamResult(_memoryStream, "application/pdf")
            {
                FileDownloadName = nomeDoArquivo
            };

            return new FormFile(
                fsAquivo.FileStream,
                baseStreamOffset: 0,
                fsAquivo.FileStream.Length,
                Guid.NewGuid().ToString(),
                fsAquivo.FileDownloadName
            );
        }

        protected virtual void AdicionarLinhaSeparadora()
        {
            _documento.Add(_linhaSeparadora);
        }

        protected virtual Table CriarCabecalhoPadrao()//string titulo, string empresaNome, string empresaCor, int numeroDeLinhas)
        {
            var tabCabecalho = CriarTabelaPadrao(3);

            var imgLogo = CriarImagem(LOGO, 70, 34);
            var celLogo = new Cell(3, 1)
                .Add(imgLogo)
                .SetBorder(Border.NO_BORDER);
            tabCabecalho.AddCell(celLogo);

            var celNomeAutoCenter = CriarCelulaCabecalho(
                celula: new Cell(1, 2),
                texto: StringResource.NomeAutoCenter,
                tamanhoDaFonte: _tamanhoDaFonteCabecalho
            );
            tabCabecalho.AddCell(celNomeAutoCenter);

            var celEndereçoAutoCenter = CriarCelulaCabecalho(
                celula: new Cell(1, 2),
                texto: StringResource.EnderecoAutoCenter,
                tamanhoDaFonte: _tamanhoDaFonteCabecalhoDados
            );
            tabCabecalho.AddCell(celEndereçoAutoCenter);

            var celTelefoneAutoCenter = CriarCelulaCabecalho(
                celula: new Cell(1, 2),
                texto: StringResource.TelefoneAutoCenter,
                tamanhoDaFonte: _tamanhoDaFonteCabecalhoDados
            );
            tabCabecalho.AddCell(celTelefoneAutoCenter);

            //var celTitulo = CriarCelulaCabecalho(titulo);
            //tabCabecalho.AddCell(celTitulo);
            //CriarEmpresaCabecalho(empresaNome, empresaCor, tabCabecalho);

            return tabCabecalho;
        }

        protected virtual Table CriarSubCabecalhoPadrao(string texto)
        {
            var tabSubCabecalho = CriarTabelaPadrao(1);

            var celTexto = CriarCelulaCabecalho(
                celula: new Cell(1, 3),
                texto: texto,
                tamanhoDaFonte: _tamanhoDaFonteCabecalhoDados
            );
            tabSubCabecalho.AddCell(celTexto);


            return tabSubCabecalho;
        }

        protected virtual Table CriarClientePadrao(Cliente cliente)
        {
            var tabCliente = CriarTabelaPadrao(3);

            var celNome = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: StringResource.NomeCliente(cliente.Nome),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabCliente.AddCell(celNome);

            var celCpf = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: StringResource.Cpf(cliente.Cpf),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabCliente.AddCell(celCpf);

            var celTelefone = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: StringResource.TelefoneCliente(cliente.Telefone),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabCliente.AddCell(celTelefone);


            return tabCliente;
        }

        protected virtual Table CriarAutomovelPadrao(Automovel automovel)
        {
            var tabAutomovel = CriarTabelaPadrao(2);

            var celMOdelo = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: StringResource.ModeloAutomovel(automovel.Modelo),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabAutomovel.AddCell(celMOdelo);

            var celPlaca = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: StringResource.PlacaAutomovel(automovel.Placa),
                tamanhoDaFonte: _tamanhoDaFonte
            );
            tabAutomovel.AddCell(celPlaca);

            return tabAutomovel;
        }

        protected virtual void CriarCelulaSemRegistroPadrao(Table table)
        {
            var cel = CriarCelulaPadrao(
                celula: new Cell(1, 1),
                texto: StringResource.SemRegistros,
                tamanhoDaFonte: _tamanhoDaFonte
            );
            table.AddCell(cel);
        }

        protected virtual Cell CriarCelulaEmBrancoPadrao(int numColunas)
        {
            var cel = CriarCelulaPadrao(
                celula: new Cell(1, numColunas),
                texto: "",
                tamanhoDaFonte: _tamanhoDaFonte
            );
            return cel;
        }

        protected virtual void Dispose(bool invocarDispose)
        {
            ((IDisposable)_memoryStream)?.Dispose();
            ((IDisposable)_pdfDoc)?.Dispose();
            ((IDisposable)_documento)?.Dispose();
        }

        protected static Image CriarImagem(string caminho, float fitWidth, float fitHeight)
        {
            var img = new Image(ImageDataFactory.Create(caminho));
            img.ScaleAbsolute(fitWidth, fitHeight);

            return img;
        }

        //#region Célula
        protected Cell CriarCelulaPadrao(
            Cell celula,
            float tamanhoDaFonte,
            TextAlignment alinhamento,
            string texto,
            bool negrito
        )
        {
            var celulaFormatada = celula
                .SetTextAlignment(alinhamento)
                .SetFontSize(tamanhoDaFonte)
                .SetCharacterSpacing(_espacoCaracter)
                .SetBorder(Border.NO_BORDER);

            if (texto is not null)
            {
                var paragrafo = new Paragraph(texto);
                if (negrito)
                {
                    PdfFont fonteNegrito = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    paragrafo.SetFont(fonteNegrito);
                }
                celulaFormatada.Add(paragrafo);
            }

            return celulaFormatada;
        }

        protected Cell CriarCelulaPadrao(
            Cell celula,
            TextAlignment alinhamento,
            string texto,
            bool negrito
        )
        {
            return CriarCelulaPadrao(
                celula,
                _tamanhoDaFonte,
                alinhamento,
                texto,
                negrito
            );
        }

        protected Cell CriarCelulaPadrao(
            Cell celula,
            TextAlignment alinhamento,
            string texto
        )
        {
            return CriarCelulaPadrao(
                celula,
                _tamanhoDaFonte,
                alinhamento,
                texto,
                negrito: false
            );
        }

        protected Cell CriarCelulaPadrao(TextAlignment alinhamento, string texto)
        {
            return CriarCelulaPadrao(
                new Cell(),
                alinhamento,
                texto
            );
        }

        protected Cell CriarCelulaPadrao(Cell celula, float tamanhoDaFonte, string texto)
        {
            return CriarCelulaPadrao(
                celula,
                tamanhoDaFonte,
                alinhamento: TextAlignment.LEFT,
                texto,
                negrito: false
            );
        }

        protected Cell CriarCelulaPadrao(float tamanhoDaFonte, string texto)
        {
            return CriarCelulaPadrao(
                celula: new Cell(),
                tamanhoDaFonte,
                alinhamento: TextAlignment.LEFT,
                texto,
                negrito: false
            );
        }

        protected Cell CriarCelulaPadrao(Cell celula, string texto)
        {
            return CriarCelulaPadrao(
                celula,
                alinhamento: TextAlignment.LEFT,
                texto,
                negrito: false
            );
        }

        protected Cell CriarCelulaPadrao(string texto, float tamanhoPercentual)
        {
            var celula = new Cell().SetWidth(UnitValue.CreatePercentValue(tamanhoPercentual));

            return CriarCelulaPadrao(
                celula,
                alinhamento: TextAlignment.LEFT,
                texto,
                negrito: false
            );
        }

        protected Cell CriarCelulaPadrao(string texto)
        {
            return CriarCelulaPadrao(
                celula: new Cell(),
                alinhamento: TextAlignment.LEFT,
                texto,
                negrito: false
            );
        }

        protected Cell CriarCelulaPadraoNegrito(Cell celula, TextAlignment alinhamento, string texto)
        {
            return CriarCelulaPadrao(
                celula,
                alinhamento,
                texto,
                negrito: true
            );
        }

        protected Cell CriarCelulaPadraoNegrito(Cell celula, float tamanhoDaFonte, string texto, TextAlignment? alinhamento)
        {
            return CriarCelulaPadrao(
                celula,
                tamanhoDaFonte,
                alinhamento: alinhamento ?? TextAlignment.LEFT,
                texto,
                negrito: true
            );
        }

        protected Cell CriarCelulaPadraoNegrito(Cell celula, string texto)
        {
            return CriarCelulaPadraoNegrito(
                celula,
                alinhamento: TextAlignment.LEFT,
                texto
            );
        }

        protected Cell CriarCelulaPadraoNegrito(float tamanhoDaFonte, string texto)
        {
            return CriarCelulaPadraoNegrito(new Cell(), tamanhoDaFonte, texto, null);
        }

        protected Cell CriarCelulaPadraoNegrito(TextAlignment alinhamento, string texto)
        {
            return CriarCelulaPadraoNegrito(celula: new Cell(), alinhamento, texto);
        }

        protected Cell CriarCelulaPadraoNegrito(string texto)
        {
            return CriarCelulaPadraoNegrito(new Cell(), texto);
        }

        protected Cell CriarCelulaPadraoNegrito(string texto, float tamanhoPercentual)
        {
            var celula = new Cell().SetWidth(UnitValue.CreatePercentValue(tamanhoPercentual));

            return CriarCelulaPadraoNegrito(celula, texto);
        }

        protected Cell CriarCelulaCabecalho(Cell celula, string texto)
        {
            return CriarCelulaPadraoNegrito(celula, _tamanhoDaFonteCabecalho, texto, TextAlignment.CENTER);
        }

        protected Cell CriarCelulaCabecalho(Cell celula, string texto, float tamanhoDaFonte)
        {
            return CriarCelulaPadraoNegrito(celula, tamanhoDaFonte, texto, TextAlignment.CENTER);
        }

        protected Cell CriarCelulaCabecalho(string texto)
        {
            return CriarCelulaCabecalho(new Cell(), texto);

        }

        protected Cell CriarCelulaCabecalho(TextAlignment alinhamento, string texto)
        {
            return CriarCelulaPadrao(
                new Cell(),
                _tamanhoDaFonteCabecalho,
                alinhamento,
                texto,
                negrito: true
            );
        }


        protected Cell CriarCelulaComFundo(
            TextAlignment alinhamento,
            string texto,
            Color corFundo,
            int rowspan = 1,
            int colspan = 1,
            bool negrito = false
        )
        {
            var celula = new Cell(rowspan, colspan)
                .SetBackgroundColor(corFundo);

            return CriarCelulaPadrao(celula, alinhamento, texto, negrito);
        }

        protected Cell CriarCelulaComFundo(
            string texto,
            Color corFundo,
            int rowspan = 1,
            int colspan = 1,
            bool negrito = false
        )
        {
            return CriarCelulaComFundo(
                alinhamento: TextAlignment.LEFT,
                texto,
                corFundo,
                rowspan,
                colspan,
                negrito
            );
        }

        protected Cell CriarCelulaNegritoComFundo(
            TextAlignment alinhamento,
            string texto,
            Color corFundo,
            int rowspan = 1,
            int colspan = 1
        )
        {
            return CriarCelulaComFundo(
                alinhamento,
                texto,
                corFundo,
                rowspan,
                colspan,
                negrito: true
            );
        }

        protected Cell CriarCelulaNegritoComFundo(
            string texto,
            Color corFundo,
            int rowspan = 1,
            int colspan = 1
        )
        {
            return CriarCelulaNegritoComFundo(
                alinhamento: TextAlignment.LEFT,
                texto,
                corFundo,
                rowspan,
                colspan
            );
        }

        protected static Table CriarTabelaPadrao(int colunas, bool? manterConteudoJunto = null, float larguraEmPercentagem = 100)
        {
            var tab = new Table(colunas, false)
                .SetWidth(CriarUnidadePorcentagem(larguraEmPercentagem));

            if (manterConteudoJunto.HasValue)
            {
                tab.SetKeepTogether(manterConteudoJunto.Value);
            }

            return tab;
        }


        protected static Color CriarCor(string hex)
        {
            return WebColors.GetRGBColor(hex);
        }

        protected static SolidBorder CriarBorda(Color cor)
        {
            return new SolidBorder(cor, 1);
        }

        protected static SolidBorder CriarBordaColorida(string hex)
        {
            Color cor = CriarCor(hex);

            return CriarBorda(cor);
        }

        protected static UnitValue CriarUnidadePorcentagem(float value)
        {
            return UnitValue.CreatePercentValue(value);
        }

        protected static string RetornaNASeStringForNula(string valor)
        {
            return string.IsNullOrEmpty(valor) ? "N/A" : valor;
        }

        protected static string RetornaSimNaoSeTrueFalse(bool valor)
        {
            return valor ? "Sim" : "Não";
        }
    }
}