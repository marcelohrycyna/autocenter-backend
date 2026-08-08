using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class PaisDTO : DTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        

        public PaisDTO()
        {
        }

        public PaisDTO(int id, string nome, string sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }
    }
}

