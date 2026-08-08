using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("automovel")]
public class Automovel : BaseModel
{
    [Required]
    [MaxLength(100)]
    public string Modelo { get; set; }

    [MaxLength(100)]
    public string Marca { get; set; }

    [MaxLength(4)]
    public string Ano { get; set; }

    [MaxLength(50)]
    public string Cor { get; set; }

    [MaxLength(10)]
    public string Placa { get; set; }

    // Relacionamento com Cliente
    [Required]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Cliente? Cliente { get; set; }
}