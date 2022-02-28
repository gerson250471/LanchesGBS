using LanchesGBS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesGBS.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _CategoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _CategoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _CategoriaRepository.Catetorias.OrderBy(p => p.CategoriaNome);
            return View(categorias);
        }

    }
}
