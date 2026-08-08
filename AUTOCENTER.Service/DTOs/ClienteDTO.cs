using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AUTOCENTER.Service.DTOs
{
    public class ClienteDTO : DTO
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [MaxLength(150)]
        [JsonPropertyName("rua")]
        public string Rua { get; set; }

        [MaxLength(150)]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [MaxLength(100)]
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [MaxLength(150)]
        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [MaxLength(200)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [Required]
        [JsonPropertyName("cidadeId")]
        public int CidadeId { get; set; }


        [JsonPropertyName("cidade")]
        public Cidade? Cidade { get; set; }

        public ClienteDTO()
        {
        }

        public ClienteDTO(int id, string nome, string rua, string numero, string cep, string bairro, string complemento, string email, string cpf, string telefone, int cidadeId, Cidade? cidade)
        {
            Id = id;
            Nome = nome;
            Rua = rua;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Complemento = complemento;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            CidadeId = cidadeId;
            Cidade = cidade;
        }
    }
}