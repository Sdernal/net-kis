using Factory.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public class TruckProvider : CarProvider, IProvider<Truck>
    {
        public TruckProvider(int capacity, string name) : base(1, 12, name)
        {
            Capacity = capacity;
        }

        public TruckProvider(int numberOfPassengers, int numberOfWheels, string name, int capacity): 
            base(numberOfPassengers, numberOfWheels, name)
        {
            Capacity = capacity;
        }

        public new Truck CreateObject()
        {
            return new Truck()
            {
                NumberOfPassengers = this.NumberOfPassengers,
                Capacity = this.Capacity,
                NumberOfWheels = this.NumberOfWheels,
                Name = this.Name
            };
        }

        public int Capacity { get; set; }
    }

    public static class TruckFactoryExtension
    {
        public static Truck CreateTruck(this Factory factory)
        {
            return factory.GetProvider<TruckProvider>()?.CreateObject();
        }
    }
}
