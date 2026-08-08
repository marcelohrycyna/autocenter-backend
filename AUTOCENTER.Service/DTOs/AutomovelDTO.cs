using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class AutomovelDTO : DTO
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }

        [MaxLength(100)]
        [JsonPropertyName("marca")]
        public string Marca { get; set; }

        [MaxLength(4)]
        [JsonPropertyName("ano")]
        public string Ano { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("cor")]
        public string Cor { get; set; }

        [MaxLength(10)]
        [JsonPropertyName("placa")]
        public string Placa { get; set; }

        [Required]
        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }


        [JsonPropertyName("cliente")]
        public Cliente? Cliente { get; set; }

        public AutomovelDTO()
        {
        }

        public AutomovelDTO(int id, string modelo, string marca, string ano, string cor, string placa, int clienteId, Cliente? cliente)
        {
            Id = id;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Cor = cor;
            Placa = placa;
            ClienteId = clienteId;
            Cliente = cliente;
        }
    }
}