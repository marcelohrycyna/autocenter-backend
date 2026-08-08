using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ordem_servico")]
public class OrdemServico : BaseModel
{
    [Required]
    public DateOnly DataEntrada { get; set; }
    public DateOnly? DataSaida { get; set; }

    [MaxLength(1000)]
    public string Observacao { get; set; }

    [Required]
    public bool Fechado { get; set; }

    // Relacionamento com Cliente
    [Required]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Cliente? Cliente { get; set; }

    // Relacionamento com Automovel
    [Required]
    public int AutomovelId { get; set; }

    [ForeignKey("AutomovelId")]
    public virtual Automovel? Automovel { get; set; }

    public ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; } = new List<OrdemServicoServico>();

}