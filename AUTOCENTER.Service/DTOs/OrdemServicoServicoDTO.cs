using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class OrdemServicoServicoDTO : DTO
    {
        [Required]
        [JsonPropertyName("ordem_servicoId")]
        public int OrdemServicoId { get; set; }

        [Required]
        [JsonPropertyName("servicoId")]
        public int ServicoId { get; set; }

        [Required]
        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [Required]
        [JsonPropertyName("valor_unitario")]
        public Decimal ValorUnitario { get; set; }

        [Required]
        [JsonPropertyName("valor_total")]
        public Decimal ValorTotal { get; set; }

        [JsonPropertyName("servico")]
        public string? Servico { get; set; }

        public OrdemServicoServicoDTO()
        {
        }

        public OrdemServicoServicoDTO(int ordemServicoId, int servicoId, int quantidade, Decimal valorUnitario, Decimal valorTotal, string? servico)
        {
            OrdemServicoId = ordemServicoId;
            ServicoId = servicoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
            Servico = servico;
        }
    }
}