using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class ApplicationDbContext : DbContext
{
    //public ApplicationContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Adicione DbSet<T> aqui, por exemplo:
     public virtual DbSet<Pais> Paises { get; set; }
    public virtual DbSet<Estado> Estados { get; set; }
    public virtual DbSet<Cidade> Cidades { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Automovel> Automoveis { get; set; }
    public virtual DbSet<Servico> Servicos { get; set; }
    public virtual DbSet<OrdemServico> OrdemServicos { get; set; }
    public virtual DbSet<OrdemServicoServico> OrdemServicoServicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}