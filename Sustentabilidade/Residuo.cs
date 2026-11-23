public class Residuo

{

    public int Id { get; set; }

    public string Nome { get; set; } = "";

    public string Descricao { get; set; } = "";

    public bool Reciclavel { get; set; }

    public string Orientacao { get; set; } = "";

    public int IdCategoria { get; set; }
 
    public Residuo()

    {

    }
    public Residuo(string nome, string descricao, bool reciclavel, string orientacao, int idCategoria)

    {

        Nome = nome;

        Descricao = descricao;

        Reciclavel = reciclavel;

        Orientacao = orientacao;

        IdCategoria = idCategoria;

    }
 
    public override string ToString()

    {

        return $"ID: {Id} | Nome: {Nome} | Reciclável: {(Reciclavel ? "Sim" : "Não")} | Orientação: {Orientacao}";

    }
    public static async Task CriarResiduo(string nome, string descricao, bool reciclavel, string orientacao, int idCategoria)
    {
        await using var db = new AppDbContext();
        var residuo = new Residuo
        {
            Nome = nome,
            Descricao = descricao,
            Reciclavel = reciclavel,
            Orientacao = orientacao,
            IdCategoria = idCategoria
        };
        db.Residuos.Add(residuo);
        await db.SaveChangesAsync();
        Console.WriteLine($"Resíduo cadastrado com sucesso! ID: {residuo.Id}");
    }
    public static async Task<List<Residuo>> ListarResiduos()
    {
        await using var db = new AppDbContext();
        return await db.Residuos.ToListAsync();
    }
    public static async Task<Residuo?> BuscarPorNome(string nome)
    {
        await using var db = new AppDbContext();
        return await db.Residuos.FirstOrDefaultAsync(r => r.Nome == nome);
    }
    public static async Task<Residuo?> BuscarPorId(int id)
    {
        await using var db = new AppDbContext();
        return await db.Residuos.FindAsync(id);
    }
    public static async Task AtualizarResiduo(int id, Residuo novoResiduo)
    {
        await using var db = new AppDbContext();
        var residuo = await db.Residuos.FindAsync(id);
        if (residuo == null)
        {
            Console.WriteLine("Resíduo não encontrado.");
            return;
        }
        residuo.Nome = novoResiduo.Nome ?? residuo.Nome;
        residuo.Descricao = novoResiduo.Descricao ?? residuo.Descricao;
        residuo.Reciclavel = novoResiduo.Reciclavel;
        residuo.Orientacao = novoResiduo.Orientacao ?? residuo.Orientacao;
        residuo.IdCategoria = novoResiduo.IdCategoria != 0 ? novoResiduo.IdCategoria : residuo.IdCategoria;

        await db.SaveChangesAsync();
        Console.WriteLine($"Resíduo atualizado com sucesso! ID: {residuo.Id}");
    }
    public static async Task DeletarResiduo(int id)
    {
        await using var db = new AppDbContext();
        var residuo = await db.Residuos.FindAsync(id);
        if (residuo == null)
        {
            Console.WriteLine("Resíduo não encontrado.");
            return;
        }
        db.Residuos.Remove(residuo);
        await db.SaveChangesAsync();
        Console.WriteLine($"Resíduo deletado com sucesso! ID: {residuo.Id}");
    }
}