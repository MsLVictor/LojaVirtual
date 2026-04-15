using LojaVirtual.Enums;

namespace LojaVirtual.Models;

public class Categoria
{

    public Categoria(string nome)
    {
        Nome = nome;
        Status = StatusCategoriaEnum.Ativo;
        Id = _proximoId++;
    }

    private static int _proximoId = 1;
    public int Id {get;}
    public string Nome {get; private set;}
    public StatusCategoriaEnum Status {get; private set;}
    public void MudarStatus(StatusCategoriaEnum novoStatus) => Status = novoStatus;
    public void MudarNome(string novoNome) => Nome = novoNome;
    public override string ToString() => $"Id: {Id} | Nome: {Nome}";
}

