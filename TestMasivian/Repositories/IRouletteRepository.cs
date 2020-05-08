using System.Collections.Generic;
using TestMasivian.Models;

namespace TestMasivian.Repositories
{
    public interface IRouletteRepository : IRepository
    {
        public Roulette GetById(string Id);

        public List<Roulette> GetAll();
        
        public Roulette Update(string Id, Roulette roulette);
        
        public Roulette Save(Roulette roulette);
    }
}