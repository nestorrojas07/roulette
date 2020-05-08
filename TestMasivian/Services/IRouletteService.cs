using System.Collections.Generic;
using TestMasivian.Models;

namespace TestMasivian.Services
{
    public interface IRouletteService : IService
    {
        public Roulette create();

        public Roulette Find(string Id);

        public Roulette Open(string Id);
        public Roulette Close(string Id);

        public Roulette Bet(string Id, string UserId, int position, double money);

        public List<Roulette> GetAll();
    }
}