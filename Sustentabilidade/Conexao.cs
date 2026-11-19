using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set;}
    public DbSet<Residuo> Residuos { get; set;}
    public DbSet<PontoColeta> PontosColeta { get; set;}
    public DbSet<ResiduoPonto> ResiduosPontos { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(@"server=localhost;database=Sustentabilidade;user=root;password=Senac2026");
    }
}