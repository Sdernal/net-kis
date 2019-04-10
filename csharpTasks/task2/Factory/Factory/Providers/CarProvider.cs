using Factory.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public class CarProvider: IProvider<Car>
    {
        private string Name;
        private Int64 FuelCapacity;
        private double FuelConsumption;
        private int CountWheels;
        public CarProvider(int count_wheels = 4, string name = "Lada", Int64 fuel_cap = 100, double fuel_comp = 1)
        {
            Name = name;
            FuelCapacity = fuel_cap;
            FuelConsumption = fuel_comp;
            CountWheels = count_wheels;
        }
        public Car CreateObject()
        {
            return new Car(CountWheels, Name, FuelCapacity, FuelConsumption);
        }
    }

    public static class CarFactoryExtension
    {
        public static Car CreateCar(this Factory factory)
        {
            return factory.GetProvider<CarProvider>()?.CreateObject();
        }
    }
}
