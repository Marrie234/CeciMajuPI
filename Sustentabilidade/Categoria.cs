public class Categoria
{
    public int IdCategoria { get; set; }
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
        return $"ID: {IdCategoria} | Nome: {Nome} | Descrição: {Descricao}";
    }
}