using Factory.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public class CarProvider : IProvider<Car>
    {
        public CarProvider(int numberOfPassengers=4, int numberOfWheels=4, string name="unknown")
        {
            Name = name;
            NumberOfPassengers = numberOfPassengers;
            NumberOfWheels = numberOfWheels;
        }

        public Car CreateObject()
        {
            return new Car() { Name = this.Name, NumberOfWheels = this.NumberOfWheels,
                NumberOfPassengers = this.NumberOfPassengers };
        }

        public string Name { get; set; }
        public int NumberOfPassengers { get; set; }
        public int NumberOfWheels { get; set; }
    }

    public static class CarFactoryExtension
    {
        public static Car CreateCar(this Factory factory)
        {
            return factory.GetProvider<CarProvider>()?.CreateObject();
        }
    }
}
