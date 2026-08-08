using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class ServicoDTO : DTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("valor")]
        public Decimal Valor { get; set; }



        public ServicoDTO()
        {
        }

        public ServicoDTO(int id, string tipo, string descricao, Decimal valor)
        {
            Id = id;
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
        }
    }
}

