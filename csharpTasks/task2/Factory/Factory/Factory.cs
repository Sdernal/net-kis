using System;
using System.Collections.Generic;

namespace Factory
{
    public partial class Factory
    {
        private readonly Dictionary<Type, IFactoryProvider<IMovable>> _providers = new Dictionary<Type, IFactoryProvider<IMovable>>();
        
        public void AddProvider(IFactoryProvider<IMovable> provider)
        {
            Type providerType = provider.GetType().GetMethod("CreateObject").ReturnType;
            _providers[providerType] = provider;
        }

        public T GetProvider<T>() where T : IFactoryProvider<IMovable>
        {
            Type providerType = typeof(T).GetMethod("CreateObject").ReturnType;
            if (_providers.TryGetValue(providerType, out var result))
            {
                return (T) result;
            }
            throw new NotSupportedException("Provider is not supported");
        }
    }
}