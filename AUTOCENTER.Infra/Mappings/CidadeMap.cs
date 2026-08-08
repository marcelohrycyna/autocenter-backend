using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidade");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired().HasColumnName("nome");

            // Relacionamento com Estado
            builder.Property(p => p.EstadoId).IsRequired().HasColumnName("estadoId");

            builder.HasOne(e => e.Estado)
                   .WithMany()
                   .HasForeignKey(e => e.EstadoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_cidade_estado");
        }
    }
}