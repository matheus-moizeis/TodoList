using TodoList.Interface;

namespace TodoList.Entities;

public class RepositorioTarefa : IRepositorio<Tarefa>
{
    private List<Tarefa> listaTarefa = new List<Tarefa>();

    public void Atualiza(int id, Tarefa entidade)
    {
        listaTarefa[id] = entidade; 
    }

    public void Exclui(int id)
    {
        listaTarefa.RemoveAt(id);
    }

    public void Insere(Tarefa entidade)
    {
        listaTarefa.Add(entidade);
    }

    public List<Tarefa> Lista()
    {
        var listaOrdenada = listaTarefa.OrderBy(x => x.DataVencimento).ToList();
        return listaOrdenada;
    }

    public int ProximoId()
    {
        return listaTarefa.Count;
    }

    public Tarefa RetornaPorId(int id)
    {
        return listaTarefa[(int)id];
    }
}