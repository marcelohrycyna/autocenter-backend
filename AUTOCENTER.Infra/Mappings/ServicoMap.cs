using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("servico");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Tipo).HasMaxLength(200).IsRequired().HasColumnName("tipo");
            builder.Property(p => p.Descricao).HasMaxLength(500).HasColumnName("descricao");
            builder.Property(p => p.Valor).HasColumnType("DECIMAL").IsRequired().HasColumnName("valor");
        }
    }
}