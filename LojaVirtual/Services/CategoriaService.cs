using LojaVirtual.Repositories;
using LojaVirtual.Interfaces.Services;
using LojaVirtual.DTOs;
using LojaVirtual.Models;
using Interfaces.Repositories;

namespace LojaVirtual.Services;

public class CategoriaService(ICategoriaRepository categoriaRepository) : ICategoriaService
{
    public void AdicionarCategoria(CategoriaDTO dto)
    {
        if (categoriaRepository.ExisteNome(dto.Nome))
        {
            Console.WriteLine("Categoria já existe .");
            return;
        }

        //mover para menu
        if (dto.Nome.Length < 2 || dto.Nome.Length > 60)
        {
            Console.WriteLine("Categoria inválida, tem que ter de 2 a 60 caracteres.");
            return;
        }

        categoriaRepository.AdicionarCategoria(new Categoria(dto.Nome));
        Console.WriteLine("Categoria adicionada com sucesso!");
    }

    public void AlterarNome(CategoriaDTO dto)
    {
        var pesquisaCategoria = categoriaRepository.ListarCategorias().FirstOrDefault(c => c.Nome.ToLower() == dto.Nome.ToLower());

        if (pesquisaCategoria != null)
        {
            Console.WriteLine("Nome da categoria não pode ser atualizado pois já existe uma categoria com o mesmo Nome.");
            return;
        }


        System.Console.WriteLine("Nome da categoria atualizado com sucesso!");

        pesquisaCategoria.MudarNome(dto.Nome);
    }

    public Categoria BuscarCategoriaPorId(int id)
    {
        var categoria = categoriaRepository.BuscarPorId(id);

        return categoria;
    }

    public void ExcluirCategoriaPorId(int id)
    {
        var CategoriaParaExcluir = categoriaRepository.BuscarPorId(id);

        categoriaRepository.ExcluirCategoria(CategoriaParaExcluir);
    }


    public List<Categoria> ListarCategorias() => categoriaRepository.ListarCategorias();


}
