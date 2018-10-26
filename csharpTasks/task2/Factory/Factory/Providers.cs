using System;

namespace Factory
{
    class CarProvider : IFactoryProvider<Car>
    {
        public CarProvider(string name, uint passengerSeats, uint wheels)
        {
            Name = name;
            PassengerSeats = passengerSeats;
            Wheels = wheels;
        }

        public Car CreateObject()
        {
            return new Car(Name, PassengerSeats, Wheels);
        }

        public string Name { get; set; }
        public uint PassengerSeats { get; set; }
        public uint Wheels { get; set; }
    }

    class TruckProvider : IFactoryProvider<Truck> // TODO: think about this inheritance
    {
        public TruckProvider(int a, string b) // TODO: rename it
        {
            _a = a;
            _b = b;
        }

        public Truck CreateObject()
        {
            throw new NotImplementedException();
        }

        private int _a;
        private string _b; // TODO: rename it
    }

    class PlaneProvider : IFactoryProvider<Plane>
    {
        public Plane CreateObject()
        {
            throw new NotImplementedException();
        }
    }

    static class FactoryExtensions
    {
        public static Car CreateCar(this Factory factory)
        {
            throw new NotImplementedException();
        }

        public static Truck CreateTruck(this Factory factory)
        {
            throw new NotImplementedException();
        }

        public static Plane CreatePlane(this Factory factory)
        {
            throw new NotImplementedException();
        }
    }
}