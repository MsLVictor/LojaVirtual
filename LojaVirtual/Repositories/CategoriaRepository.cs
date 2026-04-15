using Interfaces.Repositories;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly List<Categoria> _categorias = new List<Categoria>();

    public void AdicionarCategoria(Categoria categoria) => _categorias.Add(categoria);

    public List<Categoria> ListarCategorias() => _categorias.Where(c => c.Status == Enums.StatusCategoriaEnum.Ativo).ToList();

    public Categoria BuscarPorId(int id) => _categorias.FirstOrDefault(c => c.Id == id);
    
    public bool ExisteNome(string nome) => _categorias.Any(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    public void ExcluirCategoria(Categoria categoria) => categoria.MudarStatus(Enums.StatusCategoriaEnum.Inativo);
}

