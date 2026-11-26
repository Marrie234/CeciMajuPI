using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto.Generators;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string opcao = "";

        while (opcao != "7")

        {
            Console.WriteLine("=================================================");
            Console.WriteLine("Bem vindo ao nosso Sistema de Sustentabilidade!");
            Console.WriteLine("=================================================");
            Console.WriteLine("=Temos algumas opções para que você nos ajude a cuidar bem do nosso planeta!=");
            Console.WriteLine("1. Cadastrar uma nova categoria");
            Console.WriteLine("2. Cadastrar um novo residuo");
            Console.WriteLine("3. Cadastrar um novo pondo de coleta");
            Console.WriteLine("4. Listar residuos, pontos de coleta e categorias");
            Console.WriteLine("5. Atualizar um cadastro");
            Console.WriteLine("6. Excluir um cadastro");
            Console.WriteLine("7. Sair");

            Console.WriteLine("Digite uma opção:");
            opcao = Console.ReadLine() ?? "";
            
            if (opcao == "1")
            {
                Console.WriteLine("=====Cadastro de categorias=====");

                Console.WriteLine("Digite o nome da categoria:");
                string nome = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a descrição da categoria:");
                string descricao = Console.ReadLine() ?? "";
                await Categoria.CriarCategoria(nome, descricao);

            }

            else if (opcao == "2")
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
                await Residuo.CriarResiduo(nome, descricao, reciclavel, orientacao, idCategoria);

            }

            else if (opcao == "3")
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
                await PontoColeta.CriarPontoColeta(nome, endereco, bairro, cidade, telefone, horario);
            }

            else if (opcao == "4")
            {
                Console.WriteLine("===== Listar cadastros =====");

                Console.WriteLine("Qual você deseja listar?");
                Console.WriteLine("1. Resíduos");
                Console.WriteLine("2. Pontos de coleta");
                Console.WriteLine("3. Categorias");

                string escolha = Console.ReadLine() ?? "";

                if (escolha == "1")
                {
                    Console.WriteLine("===== Resíduos cadastrados =====");

                    var residuos = await Residuo.ListarResiduos();

                    if (residuos.Count == 0)
                    {
                        Console.WriteLine("Nenhum resíduo cadastrado.");
                    }
                    else
                    {
                        foreach (var residuo in residuos)
                        {
                            Console.WriteLine(residuo);
                        }
                    }
                }
                else if (escolha == "2")
                {
                    Console.WriteLine("===== Pontos de coleta cadastrados =====");

                    var pontos = await PontoColeta.ListarPontosColeta();

                    if (pontos.Count == 0)
                    {
                        Console.WriteLine("Nenhum ponto de coleta cadastrado.");
                    }
                    else
                    {
                        foreach (var ponto in pontos)
                        {
                            Console.WriteLine(ponto);
                        }
                    }
                }
                else if (escolha == "3")
                {
                    Console.WriteLine("===== Categorias cadastradas =====");

                    var categorias = await Categoria.ListarCategorias();

                    if (categorias.Count == 0)
                    {
                        Console.WriteLine("Nenhuma categoria cadastrada.");
                    }
                    else
                    {
                        foreach (var categoria in categorias)
                        {
                            Console.WriteLine(categoria);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                }
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
            else if (opcao == "6")
            {
                Console.WriteLine("===== Excluir cadastro =====");

                Console.WriteLine("O que deseja excluir?");
                Console.WriteLine("1. Resíduo");
                Console.WriteLine("2. Ponto de coleta");
                Console.WriteLine("3. Categoria");

                string tipo = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o ID do cadastro que deseja excluir:");
                int id = int.Parse(Console.ReadLine() ?? "0");

                if (tipo == "1")
                {
                    Console.WriteLine("Resíduo excluído com sucesso!");
                }
                else if (tipo == "2")
                {
                    Console.WriteLine("Ponto de coleta excluído com sucesso!");
                }
                else if (tipo == "3")
                {
                    Console.WriteLine("Categoria excluída com sucesso!");
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
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