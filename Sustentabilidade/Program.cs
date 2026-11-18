using System;
 
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Conexao.Conectar();
 
            Console.WriteLine("Conexão com o MySQL realizada com sucesso!");
        }
        catch (Exception erro)
        {
            Console.WriteLine("Erro ao conectar: " + erro.Message);
        }
 
        Console.ReadKey();
    }
} //teste