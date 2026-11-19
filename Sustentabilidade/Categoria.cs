public class Categoria
{
    public int Id{ get; set; }
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
    static async Task CriarCategoria(string nome, string descricao)
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
}