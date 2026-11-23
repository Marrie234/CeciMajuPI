using Microsoft.EntityFrameworkCore;

public class Categoria
{

    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Descricao { get; set; } = "";
 
    public Categoria()
    {  
    }
 
    public Categoria(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }
 
    public override string ToString()
    {
        return $"ID: {Id} | Nome: {Nome} | Descrição: {Descricao}";
    }
     public static async Task CriarCategoria(string nome, string descricao)
    {
        await using var db = new AppDbContext();
        var categoria = new Categoria
        {
            Nome = nome,
            Descricao = descricao
        };
        db.Categorias.Add(categoria);
        await db.SaveChangesAsync();
        Console.WriteLine($"Categoria cadastrada com sucesso! ID: {categoria.Id}");
    }
    public static async Task<List<Categoria>> ListarCategorias()
    {
        await using var db = new AppDbContext();
        return await db.Categorias.ToListAsync();
    }
        public static async Task<Categoria?> BuscarPorNome(string nome)
    {
        await using var db = new AppDbContext();
        return await db.Categorias.FirstOrDefaultAsync(c => c.Nome == nome);
    }
    public static async Task<Categoria?> BuscarPorId(int id)
    {
        await using var db = new AppDbContext();
        return await db.Categorias.FindAsync(id);
    }
    public static async Task AtualizarCategoria(int id, Categoria novaCategoria)
    {
        await using var db = new AppDbContext();
        var categoria = await db.Categorias.FindAsync(id);
        if (categoria == null)
        {
            Console.WriteLine("Categoria não encontrada.");
            return;
        }
        categoria.Nome = novaCategoria.Nome ?? categoria.Nome;
        categoria.Descricao = novaCategoria.Descricao ?? categoria.Descricao;

        await db.SaveChangesAsync();
        Console.WriteLine("Categoria atualizada com sucesso!");
    }
    public static async Task DeletarCategoria(int id)
    {
        await using var db = new AppDbContext();
        var categoria = await db.Categorias.FindAsync(id);
        if(categoria == null)
        {
            Console.WriteLine("Categoria não encontrada.");
            return;
        }
        db.Categorias.Remove(categoria);
        await db.SaveChangesAsync();
        Console.WriteLine("Categoria deletada com sucesso!");
    }
}