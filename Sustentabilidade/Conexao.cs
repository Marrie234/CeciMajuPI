using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Categoria> Categoria { get; set;}
    public DbSet<Residuo> Residuo { get; set;}
    public DbSet<PontoColeta> PontoColeta { get; set;}
    public DbSet<ResiduoPonto> ResiduoPonto { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(@"server=localhost;database=sustentabilidade;user=root;password=Senac2026");
    }
}