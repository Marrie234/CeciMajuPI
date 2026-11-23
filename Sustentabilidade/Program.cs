using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto.Generators;

class Program
{
    static void Main(string[] args)
    {
        string opcao = "";

        while (opcao != "4")
    
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("Bem vindo ao nosso Sistema de Sustentabilidade!");
        Console.WriteLine("=================================================");
        Console.WriteLine("=Temos algumas opções para que você nos ajude a cuidar bem do nosso planeta!=");
        Console.WriteLine("1. Cadastrar um novo resíduo");
        Console.WriteLine("2. Cadastrar um novo ponto de coleta");
        Console.WriteLine("3. Cadastrar uma nova categoria");
        Console.WriteLine("4. Sair");

        Console.WriteLine("Digite uma opção:");
            opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                Console.WriteLine("=====Cadastro de resíduos=====");

                Console.WriteLine("Digite o nome do resíduo:");
                string nome = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a descrição:");
                string descricao = Console.ReadLine() ?? "";

                Console.WriteLine("O resíduo é reciclável? (sim/não)");
                string resposta = Console.ReadLine() ?? "";

                bool reciclavel;

                if (resposta.ToLower() == "sim")
                {
                    reciclavel = true;
                }
                else
                {
                    reciclavel = false;
                }

                Console.WriteLine("Digite a orientação de descarte:");
                string orientacao = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o ID da categoria:");
                int idCategoria = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("Resíduo cadastrado com sucesso!");
            }
            else if (opcao == "2")
            {
                Console.WriteLine("=====Cadastro de pontos de coleta=====");

                 Console.WriteLine("Digite o nome do ponto de coleta:");
                string nome = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o endereço:");
                string endereco = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o bairro:");
                string bairro = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a cidade:");
                string cidade = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o telefone:");
                string telefone = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o horário de funcionamento:");
                string horario = Console.ReadLine() ?? "";

                Console.WriteLine("Ponto de coleta cadastrado com sucesso!");

    }
            
            else if (opcao == "3")
            {
                Console.WriteLine("=====Cadastro de categorias=====");

                Console.WriteLine("Digite o nome da categoria:");
                string nome = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a descrição da categoria:");
                string descricao = Console.ReadLine() ?? "";

                Console.WriteLine("Categoria cadastrada com sucesso!");
            }
            else if (opcao == "4")
            {
                Console.WriteLine("Obrigada por ajudar o planeta! Até mais!");
            }
            else
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
            }

            Console.WriteLine();
        }
    }
}