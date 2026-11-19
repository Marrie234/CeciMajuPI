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

        return $"ID: {IdResiduo} | Nome: {Nome} | Reciclável: {(Reciclavel ? "Sim" : "Não")} | Orientação: {Orientacao}";

    }

}