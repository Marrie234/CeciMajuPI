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
}