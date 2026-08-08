using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Adicione DbSet<T> aqui, por exemplo:
     public DbSet<Pais> Paises { get; set; }
}