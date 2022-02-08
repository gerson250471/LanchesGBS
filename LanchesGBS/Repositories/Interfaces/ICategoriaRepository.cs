using LanchesGBS.Models;

namespace LanchesGBS.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Catetorias { get; }
    }
}
