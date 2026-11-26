using Microsoft.EntityFrameworkCore;
public class ResiduoPonto
{
    public int Id { get; set; }
    public int IdResiduo { get; set; }
    public int IdPonto { get; set; }
 
    public ResiduoPonto()
    {
    }
 
    public ResiduoPonto(int idResiduo, int idPonto)
    {
        IdResiduo = idResiduo;
        IdPonto = idPonto;
    }
 
    public override string ToString()
    {
        return $"ID: {Id} | Resíduo: {IdResiduo} | Ponto de coleta: {IdPonto}";
    }
    public static async Task CriarResiduoPonto(int idResiduo, int idPonto)
    {
        await using var db = new AppDbContext();
        var residuoPonto = new ResiduoPonto
        {
            IdResiduo = idResiduo,
            IdPonto = idPonto
        };
        db.ResiduoPonto.Add(residuoPonto);
        await db.SaveChangesAsync();
        Console.WriteLine($"Resíduo-Ponto cadastrado com sucesso! ID: {residuoPonto.Id}");
    }
    public static async Task<List<ResiduoPonto>> ListarResiduosPontos()
    {
        await using var db = new AppDbContext();
        return await db.ResiduoPonto.ToListAsync();
    }
    public static async Task<ResiduoPonto?> BuscarPorNome(int idResiduo, int idPonto)
    {
        await using var db = new AppDbContext();
        return await db.ResiduoPonto.FirstOrDefaultAsync(rp => rp.IdResiduo == idResiduo && rp.IdPonto == idPonto);
    }
    public static async Task<ResiduoPonto?> BuscarPorId(int id)
    {
        await using var db = new AppDbContext();
        return await db.ResiduoPonto.FindAsync(id);
    }
    public static async Task AtualizarResiduoPonto(int id, ResiduoPonto novoResiduoPonto)
    {
        await using var db = new AppDbContext();
        var residuoPonto = await db.ResiduoPonto.FindAsync(id);
        if (residuoPonto == null)
        {
            Console.WriteLine("Resíduo-Ponto não encontrado.");
            return;
        }
        residuoPonto.IdResiduo = novoResiduoPonto.IdResiduo != 0 ? novoResiduoPonto.IdResiduo : residuoPonto.IdResiduo;
        residuoPonto.IdPonto = novoResiduoPonto.IdPonto != 0 ? novoResiduoPonto.IdPonto : residuoPonto.IdPonto;

        await db.SaveChangesAsync();
        Console.WriteLine($"Resíduo-Ponto atualizado com sucesso! ID: {residuoPonto.Id}");
    }
    public static async Task DeletarResiduoPonto(int id)
    {
        await using var db = new AppDbContext();
        var residuoPonto = await db.ResiduoPonto.FindAsync(id);
        if (residuoPonto == null)
        {
            Console.WriteLine("Resíduo-Ponto não encontrado.");
            return;
        }

        db.ResiduoPonto.Remove(residuoPonto);
        await db.SaveChangesAsync();
        Console.WriteLine($"Resíduo-Ponto deletado com sucesso! ID: {residuoPonto.Id}");
    }
}