using LojaVirtual.DTOs;
using LojaVirtual.Interfaces.Services;
using LojaVirtual.Models;
using LojaVirtual.Repositories;

namespace LojaVirtual.UI;

public class Menu(ICategoriaService categoriaService)
{

    public void MenuInicial()
    {
        bool menuInfinito = true;

        while (menuInfinito)
        {
            System.Console.WriteLine("====== LOJA VIRTUAL ======");
            System.Console.WriteLine("1 - Adicionar Categoria");
            System.Console.WriteLine("2 - Listar Categorias");
            System.Console.WriteLine("3 - Aletar Nome da Categoria");
            System.Console.WriteLine("4 - Excluir Categoria \n");
            System.Console.WriteLine("0 - sair");

            int opcaoMenu;

            while (!int.TryParse(Console.ReadLine(), out opcaoMenu) || opcaoMenu < 0)
                System.Console.WriteLine("Opcão inválida.");
            

            switch (opcaoMenu)
            {
                case 1:
                    categoriaService.AdicionarCategoria(AdicionarCategoria());
                    break;
                case 2:
                    ListarCategorias(categoriaService.ListarCategorias());
                    break;
                case 3:
                    categoriaService.AlterarNome(AlterarNomeCategoriaPorId());
                break;
                case 4:
                    ExcluirCategoria();
                break;
                case 0:
                    menuInfinito = false;
                    break;
            }
        }
    }



    public CategoriaDTO AdicionarCategoria()
    {
        System.Console.WriteLine("=== CADASTRO DE CATEGORIA ===");
        System.Console.WriteLine("Digite o nome da categoria: ");

        string nomeCategoria = Console.ReadLine();

        return new CategoriaDTO(nomeCategoria);
    }

    public void ListarCategorias(List<Categoria> categoria) => categoria.ForEach(c => Console.WriteLine(c.ToString()));

    public CategoriaDTO AlterarNomeCategoriaPorId()
    {
        int id;

        System.Console.WriteLine("Digite o id da categoria para alterar: ");

        while(!int.TryParse(Console.ReadLine(), out id))
            System.Console.WriteLine("Id inválido.");

         //remover validacao da UI e colocar na service
        var categoriaParaAtualizar = categoriaService.BuscarCategoriaPorId(id);

        if(categoriaParaAtualizar == null)
        {
            System.Console.WriteLine($"Nenhuma categoria encontrada com o Id {id}");
            return null;
        }
        
        System.Console.WriteLine($"Digite o novo nome para alterar (Nome atual: {categoriaParaAtualizar.Nome}): ");
        string novoNome = Console.ReadLine();

        return new CategoriaDTO(novoNome);
    }

    public void ExcluirCategoria()
    {
        System.Console.WriteLine("Informe o Id da categoria que você deseja excluir: ");

        int idParaExcluir;

        while(!int.TryParse(Console.ReadLine(), out idParaExcluir))
            System.Console.WriteLine("Id inválido.");
        
        var categoria = categoriaService.BuscarCategoriaPorId(idParaExcluir);

        if(categoria == null)
        {
            System.Console.WriteLine("Categoria não existe.");
            return;
        }

        categoriaService.ExcluirCategoriaPorId(idParaExcluir);
    }
}
