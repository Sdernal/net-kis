using System.Collections.Generic;
using System.Linq;

namespace Factory
{
    class Factory
    {
        public Factory()
        {
            _providers = new List<IFactoryProvider<IMovable>>();
        }

        public void AddProvider(IFactoryProvider<IMovable> provider)
        {
            for (var i = 0; i < _providers.Count; ++i)
            {
                if (_providers[i].GetType() != provider.GetType()) continue;
                _providers[i] = provider;
                return;
            }

            _providers.Add(provider);
        }

        public T GetProvider<T>() where T : class, IFactoryProvider<IMovable>
        {
            return _providers.OfType<T>().Select(provider => provider)
                .FirstOrDefault();
        }

        public void RemoveProvider<T>() where T : class,
            IFactoryProvider<IMovable>
        {
            for (var i = 0; i < _providers.Count; ++i)
            {
                if (_providers[i].GetType() != typeof(T)) continue;
                _providers.RemoveAt(i);
                return;
            }
        }

        private List<IFactoryProvider<IMovable>> _providers;
    }
}