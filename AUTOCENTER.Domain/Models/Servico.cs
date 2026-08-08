using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("servico")]
public class Servico : BaseModel
{
    [Required]
    [MaxLength(200)]
    public string Tipo { get; set; }

    [StringLength(500)]
    public string Descricao { get; set; }

    [Required]
    public decimal Valor { get; set; }

    public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; } = new List<OrdemServicoServico>();

}