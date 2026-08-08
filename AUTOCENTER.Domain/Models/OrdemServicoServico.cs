using AUTOCENTER.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ordem_servico_servico")]
public class OrdemServicoServico : BaseModelWithoutId
{
    public int OrdemServicoId { get; set; }
    public OrdemServico OrdemServico { get; set; } = null!;

    public int ServicoId { get; set; }
    public Servico Servico { get; set; } = null!;

    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
}