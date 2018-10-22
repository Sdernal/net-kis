using System;

namespace Factory
{
    class CarProvider : IFactoryProvider
    {
        public IMovable CreateObject()
        {
            throw new NotImplementedException();
        }
    }

    class TruckProvider : CarProvider // TODO: think about this inheritance
    {
    }

    class PlaneProvider : IFactoryProvider
    {
        public IMovable CreateObject()
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