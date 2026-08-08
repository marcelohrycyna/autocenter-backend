using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class OrdemServicoMap : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("ordem_servico");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DataEntrada).IsRequired().HasColumnType("date").HasColumnName("data_entrada");
            builder.Property(p => p.DataSaida).HasColumnType("date").HasColumnName("data_saida");
            builder.Property(p => p.Observacao).HasMaxLength(1000).HasColumnName("observacao");
            builder.Property(p => p.Fechado).HasColumnType("bit").HasDefaultValue(false).HasColumnName("fechado");

            // Relacionamento com Cliente
            builder.Property(p => p.ClienteId).IsRequired().HasColumnName("clienteId");

            builder.HasOne(e => e.Cliente)
                   .WithMany()
                   .HasForeignKey(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Automovel
            builder.Property(p => p.AutomovelId).IsRequired().HasColumnName("automovelId");

            builder.HasOne(e => e.Automovel)
                   .WithMany()
                   .HasForeignKey(e => e.AutomovelId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}