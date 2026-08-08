using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pais")]
public class Pais : BaseModel
{
    [Required]
    [MaxLength(200)]
    public string Nome { get; set; }

    [Required]
    [StringLength(2)]
    public string Sigla { get; set; } // ISO 3166-1 alpha-2
}