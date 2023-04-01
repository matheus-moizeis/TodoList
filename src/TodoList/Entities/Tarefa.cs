namespace TodoList.Entities;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Concluida { get; set; }

    public Tarefa(int id, string titulo, string descricao, DateTime dataVencimento, bool concluida)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.DataVencimento = dataVencimento;
        this.Concluida = concluida;
    }
}
