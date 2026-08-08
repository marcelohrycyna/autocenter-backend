using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class AutomovelMap : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> builder)
        {
            builder.ToTable("automovel");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Modelo).HasMaxLength(100).IsRequired().HasColumnName("modelo");
            builder.Property(p => p.Marca).HasMaxLength(100).HasColumnName("marca");
            builder.Property(p => p.Ano).HasMaxLength(4).HasColumnName("ano");
            builder.Property(p => p.Cor).HasMaxLength(50).HasColumnName("cor");
            builder.Property(p => p.Placa).HasMaxLength(10).HasColumnName("placa");

            // Relacionamento com Cliente
            builder.Property(p => p.ClienteId).IsRequired().HasColumnName("clienteId");

            builder.HasOne(e => e.Cliente)
                   .WithMany()
                   .HasForeignKey(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_automovel_cliente");
        }
    }
}