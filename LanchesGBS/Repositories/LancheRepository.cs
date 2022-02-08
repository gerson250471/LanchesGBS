using LanchesGBS.Context;
using LanchesGBS.Models;
using LanchesGBS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesGBS.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _contex;

        public LancheRepository(AppDbContext contex)
        {
            _contex = contex;
        }

        public IEnumerable<Lanche> Lanches => _contex.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _contex.Lanches.Where(p => p.IsLanchePreferido).Include(c=>c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _contex.Lanches.FirstOrDefault(I => I.LancheId == lancheId);
        } 


    }
}
