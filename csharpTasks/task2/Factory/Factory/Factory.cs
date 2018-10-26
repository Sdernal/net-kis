using System;
using System.Linq;

namespace Factory
{
    class Factory
    {
        public void AddProvider(IFactoryProvider<IMovable> provider)
        {
            throw new NotImplementedException();
        }

        public T GetProvider<T>() where T : class, IFactoryProvider<IMovable>
        {
            return _providers.OfType<T>().Select(provider => provider as T)
                .FirstOrDefault();
        }

        private IFactoryProvider<IMovable>[] _providers;
    }
}