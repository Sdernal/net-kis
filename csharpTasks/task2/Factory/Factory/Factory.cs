using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Factory
    {
        private CarProvider CProvider;
        private BMWProvider BProvider;
        private ZeppelinProvider ZProvider;

        public void AddProvider(Provider NewProvider)
        {
            string type = NewProvider.GetProviderType();
            if (type == "Car")
            {
                CProvider = (CarProvider)NewProvider;
            }
            else if (type == "BMW")
            {
                BProvider = (BMWProvider)NewProvider;
            }
            else if (type == "Zeppelin")
            {
                ZProvider = (ZeppelinProvider)NewProvider;
            }
            else
            {
                throw new Exception("Wrong Provider!");
            }

        }
        
        public Provider GetProvider<T>() where T: Provider
        {
            string type = typeof(T).Name;
            if (type == "CarProvider")
            {
                return CProvider;
            }
            else if (type == "BMWProvider")
            {
                return BProvider;
            }
            else if (type == "ZeppelinProvider")
            {
                return ZProvider;
            }
            else
            {
                throw new Exception("Wrong Provider!");
            }
        }
    }
    static class FactoryExtensions
    {
        public static Car CreateCar(this Factory F)
        {
            return (Car)F.GetProvider<CarProvider>().CreateObject();
        }
        public static BMW CreateBMW(this Factory F)
        {
            return (BMW)F.GetProvider<BMWProvider>().CreateObject();
        }
        public static Zeppelin CreateZeppelin(this Factory F)
        {
            return (Zeppelin)F.GetProvider<ZeppelinProvider>().CreateObject();
        }
    }
}
