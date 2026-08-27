using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AUTOCENTER.Utils
{
    public static class StringResource
    {

        #region BasePdf
        public const string NomeAutoCenter = "AutoCenter 1";
        public const string EnderecoAutoCenter = "Rua da Silva, 858 - Bairro Capela Velha - Araucária/Pr";
        public const string TelefoneAutoCenter = "41 9876-1245";
        public const string SemRegistros = "Não foram encontrados registros";
        public static string Cpf(string cpf) =>
            $"Cpf: {cpf}";
        public static string NomeCliente(string nomeCliente) =>
            $"Cliente: {nomeCliente}";
        public static string TelefoneCliente(string telefoneCliente) =>
            $"Telefone: {telefoneCliente}";
        public static string ModeloAutomovel(string modeloAutomovel) =>
            $"Modelo: {modeloAutomovel}";
        public static string PlacaAutomovel(string placaAutomovel) =>
            $"Placa: {placaAutomovel}";



        #endregion BasePdf

        #region OrdemServicoPdf
        public static string TextoSubCabecalhoOrdemServicoPdf(string texto) =>
            $"Ordem de Serviço Nº {texto}";
        public const string Servicos = "Serviços";

        #endregion OrdemServicoPdf


        public static string TamanhoDoArquivoExcedeTamanhoLimite(string nomeArquivo)
            => $"Tamanho do arquivo: {nomeArquivo} ultrapassa o limite de 15MB";
        

        public static string RefContratualExistente(string refContratual) =>
            $"Referencia Contratual \"{refContratual}\" já está cadastrada no sistema";

        

        #region AtaPautaRQOPE
        public const string AtaPautaRQOPEErroEmailPautaRQOPE = "Erro ao enviar o e-mail da Pauta RQOPE";
        public const string AtaPautaRQOPEErroPdfRelatorioRQOPE = "Erro ao Gerar o PDF do Relatorio Operacional da Qualidade";
        public const string AtaPautaRQOPEErroPdfPauta = "Erro ao Gerar o PDF da Pauta";
        public const string AtaPautaRQOPEErroEmailPendencias = "Erro ao enviar os e-mails das Pendências";





        #endregion AtaPautaRQOPE
    }
}
