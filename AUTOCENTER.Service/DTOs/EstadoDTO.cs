using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class EstadoDTO : DTO
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(2)]
        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        [Required]
        [JsonPropertyName("paisId")]
        public int PaisId { get; set; }


        [JsonPropertyName("pais")]
        public Pais? Pais { get; set; }

        public EstadoDTO()
        {
        }

        public EstadoDTO(int id, string nome, string sigla, int paisId, Pais? pais)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            PaisId = paisId;
            Pais = pais;
        }
    }
}