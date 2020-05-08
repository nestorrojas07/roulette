using System;
using System.Collections.Generic;
using System.Linq;
using EasyCaching.Core;
using TestMasivian.Models;

namespace TestMasivian.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private IEasyCachingProviderFactory cachingProviderFactory;

        private IEasyCachingProvider cachingProvider;

        private const string KEYREDIS = "TABLEROULETE";
        
        public RouletteRepository(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("roulette");
            
        }

        public Roulette GetById(string Id)
        {
            var item = this.cachingProvider.Get<Roulette>(KEYREDIS + Id);
            if (!item.HasValue)
            {
                return null;
            }
            return item.Value;
        }

        public List<Roulette> GetAll()
        {
            var rouletes = this.cachingProvider.GetByPrefix<Roulette>(KEYREDIS);
            if (rouletes.Values.Count == 0)
            {
                return new List<Roulette>();
            }
            return new List<Roulette>(rouletes.Select(x => x.Value.Value));
        }

        public Roulette Update(string Id, Roulette roulette)
        {
            roulette.Id = Id;
            return Save(roulette);
        }

        public Roulette Save(Roulette roulette)
        {
            cachingProvider.Set(KEYREDIS + roulette.Id , roulette, TimeSpan.FromDays(365));
            return roulette;
        }
    }
}