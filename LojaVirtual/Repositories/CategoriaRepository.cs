using Interfaces.Repositories;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly List<Categoria> _categorias = new List<Categoria>();

    public void AdicionarCategoria(Categoria categoria) => _categorias.Add(categoria);

    public List<Categoria> ListarCategorias() => _categorias.Where(c => c.Status == Enums.StatusCategoriaEnum.Ativo).ToList();
    public void ExcluirCategoria(Categoria categoria) => _categorias.Remove(categoria);
}

