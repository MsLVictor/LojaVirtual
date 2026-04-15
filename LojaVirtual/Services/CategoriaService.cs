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

        var pesquisaCategoria = categoriaRepository.ListarCategorias().FirstOrDefault(c => c.Nome.ToLower() == dto.nome.ToLower());
        
        if(pesquisaCategoria != null)
        {
            System.Console.WriteLine("Categoria já existe.");
            return;
        }

        if(dto.nome.Count() >= 2 || dto.nome.Count() <= 60)
        {
            categoriaRepository.AdicionarCategoria(new Categoria(dto.nome));
            System.Console.WriteLine("Categoria adicionada com sucesso!");
            return;
        }

        System.Console.WriteLine("Categoria inválida, tem que ter de 2 a 60 caracteres.");
        return;
    }

    public void AlterarNome(CategoriaDTO dto)
    {
        var pesquisaCategoria = categoriaRepository.ListarCategorias().FirstOrDefault(c => c.Nome.ToLower() == dto.nome.ToLower());

        if(pesquisaCategoria != null)
        {
            System.Console.WriteLine("Nome da categoria não pode ser atualizado pois já existe uma categoria com o mesmo nome.");
            return;
        }


    }

    public void ExcluirCategoriaPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> ListarCategorias() => categoriaRepository.ListarCategorias();

    
}
