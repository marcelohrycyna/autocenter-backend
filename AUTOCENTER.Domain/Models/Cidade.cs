using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("cidade")]
public class Cidade : BaseModel
{
    [Required]
    [MaxLength(50)]
    public string Nome { get; set; }

    // Relacionamento com País (subgrupo de país pelo id)
    [Required]
    public int EstadoId { get; set; }

    [ForeignKey("EstadoId")]
    public virtual Estado? Estado { get; set; }
}