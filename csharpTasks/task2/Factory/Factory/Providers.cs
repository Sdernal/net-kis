using System;

namespace Factory
{
    class CarProvider : IFactoryProvider<Car>
    {
        public Car CreateObject()
        {
            return new Car("CAR", 4);
        }

        public Type GetTypeOfProvidedObject()
        {
            return typeof(Car);
        }
    }
    
    class TruckProvider : IFactoryProvider<Truck>
    {
        public int Capacity { get; }
        public string Name { get; }

        public TruckProvider(int capacity, string name)
        {
            Capacity = capacity;
            Name = name;
        }

        public Truck CreateObject()
        {
            return new Truck(Name, 4, Capacity);
        }

        public Type GetTypeOfProvidedObject()
        {
            return typeof(Truck);
        }
    }
    
    class PlaneProvider : IFactoryProvider<Plane>
    {
        public Plane CreateObject()
        {
            return new Plane("PLANE", 2);
        }

        public Type GetTypeOfProvidedObject()
        {
            return typeof(Plane);
        }
    }
    
    static class Extensions
    {
        public static Car CreateCar(this Factory factory)
        {
            return factory.GetProvider<CarProvider>().CreateObject();
        }
        public static Truck CreateTruck(this Factory factory)
        {
            return factory.GetProvider<TruckProvider>().CreateObject();
        }
        public static Plane CreatePlane(this Factory factory)
        {
            return factory.GetProvider<PlaneProvider>().CreateObject();
        }
    }
}