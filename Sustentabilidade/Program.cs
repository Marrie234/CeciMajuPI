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
        Console.WriteLine("4. Listar residuos, pontos de coleta e categorias");
        Console.WriteLine("5. Atualizar um cadastro");
        Console.WriteLine("6. Excluir um cadastro");
        Console.WriteLine("7. Sair");

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
                Console.WriteLine("===== Listar cadastros =====");

                Console.WriteLine("===== Categorias cadastradas =====");

            // Aqui vamos chamar o método para listar categorias.

                Console.WriteLine("===== Resíduos cadastrados =====");

            // Aqui vamos chamar o método para listar resíduos.

                Console.WriteLine("===== Pontos de coleta cadastrados =====");

            // Aqui vamos chamar o método para listar pontos de coleta.

                Console.WriteLine("===== Fim da listagem =====");
            }
            else if (opcao == "5")
            {
                Console.WriteLine("===== Atualizar cadastro =====");

                Console.WriteLine("O que deseja atualizar?");
                Console.WriteLine("1. Resíduo");
                Console.WriteLine("2. Ponto de coleta");
                Console.WriteLine("3. Categoria");

            string tipo = Console.ReadLine() ?? "";

                if (tipo == "1")
            {
                Console.WriteLine("Digite o ID do resíduo:");
                int id = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("Digite o novo nome do resíduo:");
                string nome = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a nova descrição:");
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

                Console.WriteLine("Digite a nova orientação de descarte:");
                string orientacao = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o novo ID da categoria:");
                int idCategoria = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("Resíduo atualizado com sucesso!");
            }
            else if (tipo == "2")
            {
                Console.WriteLine("Digite o ID do ponto de coleta:");
                int id = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("Digite o novo nome:");
                string nome = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o novo endereço:");
                string endereco = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o novo bairro:");
                string bairro = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a nova cidade:");
                string cidade = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o novo telefone:");
                string telefone = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o novo horário de funcionamento:");
                string horario = Console.ReadLine() ?? "";

                Console.WriteLine("Ponto de coleta atualizado com sucesso!");
            }
            else if (tipo == "3")
            {
                Console.WriteLine("Digite o ID da categoria:");
                int id = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("Digite o novo nome da categoria:");
                string nome = Console.ReadLine() ?? ""; 
                Console.WriteLine("Digite a nova descrição:");
                string descricao = Console.ReadLine() ?? "";

                Console.WriteLine("Categoria atualizada com sucesso!");
            }
        }

            else if (opcao == "7")
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