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
}