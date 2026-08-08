using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("cliente")]
public class Cliente : BaseModel
{
    [Required]
    [MaxLength(150)]
    public string Nome { get; set; }

    [MaxLength(150)]
    public string Rua { get; set; }

    [MaxLength(150)]
    public string Numero { get; set; }

    [MaxLength(50)]
    public string Cep { get; set; }

    [MaxLength(100)]
    public string Bairro { get; set; }

    [MaxLength(150)]
    public string Complemento { get; set; }

    [MaxLength(200)]
    public string Email { get; set; }

    [MaxLength(50)]
    public string Cpf { get; set; }

    [MaxLength(50)]
    public string Telefone { get; set; }

    // Relacionamento com Cidade
    [Required]
    public int CidadeId { get; set; }

    [ForeignKey("CidadeId")]
    public virtual Cidade? Cidade { get; set; }
}