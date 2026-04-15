using LojaVirtual.DTOs;
using LojaVirtual.Models;

namespace LojaVirtual.Interfaces.Services;

public interface ICategoriaService
{
    public void AdicionarCategoria(CategoriaDTO dto);
    public List<Categoria> ListarCategorias();
    public void ExcluirCategoriaPorId(int id);
    public Categoria BuscarCategoriaPorId(int id);
    public void AlterarNome(CategoriaDTO dto);
}

