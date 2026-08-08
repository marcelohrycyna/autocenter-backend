using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("estado")]
public class Estado : BaseModel
{
    [Required]
    [MaxLength(200)]
    public string Nome { get; set; }

    [Required]
    [StringLength(2)]
    public string Sigla { get; set; } // ISO 3166-1 alpha-2

    // Relacionamento com País (subgrupo de país pelo id)
    [Required]
    public int PaisId { get; set; }

    [ForeignKey("PaisId")]
    public virtual Pais? Pais { get; set; }

}