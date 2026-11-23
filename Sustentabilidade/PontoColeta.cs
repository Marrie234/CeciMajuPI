public class PontoColeta
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Endereco { get; set; } = "";
    public string Bairro { get; set; } = "";
    public string Cidade { get; set; } = "";
    public string Telefone { get; set; } = "";
    public string HorarioFuncionamento { get; set; } = "";
 
    public PontoColeta()
    {
    }
 
    public PontoColeta(string nome, string endereco, string bairro, string cidade, string telefone, string horarioFuncionamento)
    {
        Nome = nome;
        Endereco = endereco;
        Bairro = bairro;
        Cidade = cidade;
        Telefone = telefone;
        HorarioFuncionamento = horarioFuncionamento;
    }
 
    public override string ToString()
    {
        return $"ID: {Id} | Nome: {Nome} | Endereço: {Endereco} | Bairro: {Bairro} | Cidade: {Cidade}";
    }
     public static async Task CriarPontoColeta(string nome, string endereco, string bairro, string cidade, string telefone, string horarioFuncionamento)
    {
     await using var db = new AppDbContext();
        var pontoColeta = new PontoColeta
        {
            Nome = nome,
            Endereco = endereco,
            Bairro = bairro,
            Cidade = cidade,
            Telefone = telefone,
            HorarioFuncionamento = horarioFuncionamento
        };
        db.PontosColeta.Add(pontoColeta);
        await db.SaveChangesAsync();
        Console.WriteLine($"Ponto de coleta cadastrado com sucesso! ID: {pontoColeta.Id}");
    }
    public static async Task<List<PontoColeta>> ListarPontosColeta()
    {
        await using var db = new AppDbContext();
        return await db.PontosColeta.ToListAsync();
    }
    public static async Task<PontoColeta?> BuscarPorNome(string nome)
    {
        await using var db = new AppDbContext();
        return await db.PontosColeta.FirstOrDefaultAsync(p => p.Nome == nome);
    }
    public static async Task<PontoColeta?> BuscarPorId(int id)
    {
        await using var db = new AppDbContext();
        return await db.PontosColeta.FindAsync(id);
    }
    public static async Task AtualizarPontoColeta(int id, PontoColeta novoPontoColeta)
    {
        await using var db = new AppDbContext();
        var pontoColeta = await db.PontosColeta.FindAsync(id);
        if (pontoColeta == null)
        {
            Console.WriteLine("Ponto de coleta não encontrado.");
            return;
        }
        pontoColeta.Nome = novoPontoColeta.Nome ?? pontoColeta.Nome;
        pontoColeta.Endereco = novoPontoColeta.Endereco ?? pontoColeta.Endereco;
        pontoColeta.Bairro = novoPontoColeta.Bairro ?? pontoColeta.Bairro;
        pontoColeta.Cidade = novoPontoColeta.Cidade ?? pontoColeta.Cidade;
        pontoColeta.Telefone = novoPontoColeta.Telefone ?? pontoColeta.Telefone;
        pontoColeta.HorarioFuncionamento = novoPontoColeta.HorarioFuncionamento ?? pontoColeta.HorarioFuncionamento;

        await db.SaveChangesAsync();
        Console.WriteLine($"Ponto de coleta atualizado com sucesso! ID: {pontoColeta.Id}");
    }
    public static async Task DeletarPontoColeta(int id)
    {
        await using var db = new AppDbContext();
        var pontoColeta = await db.PontosColeta.FindAsync(id);
        if (pontoColeta == null)
        {
            Console.WriteLine("Ponto de coleta não encontrado.");
            return;
        }
        db.PontosColeta.Remove(pontoColeta);
        await db.SaveChangesAsync();
        Console.WriteLine($"Ponto de coleta deletado com sucesso! ID: {pontoColeta.Id}");
    }
}