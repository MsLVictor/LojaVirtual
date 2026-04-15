using LojaVirtual.Enums;

namespace LojaVirtual.Models;

public class Categoria
{

    public Categoria(string nome)
    {
        Nome = nome;
        Status = StatusCategoriaEnum.Ativo;
    }

    public string Nome {get; private set;}
    public StatusCategoriaEnum Status {get; private set;}

    public void MudarStatus(StatusCategoriaEnum novoStatus) => Status = novoStatus;
    public void MudarNome(string novoNome) => Nome = novoNome;
}

