using LojaVirtual.Models;

namespace Interfaces.Repositories;

public interface ICategoriaRepository
{
    public void AdicionarCategoria(Categoria categoria);
    public List<Categoria> ListarCategorias();
    public void ExcluirCategoria(Categoria categoria);  
}

