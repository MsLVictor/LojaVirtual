using LojaVirtual.DTOs;
using LojaVirtual.Interfaces.Services;
using LojaVirtual.Models;

namespace LojaVirtual.UI;

public class Menu(ICategoriaService categoriaService)
{

    public void MenuInicial()
    {
        bool menuInfinito = true;

        while (menuInfinito)
        {
            System.Console.WriteLine("=== LOJA VIRTUAL ===");
            System.Console.WriteLine("1 - Adicionar Categoria");
            System.Console.WriteLine("2 - Listar Categorias");
            System.Console.WriteLine("0 - sair");

            int opcaoMenu;

            while (!int.TryParse(Console.ReadLine(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 2)
                System.Console.WriteLine("Opcão inválida.");
            

            switch (opcaoMenu)
            {
                case 1:
                    categoriaService.AdicionarCategoria(AdicionarCategoria());
                    break;
                case 2:
                    ListarCategorias(categoriaService.ListarCategorias());
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

    public void ListarCategorias(List<Categoria> categoria) => categoria.ForEach(c => Console.WriteLine($"{c.Nome}"));

}
