using Factory.Providers;
using Factory.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Factory
    {
        public Factory()
        {
            providers_ = new List<IProvider<IVechile>>();
        }
        
        public void AddProvider(IProvider<IVechile> provider)
        {
            providers_.Add(provider);
        }

        public TProvider GetProvider<TProvider>() where TProvider: class, IProvider<IVechile>
        {
            return providers_.FirstOrDefault(item => item is TProvider) as TProvider;
        }

        private ICollection<IProvider<IVechile>> providers_;
    }
}
