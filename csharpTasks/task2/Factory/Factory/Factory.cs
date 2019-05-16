using System.Collections.Generic;
namespace Factory
{
    class Factory
    {
        private List<IFactoryProvider<IMovable>> providers;

        public Factory()
        {
            providers = new List<IFactoryProvider<IMovable>>();
        }
        public T GetProvider<T>() where T : class, IFactoryProvider<IMovable>
        {
            T Provider = null;
            foreach (IFactoryProvider<IMovable> provider in providers)
            {
                if ((Provider = provider as T) != null)
                {
                    return Provider;
                }
            }
            return null;
        }

        public void AddProvider(IFactoryProvider<IMovable> NewProvider)
        {
            providers.Add(NewProvider);
        }
        public void DeleteProvider<T>() where T : class, IFactoryProvider<IMovable>
        {
            for (var i = 0; i < providers.Count; i++)
            {
                if (providers[i].GetType() != typeof(T)) continue;
                providers.RemoveAt(i);
                return;
            }
        }
    }
}