using TodoList.Entities;

namespace TodoList;

class Program
{
    static RepositorioTarefa repositorio = new RepositorioTarefa();

    static void Main(string[] args)
    {

        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarTarefa();
                    break;
                case "2":
                    InserirTarefa();
                    break;
                case "3":
                    EditarTarefa();
                    break;
                case "4":
                    ApagarTarefa();
                    break;

                default:
                    Console.WriteLine($"Opção {opcaoUsuario} inválida.");
                    break;

            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Finalizando.");
        Console.ReadLine();
    }

    #region Métodos
    
    private static void ApagarTarefa()
    {
        Console.Write("Digite o id da tarefa a ser apagada: ");
        int idTarefa = int.Parse(Console.ReadLine());

        repositorio.Exclui(idTarefa);
    }

    private static void EditarTarefa()
    {
        Console.WriteLine("Editar nova tarefa");

        Console.Write("Digite o id da tarefa: ");
        int idTarefa = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da tarefa: ");
        string tituloTarefa = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string descricaoTarefa = Console.ReadLine();

        Console.Write("Digite o vencimento da tarefa (DD/MM/YYYY): ");
        DateTime dtVencimento = DateTime.Parse(Console.ReadLine());

        Console.Write("Tarefa concluida? (s/n): ");
        char respConcluida = char.Parse(Console.ReadLine());

        if (respConcluida == 'n' || respConcluida == 'N')
        {
            Tarefa tarefaAtualizada = new Tarefa(id: idTarefa,
                                           titulo: tituloTarefa,
                                           descricao: descricaoTarefa,
                                           dataVencimento: dtVencimento,
                                           concluida: false    
                                            );
            repositorio.Atualiza(idTarefa, tarefaAtualizada);
        }
        else
        {
            repositorio.Exclui(idTarefa);
        }

    }

    private static void InserirTarefa()
    {
        Console.WriteLine("Inserir nova tarefa");


        Console.Write("Digite o título da tarefa: ");
        string tituloTarefa = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string descricaoTarefa = Console.ReadLine();

        Console.Write("Digite o vencimento da tarefa (DD/MM/YYYY): ");
        DateTime dtVencimento = DateTime.Parse(Console.ReadLine());

        Tarefa novaTarefa = new Tarefa(id: repositorio.ProximoId(),
                                       titulo: tituloTarefa,
                                       descricao: descricaoTarefa,
                                       dataVencimento: dtVencimento,
                                       concluida: false
                                        );
        repositorio.Insere(novaTarefa);
    }

    private static void ListarTarefa()
    {
        Console.WriteLine("Listar tarefas");

        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        foreach (var itensLista in lista)
        {
            string tarefaConcluida = itensLista.Concluida == true ? "Sim" : "Não";
            Console.WriteLine($"ID: {itensLista.Id} | Título: {itensLista.Titulo} | Descrição: {itensLista.Descricao} | Vencimento: {itensLista.DataVencimento} | Tarefa concluida : {tarefaConcluida}");
        }
    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1- Listar tarefas");
        Console.WriteLine("2- Inserir nova tarefa");
        Console.WriteLine("3- Editar tarefa");
        Console.WriteLine("4- Excluir tarefa");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }

    #endregion
}
