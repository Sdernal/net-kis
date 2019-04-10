using Factory.Providers;
using Factory.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public class TruckProvider: IProvider<Truck>
    {
        private double weight_;
        private string name_;
        private Int64 fuel_capacity_;
        private double fuel_consumption_;
        public TruckProvider(double weight = 1000, string name = "truck", Int64 capacity = 1000, double consump = 0.5)
        {
            weight_ = weight;
            name_ = name;
            fuel_capacity_ = capacity;
            fuel_consumption_ = consump;
        }

        public Truck CreateObject()
        {
            return new Truck(weight_, name_, fuel_capacity_, fuel_consumption_);
        }
    }

    public static class TruckFactoryExtension
    {
        public static Truck CreateTruck(this Factory factory)
        {
            return factory.GetProvider<TruckProvider>()?.CreateObject();
        }
    }
}
