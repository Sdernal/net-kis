using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory {
    class TransportFactory {
        private List<IFactoryProvider<Transport>> providers_;

        public TransportFactory() {
            providers_ = new List<IFactoryProvider<Transport>>();
        }

        public void AddProvider(IFactoryProvider<Transport> Provider) {
            for (int i = 0; i < providers_.Count(); ++i) {
                if (providers_[i].GetType().FullName == Provider.GetType().FullName) {
                    providers_[i] = Provider;
                    return;
                }
            }
            providers_.Add(Provider);
        }

        public T GetProvider<T>() where T : class, IFactoryProvider<Transport> {
            foreach (var Provider in providers_) {
                if (Provider is T) {
                    return Provider as T;
                }
            }
            return null;
        }

        public bool RemoveProvider<T>() where T : class, IFactoryProvider<Transport> {
            for (int i = 0; i < providers_.Count(); ++i) {
                if (providers_[i] is T) {
                    providers_.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
