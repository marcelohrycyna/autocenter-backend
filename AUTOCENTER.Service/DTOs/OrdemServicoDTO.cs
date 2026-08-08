using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class OrdemServicoDTO : DTO
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("data_entrada")]
        public DateOnly DataEntrada { get; set; }

        [JsonPropertyName("data_saida")]
        public DateOnly? DataSaida { get; set; }

        [MaxLength(1000)]
        [JsonPropertyName("observacao")]
        public string Observacao { get; set; }

        [Required]
        [JsonPropertyName("fechado")]
        public bool Fechado { get; set; }

        [Required]
        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [JsonPropertyName("cliente")]
        public Cliente? Cliente { get; set; }

        [Required]
        [JsonPropertyName("automovelId")]
        public int AutomovelId { get; set; }

        [JsonPropertyName("automovel")]
        public Automovel? Automovel { get; set; }

        [JsonPropertyName("servicos")]
        public List<OrdemServicoServicoDTO?> OrdemServicoServicoDTO { get; set; } = new();

        public OrdemServicoDTO()
        {
        }

        public OrdemServicoDTO(int id, DateOnly dataEntrada, DateOnly? dataSaida, string observacao, bool fechado, int clienteId, int automovelId, Cliente? cliente, List<OrdemServicoServicoDTO?> servicos)
        {
            Id = id;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            Observacao = observacao;
            Fechado = fechado;
            ClienteId = clienteId;
            AutomovelId = automovelId;
            Cliente = cliente;
            OrdemServicoServicoDTO = servicos;
        }
    }
}