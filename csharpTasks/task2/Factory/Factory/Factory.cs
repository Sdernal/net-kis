using Factory.Providers;
using Factory.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Factory
    {
        public void AddProvider(IProvider<IMovable> provider)
        {
            
            _providers.Add(provider);
        }

        public TProvider GetProvider<TProvider>()
            where TProvider: class, IProvider<IMovable>
        {
            return _providers.FirstOrDefault(p => p is TProvider) as TProvider;
        }

        public void RemoveProvider<TProvider>()
            where TProvider: class, IProvider<IMovable>
        {
            _providers.Remove(GetProvider<TProvider>());
        }

        public bool ContainsProvider<TProvider>()
            where TProvider : class, IProvider<IMovable>
        {
            return _providers.Any(p => p is TProvider);
        }

        private ICollection<IProvider<IMovable>> _providers = new List<IProvider<IMovable>>();
    }
}
