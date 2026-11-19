using Microsoft.EntityFrameworkCore;

namespace CrudEF.Data;
public class AppDbContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(@"server=localhost;database=Sustentabilidade;user=root;password=Senac2026");
    }
}