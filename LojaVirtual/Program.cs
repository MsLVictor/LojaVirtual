
using Interfaces.Repositories;
using LojaVirtual.Interfaces.Services;
using LojaVirtual.Repositories;
using LojaVirtual.Services;
using LojaVirtual.UI;

ICategoriaRepository categoriaRepository = new CategoriaRepository();
ICategoriaService categoriaService = new CategoriaService(categoriaRepository);

Menu menu = new Menu(categoriaService);

menu.MenuInicial();
