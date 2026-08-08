using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class CidadeDTO : DTO
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Required]
        [JsonPropertyName("estadoId")]
        public int EstadoId { get; set; }


        [JsonPropertyName("estado")]
        public Estado? Estado { get; set; }

        public CidadeDTO()
        {
        }

        public CidadeDTO(int id, string nome, int estadoId, Estado? estado)
        {
            Id = id;
            Nome = nome;
            EstadoId = estadoId;
            Estado = estado;
        }
    }
}