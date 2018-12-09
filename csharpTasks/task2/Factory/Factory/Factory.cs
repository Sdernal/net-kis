using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Factory
    { 
        private List<IFactoryProvider<IMovable>> Providers;

        public Factory()
        {
            Providers = new List<IFactoryProvider<IMovable>>();
        }

        public void AddProvider(IFactoryProvider<IMovable> NewProvider)
        {
            Providers.Add(NewProvider);
        }
        
        public T GetProvider<T>() where T: class, IFactoryProvider<IMovable>
        {
            T Provider = null;
            foreach (IFactoryProvider<IMovable> provider in Providers)
            {
                if ((Provider = provider as T) != null)
                {
                    return Provider;
                }
            }
            return null;
        }
    }
    static class FactoryExtensions
    {
        public static Car CreateCar(this Factory F)
        {
            return F.GetProvider<CarProvider>()?.CreateObject();
        }
        public static BMW CreateBMW(this Factory F)
        {
            return F.GetProvider<BMWProvider>()?.CreateObject();
        }
        public static Zeppelin CreateZeppelin(this Factory F)
        {
            return F.GetProvider<ZeppelinProvider>()?.CreateObject();
        }
    }
}
