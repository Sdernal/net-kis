using System;
using System.Collections.Generic;

namespace Factory 
{
    public class Factory 
    {
        private List<IProvider<Transport>> providers;


        public Factory()
        {
            providers = new List<IProvider<Transport>>();
        }
        public void AddProvider(IProvider<Transport> provider)
        {
            providers.Add(provider);
        }

        public TypeProvider GetProvider<TypeProvider>() where TypeProvider : class, IProvider<Transport>
        {
            for (var i = 0; i < providers.Count; i++)
            {
                if (providers[i] is TypeProvider)
                {
                    return providers[i] as TypeProvider;
                }
            }
            return null;
        }

        public void RemoveProvider<TypeProvider>() where TypeProvider : class, IProvider<Transport>
        {
            for (var i = 0;i < providers.Count;i++)
            {
                if (providers[i] is TypeProvider)
                {
                    providers.RemoveAt(i);
                }
            }
        }
    }
    
}