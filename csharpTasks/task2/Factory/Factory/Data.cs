using System;

namespace Factory
{
    class Car : IMovable
    {
        public void Move()
        {
            throw new NotImplementedException();
        }
    }

    class Truck : Car
    {
    }

    class Plane : IMovable
    {
        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}