// using MySqlConnector;
class Conexao
{
    public static MySqlConnection Conectar()
    {
        string stringConexao = "Server=localhost;Port=3306;Database=sustentabilidade;User ID=root;Password=Senac2026;";
 
        MySqlConnection conexao = new MySqlConnection(stringConexao);
 
        conexao.Open();
 
        return conexao;
    }
}