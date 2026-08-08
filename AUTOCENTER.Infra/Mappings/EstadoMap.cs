using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estado");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired().HasColumnName("nome");
            builder.Property(p => p.Sigla).HasMaxLength(2).IsRequired().HasColumnName("sigla");

            // Relacionamento com País
            builder.Property(p => p.PaisId).IsRequired().HasColumnName("paisId");

            builder.HasOne(e => e.Pais)
                   .WithMany()
                   .HasForeignKey(e => e.PaisId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_estado_pais");
        }
    }
}