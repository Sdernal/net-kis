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

    class TruckProvider : IFactoryProvider<Truck>
    {
        public TruckProvider(string name, uint passengerSeats,
            uint wheels, uint maxWeight)
        {
            Name = name;
            PassengerSeats = passengerSeats;
            Wheels = wheels;
            MaxWeight = maxWeight;
        }

        public Truck CreateObject()
        {
            return new Truck(Name, PassengerSeats, Wheels, MaxWeight);
        }

        public string Name { get; set; }
        public uint PassengerSeats { get; set; }
        public uint Wheels { get; set; }
        public uint MaxWeight { get; set; }
    }

    class PlaneProvider : IFactoryProvider<Plane>
    {
        public PlaneProvider(string name, uint wings, uint wheels, uint maxTakeOffWeight)
        {
            Name = name;
            Wings = wings;
            Wheels = wheels;
            MaxTakeOffWeight = maxTakeOffWeight;
        }

        public Plane CreateObject()
        {
            return new Plane(Name, Wings, Wheels, MaxTakeOffWeight);
        }

        public string Name { get; set; }
        public uint Wings { get; set; }
        public uint Wheels { get; set; }
        public uint MaxTakeOffWeight { get; set; }
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