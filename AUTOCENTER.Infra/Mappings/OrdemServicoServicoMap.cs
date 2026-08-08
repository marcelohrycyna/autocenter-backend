using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class OrdemServicoServicoMap : IEntityTypeConfiguration<OrdemServicoServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServicoServico> builder)
        {
            builder.ToTable("ordem_servico_servico");

            builder.HasKey(oss => new { oss.OrdemServicoId, oss.ServicoId });

            builder.Property(oss => oss.OrdemServicoId).HasColumnName("ordem_servicoId").IsRequired();
            builder.Property(oss => oss.ServicoId).HasColumnName("servicoId").IsRequired();
            builder.Property(oss => oss.Quantidade).HasColumnName("quantidade").IsRequired().HasDefaultValue(1);
            builder.Property(oss => oss.ValorUnitario).HasColumnName("valor_unitario").HasColumnType("decimal(19,2)").IsRequired();
            builder.Property(oss => oss.ValorTotal).HasColumnName("valor_total").HasColumnType("decimal(19,2)").IsRequired();

            //Relacionamentos
            builder.HasOne(oss => oss.OrdemServico).WithMany(os => os.OrdemServicoServicos).HasForeignKey(oss => oss.OrdemServicoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(oss => oss.Servico).WithMany(s => s.OrdemServicoServicos).HasForeignKey(oss => oss.ServicoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}