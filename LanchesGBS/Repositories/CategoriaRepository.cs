using LanchesGBS.Context;
using LanchesGBS.Models;
using LanchesGBS.Repositories.Interfaces;

namespace LanchesGBS.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Catetorias => _context.Categorias;
    }
}
