using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("pais");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired().HasColumnName("nome");
            builder.Property(p => p.Sigla).HasMaxLength(2).IsRequired().HasColumnType("BLOB").HasColumnName("sigla");
        }
    }
}