using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOCENTER.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.HasKey(k => new { k.Id }).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.Nome)
                   .HasMaxLength(150)
                   .IsRequired()
                   .HasColumnName("nome");

            builder.Property(p => p.Rua)
                   .HasMaxLength(150)
                   .HasColumnName("rua");

            builder.Property(p => p.Numero)
                   .HasMaxLength(150)
                   .HasColumnName("numero");

            builder.Property(p => p.Cep)
                   .HasMaxLength(50)
                   .HasColumnName("cep");

            builder.Property(p => p.Bairro)
                   .HasMaxLength(100)
                   .HasColumnName("bairro");

            builder.Property(p => p.Complemento)
                   .HasMaxLength(150)
                   .HasColumnName("complemento");

            builder.Property(p => p.Email)
                   .HasMaxLength(200)
                   .HasColumnName("email");

            builder.Property(p => p.Cpf)
                   .HasMaxLength(50)
                   .HasColumnName("cpf");

            builder.Property(p => p.Telefone)
                   .HasMaxLength(50)
                   .HasColumnName("telefone");

            // Relacionamento com Cidade
            builder.Property(p => p.CidadeId)
                   .IsRequired()
                   .HasColumnName("cidadeId");

            builder.HasOne(e => e.Cidade)
                   .WithMany()
                   .HasForeignKey(e => e.CidadeId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_cliente_cidade");
        }
    }
}