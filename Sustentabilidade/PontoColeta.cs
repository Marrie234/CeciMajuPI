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
        return $"ID: {IdPonto} | Nome: {Nome} | Endereço: {Endereco} | Bairro: {Bairro} | Cidade: {Cidade}";
    }
}